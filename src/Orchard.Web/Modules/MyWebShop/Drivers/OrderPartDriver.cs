using MyWebShop.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop.Drivers
{
    public class OrderPartDriver : ContentPartDriver<OrderPart> 
    {
        protected override string Prefix
        {
            get { return "Order"; }
        }

        protected override DriverResult Editor(OrderPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_Order_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Parts/Order", Model: part, Prefix: Prefix));
        }

        protected override DriverResult Editor(OrderPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

    }
}