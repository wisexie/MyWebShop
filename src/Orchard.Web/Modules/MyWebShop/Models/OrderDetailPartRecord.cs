using Orchard.ContentManagement.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop.Models
{
    public class OrderDetailPartRecord : ContentPartRecord 
    {
        public virtual int OrderRecord_Id { get; set; }
        public virtual int ProductId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual decimal VatRate { get; set; }

    }
}