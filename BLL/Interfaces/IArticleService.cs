using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IArticleService
    {
        IEnumerable<ArticleDTO> GetArticles();
        IEnumerable<ArticleDTO> GetArticlesByBlogId(int? id);
        ArticleDTO Article(int? id);
        void Create(ArticleDTO article);
        void Update(ArticleDTO article);
        void Delete(int id);
        IEnumerable<ArticleDTO> Search(string source);
    }
}
