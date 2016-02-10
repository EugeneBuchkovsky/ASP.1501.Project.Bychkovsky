using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ITagService
    {
        IEnumerable<TagDTO> GetTags();
        IEnumerable<TagDTO> GetTagsByArticleId(int? id);
        TagDTO GetTag(int? id);
        IEnumerable<ArticleDTO> GetArticlesByTag(int? id);
        void Create(TagDTO tag);
        void Update(TagDTO tag);
        void Delete(int id);
    }
}
