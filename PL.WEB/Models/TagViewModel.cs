using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PL.WEB.Models
{
    public class TagViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Tag is too long!", MinimumLength = 0)]
        public string Name { get; set; }
    }
}