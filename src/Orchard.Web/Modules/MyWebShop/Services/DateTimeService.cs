using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now
        {
            get { return DateTime.UtcNow; }
        }
    }
}