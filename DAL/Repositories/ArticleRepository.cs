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
    public class ArticleRepository : IRepository<Article>
    {
        private BlogContext db;

        public ArticleRepository(BlogContext context)
        {
            this.db = context;
        }

        public IEnumerable<Article> GetAll()
        {
            return db.Articles;
        }

        public IEnumerable<Article> GetAll(int id)
        {
            return db.Articles.Where(a=>a.BlogId==id);
        }

        public Article Get(int id)
        {
            return db.Articles.Find(id);
        }

        public void Create(Article art)
        {
            db.Articles.Add(art);
        }

        public void Update(Article art)
        {
            var uArticle = db.Articles.FirstOrDefault(a => a.Id == art.Id);
            uArticle.Title = art.Title;
            uArticle.ArticleText = art.ArticleText;
            db.Entry(uArticle).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Article art = db.Articles.Find(id);
            if (art != null)
                db.Articles.Remove(art);
        }

        public IEnumerable<Article> GetArticles(int id)
        {
            IEnumerable<Tag> tags = db.Tags.Include("Articles");
            Tag fTag = tags.First(t => t.Id == id);
            return fTag.Articles;
        }
    }
}
