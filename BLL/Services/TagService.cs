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
    public class TagService : ITagService
    {
        IUnitOfWork Database { get; set; }
        public TagService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<TagDTO> GetTags()
        {
            Mapper.CreateMap<Tag, TagDTO>();
            return Mapper.Map<IEnumerable<Tag>, List<TagDTO>>(Database.Tags.GetAll());
        }

        public IEnumerable<TagDTO> GetTagsByArticleId(int? id)
        {
            if(id == null)
                throw new ValidationException("Article not found!", "");
            Mapper.CreateMap<Tag, TagDTO>();
            return Mapper.Map<IEnumerable<Tag>, List<TagDTO>>(Database.Tags.GetAll((int)id));
        }

        public TagDTO GetTag(int? id)
        {
            if (id == null)
                throw new ValidationException("This ID null!", "");
            var tag = Database.Tags.Get((int)id);
            if (tag == null)
                throw new ValidationException("This tag not found!", "");
            Mapper.CreateMap<Tag, TagDTO>();
            return Mapper.Map<Tag, TagDTO>(tag);
        }

        public IEnumerable<ArticleDTO> GetArticlesByTag(int? id)
        {
            if (id == null)
                throw new ValidationException("This ID null!", "");
            var tag = Database.Tags.Get((int)id);
            if (tag == null)
                throw new ValidationException("This tag not found!", "");
            Mapper.CreateMap<Article, ArticleDTO>();
            var articles = Mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(tag.Articles);
            foreach (var a in articles)
                a.CommentsCount = Database.Comments.GetAll(a.Id).Count();
            return articles;
        }

        public void Create(TagDTO tag)
        {
            Tag newTag = new Tag
            {
                Name = tag.Name
            };
            Database.Tags.Create(newTag);
            Database.Save();
        }

        public void Update(TagDTO tag)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
