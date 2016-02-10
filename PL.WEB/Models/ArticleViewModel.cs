using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PL.WEB.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The title more than 100 characters", MinimumLength = 0)]
        public string Title { get; set; }

        [Required]
        public string ArticleText { get; set; }

        [Display(Name = "Creation date:")]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int BlogId { get; set; }

        [Display(Name = "Comments:")]
        public int CommentsCount { get; set; }
    }
}