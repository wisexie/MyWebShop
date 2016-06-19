using MyWebShop.Extensibility;
using MyWebShop.Models;
using Orchard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebShop.Services
{
    public interface IOrderService : IDependency 
    {
        /// <summary>
        /// Creates a new order based on the specified ShoppingCartItems
        /// </summary>
        OrderPart CreateOrder(int customerId, IEnumerable<ShoppingCartItem> items);

        /// <summary>
        /// Gets a list of ProductParts from the specified list of OrderDetails. Useful if you need to use the product as a ProductPart (instead of just having access to the ProductRecord instance).
        /// </summary>
        IEnumerable<ProductPart> GetProducts(IEnumerable<OrderDetailPart> orderDetails);
        OrderPart GetOrderByNumber(string orderNumber);
        void UpdateOrderStatus(OrderPart order, PaymentResponse paymentResponse);
        IEnumerable<OrderPart> GetOrders(int customerId);
        IEnumerable<OrderPart> GetOrders();
        OrderPart GetOrder(int id);
    }
}
