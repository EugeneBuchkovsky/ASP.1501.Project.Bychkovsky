using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

        public ICollection<Article> Articles { get; set; }
        public Blog()
        {
            Articles = new List<Article>();
        }
    }
}
