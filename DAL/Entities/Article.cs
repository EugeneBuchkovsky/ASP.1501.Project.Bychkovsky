using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ArticleText { get; set; }

        public DateTime CreationDate { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public Article()
        {
            Comments = new List<Comment>();
            Tags = new List<Tag>();
        }
    }
}
