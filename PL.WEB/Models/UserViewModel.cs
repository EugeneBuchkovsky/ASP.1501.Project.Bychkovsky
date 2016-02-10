using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PL.WEB.Models
{
    public class UserViewModel
    {
        [Display(Name = "Login:")]
        public string Email { get; set; }

        [Display(Name = "Password:")]
        public string Password { get; set; }
    }
}