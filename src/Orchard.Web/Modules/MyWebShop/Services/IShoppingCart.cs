using MyWebShop.Models;
using Orchard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebShop.Services
{
    public interface IShoppingCart : IDependency
    {
        IEnumerable<ShoppingCartItem> Items { get; }
        void Add(int productId, int quantity = 1);
        void Remove(int productId);
        ProductPart GetProduct(int productId);
        IEnumerable<ProductQuantity> GetProducts();
        decimal Subtotal();
        decimal Vat();
        decimal Total();
        int ItemCount();
        void UpdateItems();
    }

}
