using MyWebShop.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop.Handlers
{
    public class OrderDetailPartHandler : ContentHandler 
    {
        public OrderDetailPartHandler(IRepository<OrderDetailPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}