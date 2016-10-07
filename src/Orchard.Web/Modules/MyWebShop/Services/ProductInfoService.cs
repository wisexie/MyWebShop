using MyWebShop.Models;
using Orchard.Autoroute.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;

namespace MyWebShop.Services
{
    public class ProductInfoService : IProductInfoService
    {
        private readonly IPathResolutionService _pathResolutionService;
        public ProductInfoService(IPathResolutionService pathResolutionService)
        {
            _pathResolutionService = pathResolutionService;
        }

        public ProductPart GetProduct(string path)
        {
            var Product = _pathResolutionService.GetPath(path);
            ProductPart product = Product.ContentItem.As<ProductPart>();
            return product;
        }
    }
}