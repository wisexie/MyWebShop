﻿using MyWebShop.Services;
using MyWebShop.ViewModels;
using Orchard;
using Orchard.Mvc;
using Orchard.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IOrchardServices _services;

        public ShoppingCartController(IShoppingCart shoppingCart, IOrchardServices services)
        {
            _shoppingCart = shoppingCart;
            _services = services;
        }

        [HttpPost]
        public ActionResult Add(int id)
        {

            // Add the specified content id to the shopping cart with a quantity of 1.
            _shoppingCart.Add(id, 1);

            // Redirect the user to the Index action (yet to be created)
            return RedirectToAction("Index");
        }
         [Themed] 
        public ActionResult Index()
        {

            var shape = _services.New.ShoppingCart(
                  Products: _shoppingCart.GetProducts().Select(p => _services.New.ShoppingCartItem(
                      ProductPart: p.ProductPart,
                      Quantity: p.Quantity,
                      Title: _services.ContentManager.GetItemMetadata(p.ProductPart).DisplayText)
                  ).ToList(),
                  Total: _shoppingCart.Total(),
                  Subtotal: _shoppingCart.Subtotal(),
                  Vat: _shoppingCart.Vat()
              );

            // Return a ShapeResult
            return new ShapeResult(this, shape);


        }
         public ActionResult Update(string command, UpdateShoppingCartItemViewModel[] items)
         {

             // Loop through each posted item
             foreach (var item in items)
             {

                 // Select the shopping cart item by posted product ID
                 var shoppingCartItem = _shoppingCart.Items.SingleOrDefault(x => x.ProductId == item.ProductId);

                 if (shoppingCartItem != null)
                 {
                     // Update the quantity of the shoppingcart item. If IsRemoved == true, set the quantity to 0
                     shoppingCartItem.Quantity = item.IsRemoved ? 0 : item.Quantity < 0 ? 0 : item.Quantity;
                 }
             }

             // Update the shopping cart so that items with 0 quantity will be removed
             _shoppingCart.UpdateItems();

             // Return an action result based on the specified command
             switch (command)
             {
                 case "Checkout":
                     return RedirectToAction("SignupOrLogin", "Checkout");
                 case "ContinueShopping":
                     break;
                 case "Update":
                     break;
             }

             // Return to Index if no command was specified
             return RedirectToAction("Index");
         }

	}
}