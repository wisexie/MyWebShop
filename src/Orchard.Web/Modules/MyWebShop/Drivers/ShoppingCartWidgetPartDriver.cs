using MyWebShop.Models;
using MyWebShop.Services;
using Orchard.ContentManagement.Drivers;
using Orchard.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;

namespace MyWebShop.Drivers
{
    public class ShoppingCartWidgetPartDriver : ContentPartDriver<ShoppingCartWidgetPart>
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IAuthenticationService _authenticationService;
        private readonly ICustomerService _customerService;
        public ShoppingCartWidgetPartDriver(IShoppingCart shoppingCart, IAuthenticationService authenticationService, ICustomerService customerService)
        {
            _shoppingCart = shoppingCart;
            _authenticationService=authenticationService;
            _customerService = customerService;
        }

        protected override DriverResult Display(ShoppingCartWidgetPart part, string displayType, dynamic shapeHelper)
        {
            var currentUser = _authenticationService.GetAuthenticatedUser();

            return ContentShape("Parts_ShoppingCartWidget", () => shapeHelper.Parts_ShoppingCartWidget(
                ItemCount: _shoppingCart.ItemCount(),
                TotalAmount: _shoppingCart.Total(),
                Customer:currentUser != null? currentUser.ContentItem.As<CustomerPart>():null
            ));
        }
    }

}