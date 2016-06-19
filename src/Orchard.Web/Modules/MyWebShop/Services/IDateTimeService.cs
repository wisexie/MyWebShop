using Orchard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop.Services
{
    public interface IDateTimeService : IDependency 
    {
        DateTime Now { get; }
    }
}