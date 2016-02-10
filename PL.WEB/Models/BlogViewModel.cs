using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PL.WEB.Models
{
    public class BlogViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ProfileId { get; set; }
    }
}