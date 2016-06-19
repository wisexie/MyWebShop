using MyWebShop.Models;
using MyWebShop.Services;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Mvc;
using Orchard.Security;
using Orchard.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.ContentManagement;
using Orchard;
using MyWebShop.Extensibility;

namespace MyWebShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IShoppingCart _shoppingCart;
        private readonly ICustomerService _customerService;
        private readonly Localizer _t;
        IOrchardServices _services;
        private readonly IEnumerable<IPaymentServiceProvider> _paymentServiceProviders;
        public OrderController(
            IOrchardServices services,
            IOrderService orderService,
            IAuthenticationService authenticationService,
            IShoppingCart shoppingCart,
            ICustomerService customerService,
            IEnumerable<IPaymentServiceProvider> paymentServiceProviders)
        {
            _services = services;
            _orderService = orderService;
            _authenticationService = authenticationService;
            _shoppingCart = shoppingCart;
            _customerService = customerService;
            _t = NullLocalizer.Instance;
            _paymentServiceProviders = paymentServiceProviders;
        }

        [Themed, HttpPost]
        public ActionResult Create()
        {
            var user = _authenticationService.GetAuthenticatedUser();

            if (user == null)
                throw new OrchardSecurityException(_t("Login required"));

            var customer = user.ContentItem.As<CustomerPart>();

            if (customer == null)
                throw new InvalidOperationException("The current user is not a customer");

            var order = _orderService.CreateOrder(customer.Id, _shoppingCart.Items);

            // Fire the PaymentRequest event
            var paymentRequest = new PaymentRequest(order);

            foreach (var handler in _paymentServiceProviders)
            {
                handler.RequestPayment(paymentRequest);

                // If the handler responded, it will set the action result
                if (paymentRequest.WillHandlePayment)
                {
                    return paymentRequest.ActionResult;
                }
            }

            // If we got here, no PSP handled the OrderCreated event, so we'll just display the order.
            var shape = _services.New.Order_Created(
                Order: order,
                Products: _orderService.GetProducts(order.Details).Select(x => _services.New.Order_Product
                    (
                        ProductPart: x,
                        Title: _services.ContentManager.GetItemMetadata(x).DisplayText)
                    ).ToArray(),
                Customer: customer,
                InvoiceAddress: (dynamic)_customerService.GetAddress(user.Id, "InvoiceAddress"),
                ShippingAddress: (dynamic)_customerService.GetAddress(user.Id, "ShippingAddress")
            );
            var product = _orderService.GetProducts(order.Details).Select(x => _services.New.Order_Product
                    (
                        ProductPart: x,
                        Title: _services.ContentManager.GetItemMetadata(x).DisplayText)
                    ).ToArray();

            return new ShapeResult(this, shape);
        }

        [Themed]
        public ActionResult PaymentResponse()
        {

            var args = new PaymentResponse(HttpContext);

            foreach (var handler in _paymentServiceProviders)
            {
                handler.ProcessResponse(args);

                if (args.WillHandleResponse)
                    break;
            }

            if (!args.WillHandleResponse)
                throw new OrchardException(_t("Such things mean trouble"));

            var order = _orderService.GetOrderByNumber(args.OrderReference);
            _orderService.UpdateOrderStatus(order, args);

            if (order.Status == OrderStatus.Paid)
            {
                // Send some notification mail message to the customer that the order was paid.
                // We may also initiate the shipping process from here
            }

            return new ShapeResult(this, _services.New.Order_PaymentResponse(Order: order, PaymentResponse: args));
        }
    }

}