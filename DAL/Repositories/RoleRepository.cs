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
    public class RoleRepository : IRepository<Role>
    {
        private BlogContext db;

        public RoleRepository(BlogContext context)
        {
            this.db = context;
        }

        public IEnumerable<Role> GetAll()
        {
            return db.Roles;
        }

        public void Create(Role role)
        {
            db.Roles.Add(role);
        }

        public void Delete(int id)
        {
            Role role = db.Roles.Find(id);
            if (role != null)
                db.Roles.Remove(role);
        }

        public void Update(Role item)
        {
            throw new NotImplementedException();
        }

        public Role Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetAll(int id)
        {
            throw new NotImplementedException();
        }
    }
}
