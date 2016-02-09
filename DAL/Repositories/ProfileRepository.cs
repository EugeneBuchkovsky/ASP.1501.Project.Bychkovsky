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
    public class ProfileRepository : IRepository<Profile>
    {
        private BlogContext db;

        public ProfileRepository(BlogContext context)
        {
            this.db = context;
        }

        public IEnumerable<Profile> GetAll()
        {
            return db.Profiles;
        }

        public Profile Get(int id)
        {
            return db.Profiles.Find(id);
        }

        //public Profile GetByIserId(int id)
        //{
        //    return db.Profiles.First(p=>p.UserId==id);
        //}

        public void Create(Profile prof)
        {
            db.Profiles.Add(prof);
        }

        public void Update(Profile prof)
        {
            var uProfile = db.Profiles.FirstOrDefault(up => up.Id == prof.Id);
            uProfile.FirstName = prof.FirstName;
            uProfile.LastName = prof.LastName;
            uProfile.Age = prof.Age;
            db.Entry(uProfile).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Profile prof = db.Profiles.Find(id);
            if (prof != null)
                db.Profiles.Remove(prof);
        }

        public IEnumerable<Profile> GetAll(int id)
        {
            throw new NotImplementedException();
        }
    }
}
