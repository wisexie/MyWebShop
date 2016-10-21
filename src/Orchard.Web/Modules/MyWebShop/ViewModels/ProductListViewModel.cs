using MyWebShop.Models;
using Orchard.MediaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop.ViewModels
{
    public class ProductListViewModel
    {
        public ProductPart ProductItem { get; set; }
        public string ProductTitle{get;set;}
        public string ProductType { get; set; }
        public string ProductLink { get; set; }
        public MediaPart ProductImage { get; set; }


    }
}