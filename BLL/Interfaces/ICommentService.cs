using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<CommentDTO> GetCommentsByArticleId(int? id);
        void Create(CommentDTO comment);
        void Update(CommentDTO comment);
        void Delete(int id);
    }
}
