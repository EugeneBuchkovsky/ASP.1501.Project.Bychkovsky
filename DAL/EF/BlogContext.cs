using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.EF
{
    public class BlogContext : DbContext
    {
        static BlogContext()
        {
            Database.SetInitializer<BlogContext>(new StoreDbInitializer());
        }

        public BlogContext(string connectionString)
            : base(connectionString) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            context.Roles.Add(new Role { Name = "Administrator" });
            context.Roles.Add(new Role { Name = "User" });
            context.SaveChanges();

            context.Users.Add(new User { Email = "Zheniush@mail.ru", Password = "23032012", RoleId = 1  });
            context.Users.Add(new User { Email = "Lebedeva@gmail.com", Password = "03092015", RoleId = 2 });
            context.Users.Add(new User { Email = "Buchkovsky@gmail.com", Password = "29032007", RoleId = 2 });
            context.SaveChanges();

            context.Profiles.Add(new Profile { FirstName = "Eugene", LastName = "Bychkovsky",CreationDate = DateTime.Now, Age = 21, UserId = 1 });
            context.Profiles.Add(new Profile { FirstName = "Diana", LastName = "Lebedeva",CreationDate = DateTime.Now, Age = 20, UserId = 2 });
            context.Profiles.Add(new Profile { FirstName = "Maximilian", LastName = "Bychkovsky",CreationDate = DateTime.Now, Age = 8, UserId = 3 });
            context.SaveChanges();
        }
    }
}
