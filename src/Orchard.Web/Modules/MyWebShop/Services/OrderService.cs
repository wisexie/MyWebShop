using MyWebShop.Extensibility;
using MyWebShop.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Data;
using Orchard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop.Services
{
    public class OrderService : IOrderService 
    {
        private readonly IOrchardServices _orchardServices;
        private readonly IClock _clock;
        IContentManager _contentManager;

        public OrderService(IOrchardServices services, IClock clock, IContentManager contentManager)
        {
            _orchardServices = services;
            _clock = clock;
            _contentManager = contentManager;
        }

        public OrderPart CreateOrder(int customerId, IEnumerable<ShoppingCartItem> items)
        {

            if (items == null)
                throw new ArgumentNullException("items");

            // Convert to an array to avoid re-running the enumerable
            var itemsArray = items.ToArray();

            if (!itemsArray.Any())
                throw new ArgumentException("Creating an order with 0 items is not supported", "items");


            var orderPart = _orchardServices.ContentManager.Create<OrderPart>("Order", x =>
            {
                x.CreatedAt = _clock.UtcNow;
                x.CustomerId = customerId;
                x.Status = OrderStatus.New;
            });


            // Get all products in one shot, so we can add the product reference to each order detail
            var productIds = itemsArray.Select(x => x.ProductId).ToArray();
            var products = _orchardServices.ContentManager.GetMany<ProductPart>(productIds, VersionOptions.Latest, QueryHints.Empty).ToArray(); ;

            // Create an order detail for each item
            foreach (var item in itemsArray)
            {
                var product = products.Single(x => x.Id == item.ProductId);

                var orderDetailPart = _orchardServices.ContentManager.Create<OrderDetailPart>("OrderDetail", x =>
                {
                    x.OrderRecord_Id = orderPart.Id;
                    x.ProductId = product.Id;
                    x.Quantity = item.Quantity;
                    x.UnitPrice = product.UnitPrice;
                    x.VatRate = .19m;
                });


                orderPart.Details.Add(orderDetailPart);
            }

            orderPart.UpdateTotals();

            return orderPart;
        }

        /// <summary>
        /// Gets a list of ProductParts from the specified list of OrderDetails. Useful if you need to use the product as a ProductPart (instead of just having access to the ProductRecord instance).
        /// </summary>
        public IEnumerable<ProductPart> GetProducts(IEnumerable<OrderDetailPart> orderDetails)
        {
            var productIds = orderDetails.Select(x => x.ProductId).ToArray();
            return _orchardServices.ContentManager.GetMany<ProductPart>(productIds, VersionOptions.Latest, QueryHints.Empty);
        }

        public OrderPart GetOrderByNumber(string orderNumber)
        {
            var orderId = int.Parse(orderNumber) - 1000;
            var orderPart = _contentManager.Query<OrderPart,OrderPartRecord>().Where(x=>x.Id==orderId).List().SingleOrDefault();
            return orderPart;
        }

        public void UpdateOrderStatus(OrderPart order, PaymentResponse paymentResponse)
        {
            OrderStatus orderStatus;

            switch (paymentResponse.Status)
            {
                case PaymentResponseStatus.Success:
                    orderStatus = OrderStatus.Paid;
                    break;
                default:
                    orderStatus = OrderStatus.Cancelled;
                    break;
            }

            if (order.Status == orderStatus)
                return;

            order.Status = orderStatus;
            order.PaymentServiceProviderResponse = paymentResponse.ResponseText;
            order.PaymentReference = paymentResponse.PaymentReference;

            switch (order.Status)
            {
                case OrderStatus.Paid:
                    order.PaidAt = _clock.UtcNow;
                    break;
                case OrderStatus.Completed:
                    order.CompletedAt = _clock.UtcNow;
                    break;
                case OrderStatus.Cancelled:
                    order.CancelledAt = _clock.UtcNow;
                    break;
            }
        }
        public IEnumerable<OrderPart> GetOrders(int customerId)
        {
            return _contentManager.Query<OrderPart,OrderPartRecord>().Where(x => x.CustomerId == customerId).List();
        }

        public IEnumerable<OrderPart> GetOrders()
        {
            return _contentManager.Query<OrderPart, OrderPartRecord>().List() ;
        }
        public OrderPart GetOrder(int id)
        {
            return _contentManager.Get<OrderPart>(id);
        }

    }
}