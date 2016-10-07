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
using Orchard.Autoroute.Models;
using Orchard.Autoroute.Services;
using MyWebShop.Services;
using Orchard.MediaLibrary.Fields;
using Orchard.Core.Common.Models;
using Orchard.Comments.Models;
using Orchard.MediaLibrary.Models;

namespace MyWebShop.Controllers
{
    public class ProductInfoController : Controller
    {
        private readonly IOrchardServices _services;
        private readonly IProductInfoService _productInfoService;

        public ProductInfoController(IOrchardServices services, IProductInfoService productInfoService)
        {
            _services = services;
            _productInfoService = productInfoService;
        }

        [Themed]
        public ActionResult Index()
        {
            var productInfo= _productInfoService.GetProduct(Request.AppRelativeCurrentExecutionFilePath.Replace("~/", ""));
            var shape = _services.New.ProductInfo(
                          product: productInfo,
                          title: _services.ContentManager.GetItemMetadata(productInfo).DisplayText,
                          productImages: productInfo.ContentItem.Parts.SelectMany(x => x.Fields.OfType<MediaLibraryPickerField>()).SelectMany(x => x.MediaParts).ToList(),
                          productBody:productInfo.ContentItem.As<BodyPart>(),
                          productComment:productInfo.ContentItem.As<CommentPart>()
                  );

            return new ShapeResult(this, shape);
        }
	}
}