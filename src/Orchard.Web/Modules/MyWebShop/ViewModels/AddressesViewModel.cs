using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebShop.ViewModels
{
    public class AddressesViewModel : IValidatableObject 
    {
        [UIHint("Address")]
        public AddressViewModel InvoiceAddress { get; set; }

        [UIHint("Address")]
        public AddressViewModel ShippingAddress { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var address = InvoiceAddress;

            if (string.IsNullOrWhiteSpace(address.AddressLine1))
                yield return new ValidationResult("请填写地址", new[] { "InvoiceAddress.AddressLine1" });

            if (string.IsNullOrWhiteSpace(address.Zipcode))
                yield return new ValidationResult("请填写邮编", new[] { "InvoiceAddress.Zipcode" });

            if (string.IsNullOrWhiteSpace(address.City))
                yield return new ValidationResult("请填写城市", new[] { "InvoiceAddress.City" });

            if (string.IsNullOrWhiteSpace(address.Country))
                yield return new ValidationResult("请添加国家", new[] { "InvoiceAddress.Country" });
        }

    }
}