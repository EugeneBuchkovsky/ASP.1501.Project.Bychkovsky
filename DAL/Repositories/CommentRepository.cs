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
    public class CommentRepository : IRepository<Comment>
    {
        private BlogContext db;

        public CommentRepository(BlogContext context)
        {
            this.db = context;
        }

        public IEnumerable<Comment> GetAll(int id)
        {
            return db.Comments.Where(c=>c.ArticleId==id);
        }

        public void Create(Comment comment)
        {
            db.Comments.Add(comment);
        }

        public void Update(Comment comment)
        {
            db.Entry(comment).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment != null)
                db.Comments.Remove(comment);
        }

        public IEnumerable<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Comment Get(int id)
        {
            return db.Comments.Find(id);
        }
    }
}
