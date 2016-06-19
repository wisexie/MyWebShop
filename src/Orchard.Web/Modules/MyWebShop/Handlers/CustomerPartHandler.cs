using MyWebShop.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop.Handlers
{
    public class CustomerPartHandler : ContentHandler 
    {
        public CustomerPartHandler(IRepository<CustomerPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
            Filters.Add(new ActivatingFilter<UserPart>("Customer"));
        }

    }
}