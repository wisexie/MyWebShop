using Orchard.ContentManagement.Records;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MyWebShop.Models
{
    public class OrderPartRecord : ContentPartRecord 
    {
        public virtual int CustomerId { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual decimal SubTotal { get; set; }
        public virtual decimal Vat { get; set; }
        public virtual OrderStatus Status { get; set; }
        public virtual string PaymentServiceProviderResponse { get; set; }
        public virtual string PaymentReference { get; set; }
        public virtual DateTime? PaidAt { get; set; }
        public virtual DateTime? CompletedAt { get; set; }
        public virtual DateTime? CancelledAt { get; set; }

    }
}