using Orchard.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebShop.Extensibility
{
    public interface IPaymentServiceProvider : IEventHandler 
    {
        void RequestPayment(PaymentRequest e);
        void ProcessResponse(PaymentResponse e);

    }
}
