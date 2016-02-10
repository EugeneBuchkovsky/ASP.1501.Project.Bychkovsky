using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ArticleDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ArticleText { get; set; }

        public DateTime CreationDate { get; set; }

        public int BlogId { get; set; }

        public string Tags { get; set; }

        public int CommentsCount { get; set; }
    }
}
