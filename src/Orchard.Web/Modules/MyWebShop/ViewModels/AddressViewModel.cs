using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebShop.ViewModels
{
    public class AddressViewModel
    {
        [StringLength(50), Display(Name = "地址名称")]
        public string Name { get; set; }

        [StringLength(256), Display(Name = "地址 1")]
        public string AddressLine1 { get; set; }

        [StringLength(256), Display(Name = "地址 2")]
        public string AddressLine2 { get; set; }

        [StringLength(10), Display(Name = "邮编")]
        public string Zipcode { get; set; }

        [StringLength(50), Display(Name = "城市")]
        public string City { get; set; }

        [StringLength(50), Display(Name = "国家")]
        public string Country { get; set; }

    }
}