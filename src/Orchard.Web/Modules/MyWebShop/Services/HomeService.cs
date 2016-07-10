﻿using MyWebShop.Models;
using Orchard;
using Orchard.Security;
using Orchard.Services;
using Orchard.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.Core.Title.Models;
using Orchard.ContentManagement.Records;

namespace MyWebShop.Services
{
    public class HomeService:IHomeService
    {
        private readonly IOrchardServices _services;
        public HomeService(IOrchardServices services)
        {
            _services = services;
        }
        public IEnumerable<ProductPart> GetHomeProductCategory()
        {
            return _services.ContentManager.Query<ProductPart, ProductPartRecord>()
                .List();
        }
    }
}