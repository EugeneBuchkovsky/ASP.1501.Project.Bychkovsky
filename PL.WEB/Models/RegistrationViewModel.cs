using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PL.WEB.Models
{
    public class RegistrationViewModel
    {
        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Empty field! Please, enter your email.")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Wrong email format! Please, enter again.")]
        public string Email { get; set; }

        [Display(Name = "Password:")]
        [Required(ErrorMessage = "Empty field! Please, enter your password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password, please:")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords not match!")]
        public string ConfirmPassword { get; set; }
    }
}