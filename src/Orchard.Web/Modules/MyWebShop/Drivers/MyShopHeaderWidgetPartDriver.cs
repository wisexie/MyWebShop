using MyWebShop.Models;
using Orchard.ContentManagement.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop.Drivers
{
    public class MyShopHeaderWidgetPartDriver : ContentPartDriver<MyShopHeaderWidgetPart>
    {
        public MyShopHeaderWidgetPartDriver()
        {
        }

        protected override DriverResult Display(MyShopHeaderWidgetPart part, string displayType, dynamic shapeHelper)
        {

            return ContentShape("Parts_MyShopHeaderWidget", () => shapeHelper.Parts_MyShopHeaderWidget(

            ));
        }
    }
}