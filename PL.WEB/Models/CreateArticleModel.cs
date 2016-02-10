using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PL.WEB.Models
{
    public class CreateArticleModel
    {
        [Display(Name = "Article title")]
        [Required]
        [StringLength(100, ErrorMessage = "The title more than 100 characters", MinimumLength = 0)]
        public string Title { get; set; }

        [Display(Name = "Article text")]
        [Required]
        public string ArticleText { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int BlogId { get; set; }

        [Display(Name = "Tag list")]
        public string Tags { get; set; }
    }
}