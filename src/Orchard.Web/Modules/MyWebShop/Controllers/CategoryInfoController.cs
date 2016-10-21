using MyWebShop.Services;
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
    public class CategoryInfoController : Controller
    {
        private readonly IOrchardServices _services;
        private readonly ICategoryInfoService _categoryServer;

        public CategoryInfoController(IOrchardServices services, ICategoryInfoService categoryServer)
        {
            _services = services;
            _categoryServer = categoryServer;
        }
         [Themed]
        public ActionResult Index(string title)
        {
            var shape = _services.New.CategoryInfo(Products: _categoryServer.GetProductByType(title));
            return new ShapeResult(this, shape);
        }
    }
}