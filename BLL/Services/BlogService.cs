using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.DTO;
using BLL.Infrastructure;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using AutoMapper;


namespace BLL.Services
{
    public class BlogService : IBlogService
    {
        IUnitOfWork Database { get; set; }
        public BlogService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<BlogDTO> GetBlogs()
        {
            Mapper.CreateMap<Blog, BlogDTO>();
            return Mapper.Map<IEnumerable<Blog>, List<BlogDTO>>(Database.Blogs.GetAll());
        }

        public IEnumerable<BlogDTO> GetBlogsByProfileId(int? id)
        {
            if(id == null)
                throw new ValidationException("This ID null!", "");
            Mapper.CreateMap<Blog, BlogDTO>();
            return Mapper.Map<IEnumerable<Blog>, List<BlogDTO>>(Database.Blogs.GetAll((int)id));
        }

        public List<string> GetProfilesNames(IEnumerable<BlogDTO> blogs)
        {
            List<string> result = new List<string>();
            var profiles = Database.Profiles.GetAll();
            foreach (var b in blogs)
            {
                var prof = profiles.FirstOrDefault(p => p.Id == b.ProfileId);
                result.Add(prof.FirstName + " " + prof.LastName);
            }
            return result;
        }

        public BlogDTO GetBlog(int? id)
        {
            if (id == null)
                throw new ValidationException("This ID null!", "");
            var blog = Database.Blogs.Get((int)id);
            if (blog == null)
                throw new ValidationException("This blog not found!", "");
            Mapper.CreateMap<Blog, BlogDTO>();
            return Mapper.Map<Blog, BlogDTO>(blog);
        }

        public void Create(BlogDTO blog)
        {
            Blog newBlog = new Blog
            {
                Title = blog.Title,
                ProfileId = blog.ProfileId
            };
            Database.Blogs.Create(newBlog);
            Database.Save();
        }

        public void Update(BlogDTO blog)
        {
            Mapper.CreateMap<BlogDTO, Blog>();
            Blog updateBlog = Mapper.Map<BlogDTO, Blog>(blog);
            Database.Blogs.Update(updateBlog);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Blogs.Delete(id);
            Database.Save();
        }
    }
}
