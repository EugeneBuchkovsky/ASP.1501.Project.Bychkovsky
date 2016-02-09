using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime CreationDate { get; set; }

        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }

        public int? ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
