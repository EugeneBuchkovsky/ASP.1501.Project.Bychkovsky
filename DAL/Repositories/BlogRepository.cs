using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using DAL.EF;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class BlogRepository : IRepository<Blog>
    {
        private BlogContext db;

        public BlogRepository(BlogContext context)
        {
            this.db = context;
        }

        public IEnumerable<Blog> GetAll()
        {
            return db.Blogs;
        }

        public IEnumerable<Blog> GetAll(int id)
        {
            return db.Blogs.Where(b=>b.ProfileId==id);
        }

        public Blog Get(int id)
        {
            return db.Blogs.Find(id);
        }

        public void Create(Blog blog)
        {
            db.Blogs.Add(blog);
        }

        public void Update(Blog blog)
        {
            var uBlog = db.Blogs.FirstOrDefault(b => b.Id == blog.Id);
            uBlog.Title = blog.Title;
            db.Entry(uBlog).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog != null)
                db.Blogs.Remove(blog);
        }
    }
}
