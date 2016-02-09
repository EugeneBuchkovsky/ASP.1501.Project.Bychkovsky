using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private BlogContext db;

        private RoleRepository roleRepository;
        private UserRepository userRepository;
        private ProfileRepository profileRepository;
        private BlogRepository blogRepository;
        private ArticleRepository articleRepository;
        private CommentRepository commentRepository;
        private TagRepository tagRepository;

        private bool disposed = false;

        public EFUnitOfWork(string connectionString)
        {
            db = new BlogContext(connectionString);
        }

        public IRepository<Role> Roles
        {
           get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(db);
                return roleRepository;
            } 
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<Profile> Profiles
        {
            get
            {
                if (profileRepository == null)
                    profileRepository = new ProfileRepository(db);
                return profileRepository;
            }
        }

        public IRepository<Blog> Blogs
        {
            get
            {
                if (blogRepository == null)
                    blogRepository = new BlogRepository(db);
                return blogRepository;
            }
        }

        public IRepository<Article> Articles
        {
            get
            {
                if (articleRepository == null)
                    articleRepository = new ArticleRepository(db);
                return articleRepository;
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository(db);
                return commentRepository;
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                if (tagRepository == null)
                    tagRepository = new TagRepository(db);
                return tagRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
