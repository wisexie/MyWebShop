﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebShop.ViewModels
{
    public class SignupViewModel : IValidatableObject 
    {
        [StringLength(10), Display(Name = "Title")]
        public string Title { get; set; }

        [StringLength(50), Required, Display(Name = "Firstname")]
        public string FirstName { get; set; }

        [StringLength(50), Required, Display(Name = "Lastname")]
        public string LastName { get; set; }

        [StringLength(255), Required, DataType(DataType.EmailAddress), Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(255), Required, DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }

        [StringLength(255), Required, DataType(DataType.Password), Compare("Password"), Display(Name = "Repeat password")]
        public string RepeatPassword { get; set; }

        public bool ReceiveNewsletter { get; set; }
        public bool AcceptTerms { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!AcceptTerms)
                yield return new ValidationResult("You need to accept our terms and conditions in order to make use of our services");
        }

    }
}