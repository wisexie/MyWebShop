using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop.ViewModels
{
    public class CustomersIndexViewModel
    {
        public IList<dynamic> Customers { get; set; }
        public dynamic Pager { get; set; }
        public CustomersSearchViewModel Search { get; set; }

        public CustomersIndexViewModel() {
            Search = new CustomersSearchViewModel();
        }

        public CustomersIndexViewModel(IEnumerable<dynamic> customers, CustomersSearchViewModel search, dynamic pager)
        {
            Customers = customers.ToArray();
            Search = search;
            Pager = pager;
        }
    }
}