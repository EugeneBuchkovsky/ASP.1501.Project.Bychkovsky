using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Profile
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public DateTime CreationDate { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Blog> Blogs { get; set; }

        public Profile()
        {
            Blogs = new List<Blog>();
        }
    }
}
