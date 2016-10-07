using Orchard.UI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            // Create and add a new manifest
            var manifest = builder.Add();

            // Define a "common" style sheet
            manifest.DefineStyle("MyWebShop.Common").SetUrl("common.css");

            // Define the "shoppingcart" style sheet
            manifest.DefineStyle("MyWebShop.ShoppingCart").SetUrl("shoppingcart.css").SetDependencies("MyWebShop.Common");

            // Define the "shoppingcartwidget" style sheet     
            manifest.DefineStyle("MyWebShop.ShoppingCartWidget").SetUrl("shoppingcartwidget.css").SetDependencies("MyWebShop.Common");
            manifest.DefineScript("MyWebShop.ShoppingCart").SetUrl("shoppingcart.js").SetDependencies("jQuery");

            manifest.DefineStyle("MyWebShop.Checkout.Summary").SetUrl("checkout-summary.css").SetDependencies("MyWebShop.Common");

            manifest.DefineStyle("MyWebShop.Order").SetUrl("order.css").SetDependencies("MyWebShop.Common");
            manifest.DefineStyle("MyWebShop.SimulatedPSP").SetUrl("simulated-psp.css").SetDependencies("MyWebShop.Common");
            manifest.DefineStyle("MyWebShop.home").SetUrl("home.css");
            manifest.DefineStyle("MyWebShop.Goods").SetUrl("Goods.css");
            manifest.DefineStyle("MyWebShop.login").SetUrl("login.css");
            manifest.DefineStyle("MyWebShop.Register").SetUrl("Register.css");

            manifest.DefineScript("MyWebShop.PageScroll").SetUrl("PageScroll.js").SetDependencies("jQuery");
            manifest.DefineScript("MyWebShop.hd").SetUrl("hd_js.js").SetDependencies("jQuery");
            manifest.DefineScript("MyWebShop.SuperSlide").SetUrl("jquery.SuperSlide.2.1.js").SetDependencies("jQuery");
        }


    }
}