using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop.Models
{
    public class OrderDetailPart : ContentPart<OrderDetailPartRecord>
    {

        public int OrderRecord_Id
        {
            get { return Record.OrderRecord_Id; }
            set { Record.OrderRecord_Id = value; }
        }
        public int ProductId
        {
            get { return Record.ProductId; }
            set { Record.ProductId = value; }
        }
        public int Quantity
        {
            get { return Record.Quantity; }
            set { Record.Quantity = value; }
        }
        public decimal UnitPrice
        {
            get { return Record.UnitPrice; }
            set { Record.UnitPrice = value; }
        }
        public decimal VatRate
        {
            get { return Record.VatRate; }
            set { Record.VatRate = value; }
        }

        public decimal UnitVat
        {
            get { return UnitPrice * VatRate; }
        }

        public decimal Vat
        {
            get { return UnitVat * Quantity; }
        }

        public decimal SubTotal
        {
            get { return UnitPrice * Quantity; }
        }

        public decimal Total
        {
            get { return SubTotal + Vat; }
        }
    }
}