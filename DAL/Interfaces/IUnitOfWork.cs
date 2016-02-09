using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Role> Roles { get; }
        IRepository<User> Users{ get; }
        IRepository<Profile> Profiles{ get; }
        IRepository<Blog> Blogs{ get; }
        IRepository<Article> Articles{ get; }
        IRepository<Comment> Comments{ get; }
        IRepository<Tag> Tags { get; }
        void Save();
    }
}
