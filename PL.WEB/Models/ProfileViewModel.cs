using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PL.WEB.Models
{
    public class ProfileViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name:")]
        [Required(ErrorMessage = "Please, enter your name.")]
        public string FirstName { get; set; }

        [Display(Name = "Surname:")]
        public string LastName { get; set; }

        [Display(Name = "Age:")]
        public int Age { get; set; }

        [Display(Name = "Creation date:")]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int UserId { get; set; }
    }
}