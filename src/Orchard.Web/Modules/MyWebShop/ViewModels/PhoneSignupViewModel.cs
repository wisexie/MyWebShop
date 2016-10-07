using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebShop.ViewModels
{
    public class PhoneSignupViewModel : IValidatableObject 
    {
        [StringLength(10), Required, Display(Name = "用户名")]
        public string Title { get; set; }

        [StringLength(255), Required, DataType(DataType.PhoneNumber), Display(Name = "手机号码")]
        public string PhoneNumber { get; set; }

        [StringLength(255), Required, Display(Name = "手机验证码")]
        public string MessageCode { get; set; }

        [StringLength(255), Required, DataType(DataType.Password), Display(Name = "密码")]
        public string Password { get; set; }

        [StringLength(255), Required, DataType(DataType.Password), Compare("Password"), Display(Name = "确认密码")]
        public string RepeatPassword { get; set; }

        public bool ReceiveNewsletter { get; set; }
        public bool AcceptTerms { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!AcceptTerms)
                yield return new ValidationResult("你必须接受条款");
        }

    }
}