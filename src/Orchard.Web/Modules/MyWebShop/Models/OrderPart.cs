using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MyWebShop.Models
{
    public class OrderPart : ContentPart<OrderPartRecord>
    {

        public int CustomerId
        {
            get { return Record.CustomerId; }
            set { Record.CustomerId = value; }
        }

        public DateTime CreatedAt
        {
            get { return Record.CreatedAt; }
            set { Record.CreatedAt = value; }
        }

        public decimal SubTotal
        {
            get { return Record.SubTotal; }
            set { Record.SubTotal = value; }
        }

        public decimal Vat
        {
            get { return Record.Vat; }
            set { Record.Vat = value; }
        }

        public OrderStatus Status
        {
            get { return Record.Status; }
            set { Record.Status = value; }
        }
        public string PaymentServiceProviderResponse
        {
            get { return Record.PaymentServiceProviderResponse; }
            set { Record.PaymentServiceProviderResponse = value; }
        }
        public string PaymentReference
        {
            get { return Record.PaymentReference; }
            set { Record.PaymentReference = value; }
        }
        public DateTime? PaidAt
        {
            get { return Record.PaidAt; }
            set { Record.PaidAt = value; }
        }
        public DateTime? CompletedAt
        {
            get { return Record.CompletedAt; }
            set { Record.CompletedAt = value; }
        }
        public DateTime? CancelledAt
        {
            get { return Record.CancelledAt; }
            set { Record.CancelledAt = value; }
        }
        public virtual IList<OrderDetailPart> Details { get; private set; }
        public  decimal Total
        {
            get { return SubTotal + Vat; }
        }

        public string Number
        {
            get { return (Id + 1000).ToString(CultureInfo.InvariantCulture); }
        }

        public OrderPart()
        {
            Details = new List<OrderDetailPart>();
        }

        public void UpdateTotals()
        {
            var subTotal = 0m;
            var vat = 0m;

            foreach (var detail in Details)
            {
                subTotal += detail.SubTotal;
                vat += detail.Vat;
            }

            SubTotal = subTotal;
            Vat = vat;
        }
    }
}