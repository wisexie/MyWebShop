using MyWebShop.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop.Drivers
{
    public class OrderPartDetailPartDriver : ContentPartDriver<OrderDetailPart> 
    {
        protected override string Prefix
        {
            get { return "OrderDetail"; }
        }

        protected override DriverResult Editor(OrderDetailPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_OrderDetail_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Parts/OrderDetail", Model: part, Prefix: Prefix));
        }

        protected override DriverResult Editor(OrderDetailPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}