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
    public class TagRepository : IRepository<Tag>
    {
        private BlogContext db;

        public TagRepository(BlogContext context)
        {
            this.db = context;
        }

        public IEnumerable<Tag> GetAll()
        {
            return db.Tags;
        }

        

        public Tag Get(int id)
        {
            return db.Tags.Include("Articles").First(t=>t.Id == id);
        }

        public void Create(Tag tag)
        {
            db.Tags.Add(tag);
        }


        public void Update(Tag item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Tag> GetAll(int id)
        {
            IEnumerable<Article> art = db.Articles.Include("Tags");
            Article fArt = art.First(t => t.Id == id);
            return fArt.Tags;
        }
    }
}
