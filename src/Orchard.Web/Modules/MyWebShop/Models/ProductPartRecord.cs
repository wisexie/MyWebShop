using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace MyWebShop.Models
{
    public class ProductPartRecord : ContentPartRecord
    {
        public virtual decimal UnitPrice { get; set; }
        public virtual string Sku { get; set; }
    }
}