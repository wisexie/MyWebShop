using MyWebShop.Models;
using Orchard.ContentManagement.Drivers;
using Orchard.Indexing;
using Orchard.Search.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop.Drivers
{
    public class MyShopHeaderWidgetPartDriver : ContentPartDriver<MyShopHeaderWidgetPart>
    {
        private readonly IIndexManager _indexManager;
        public MyShopHeaderWidgetPartDriver(IIndexManager indexManager)
        {
            _indexManager = indexManager;
        }

        protected override DriverResult Display(MyShopHeaderWidgetPart part, string displayType, dynamic shapeHelper)
        {
            var model = new SearchViewModel();
            return ContentShape("Parts_MyShopHeaderWidget", () => shapeHelper.Parts_MyShopHeaderWidget(
                ViewModel:model
     ));
        }
    }
}