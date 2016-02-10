using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PL.WEB.Models
{
    public class CommentViewModel
    {
        [Required]
        public string Text { get; set; }

        [Display(Name = "Creation date:")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ArticleId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ProfileId { get; set; }

        [Display(Name ="User")]
        public ProfileViewModel profile { get; set; }
    }
}