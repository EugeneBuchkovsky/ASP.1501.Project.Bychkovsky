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
    public class CommentService : ICommentService
    {
        IUnitOfWork Database { get; set; }
        public CommentService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<CommentDTO> GetCommentsByArticleId(int? id)
        {
            if(id == null)
                throw new ValidationException("Article not found!", "");
            Mapper.CreateMap<Comment, CommentDTO>();
            return Mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(Database.Comments.GetAll(((int)id)));
        }

        public void Create(CommentDTO comment)
        {
            Comment com = new Comment
            {
                Text = comment.Text,
                CreationDate = DateTime.Now,
                ArticleId = comment.ArticleId,
                ProfileId = comment.ProfileId
            };
            Database.Comments.Create(com);
            Database.Save();
        }

        public void Update(CommentDTO comment)
        {
            Mapper.CreateMap<CommentDTO, Comment>();
            Comment updateComment = Mapper.Map<CommentDTO, Comment>(comment);
            Database.Comments.Update(updateComment);
        }

        public void Delete(int id)
        {
            Database.Comments.Delete(id);
        }
    }
}
