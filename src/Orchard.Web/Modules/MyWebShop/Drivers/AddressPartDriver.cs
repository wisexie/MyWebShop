﻿using MyWebShop.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop.Drivers
{
    public class AddressPartDriver : ContentPartDriver<AddressPart> 
    {
        protected override string Prefix
        {
            get { return "Address"; }
        }

        protected override DriverResult Editor(AddressPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_Address_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Parts/Address", Model: part, Prefix: Prefix));
        }

        protected override DriverResult Editor(AddressPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

    }
}