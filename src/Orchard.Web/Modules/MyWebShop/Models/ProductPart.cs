using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop.Models
{
    public class ProductPart : ContentPart<ProductPartRecord>
    {
        public decimal UnitPrice
        {
            get { return Record.UnitPrice; }
            set { Record.UnitPrice = value; }
        }

        public string Sku
        {
            get { return Record.Sku; }
            set { Record.Sku = value; }
        }

        public bool IsShowAtHome
        {
            get { return Record.IsShowAtHome; }
            set { Record.IsShowAtHome = value; }
        }

    }
}