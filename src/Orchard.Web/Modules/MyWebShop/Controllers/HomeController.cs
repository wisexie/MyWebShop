using MyWebShop.Models;
using Orchard;
using Orchard.Mvc;
using Orchard.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.ContentManagement;
using Orchard.Core.Title.Models;
using MyWebShop.Services;
using Orchard.ContentManagement.Records;
using Orchard.MediaLibrary.Fields;

namespace MyWebShop.Controllers
{
    public class HomeController : Controller
    {

        private readonly IOrchardServices _services;
        private readonly IHomeService _homeServices;
        public HomeController(IOrchardServices services,IHomeService homeServices)
        {
            _services = services;
            _homeServices = homeServices;
        }

        [Themed]
        public ActionResult Index()
        {
            var shape = _services.New.Home(
                Products: _services.ContentManager.Query<ProductPart, ProductPartRecord>()
                .List().Select(p => _services.New.ProductPart(
                      ProductPart: p,
                      Title: _services.ContentManager.GetItemMetadata(p).DisplayText,
                      Group:p.As<ContentItem>().TypeDefinition.DisplayName,
                      HomeImage: p.ContentItem.Parts.SelectMany(x => x.Fields.OfType<MediaLibraryPickerField>()).First().MediaParts.FirstOrDefault()
                      ).OrderBy("Group")
                      ).ToList()
                );

            return new ShapeResult(this, shape);


        }
	}
}