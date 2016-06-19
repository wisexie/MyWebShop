using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop.Extensibility
{
    public enum PaymentResponseStatus
    {
        Success,
        Failed,
        Cancelled,
        Exception
    }
}