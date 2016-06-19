using MyWebShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebShop.Extensibility
{
    public class PaymentRequest
    {
        public OrderPart Order { get; private set; }
        public bool WillHandlePayment { get; set; }
        public ActionResult ActionResult { get; set; }

        public PaymentRequest(OrderPart order)
        {
            Order = order;
        }

    }
}