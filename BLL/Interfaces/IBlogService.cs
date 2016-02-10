using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;


namespace BLL.Interfaces
{
    public interface IBlogService
    {
        IEnumerable<BlogDTO> GetBlogs();
        IEnumerable<BlogDTO> GetBlogsByProfileId(int? id);
        List<string> GetProfilesNames(IEnumerable<BlogDTO> blogs);
        BlogDTO GetBlog(int? id);
        void Create(BlogDTO blog);
        void Update(BlogDTO blog);
        void Delete(int id);
    }
}
