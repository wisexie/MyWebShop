using Orchard.Environment;
using Orchard.Localization;
using Orchard.UI.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MyWebShop
{
    public class AdminMenu : INavigationProvider
    {
        private readonly Work<RequestContext> _requestContextAccessor;
        public string MenuName
        {
            get { return "admin"; }
        }

        public AdminMenu(Work<RequestContext> requestContextAccessor)
        {
            _requestContextAccessor = requestContextAccessor;
            T = NullLocalizer.Instance;
        }

        private Localizer T { get; set; }

        public void GetNavigation(NavigationBuilder builder)
        {
            builder.AddImageSet("webshop")
                .Add(T("webshop"), "2.5", BuildMenu);
        }

        private void BuildMenu(NavigationItemBuilder menu)
        {
            var requestContext = _requestContextAccessor.Value;
            var idValue = (string)requestContext.RouteData.Values["id"];
            var id = 0;

            if (!string.IsNullOrEmpty(idValue))
            {
                int.TryParse(idValue, out id);
            }

            menu.Add(T("Orders"), "2.0",
                     item =>
                     item.Action("Index", "OrderAdmin", new { area = "MyWebShop" }));

            menu.Add(T("Customers"), "2.1",
                     item =>
                     item.Action("Index", "CustomerAdmin", new { area = "MyWebShop" }));
            menu.Add(T("Orders"), "2.1",
                     item =>
                      item.Action("Index", "OrderAdmin", new { area = "MyWebShop" })
                      )
                      .Add(T("Details"), i => i.Action("Edit", "CustomerAdmin", new { id }).LocalNav())
                      .Add(T("Addresses"), i => i.Action("ListAddresses", "CustomerAdmin", new { id }).LocalNav())
                     .Add(T("Orders"), i => i.Action("ListOrders", "CustomerAdmin", new { id }).LocalNav());

        }

    }
}