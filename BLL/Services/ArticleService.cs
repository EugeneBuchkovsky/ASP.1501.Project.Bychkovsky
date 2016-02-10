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
    public class ArticleService : IArticleService
    {
        IUnitOfWork Database { get; set; }
        public ArticleService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<ArticleDTO> GetArticles()
        {
            Mapper.CreateMap<Article, ArticleDTO>();
            var articles =  Mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(Database.Articles.GetAll());
            foreach (var a in articles)
                a.CommentsCount = Database.Comments.GetAll(a.Id).Count();
            return articles;
        }

        public IEnumerable<ArticleDTO> GetArticlesByBlogId(int? id)
        {
            if(id == null)
                throw new ValidationException("Blog with this ID not found!", "");
            Mapper.CreateMap<Article, ArticleDTO>();
            var articles = Mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(Database.Articles.GetAll((int)id));
            foreach (var a in articles)
                a.CommentsCount = Database.Comments.GetAll(a.Id).Count();
            return articles;
        }

        public ArticleDTO Article(int? id)
        {
            if(id == null)
                throw new ValidationException("Artile not foudn!", "");
            var art = Database.Articles.Get((int)id);
            if (art == null)
                throw new ValidationException("This Artile not found!", "");
            Mapper.CreateMap<Article, ArticleDTO>();
            return Mapper.Map<Article, ArticleDTO>(art);
        }

        public void Create(ArticleDTO article)
        {
            //<Tag> tags = TagModule.ReturnTags(article.Tags);

            string[] newTags = TagModule.ReturnTags(article.Tags);
            List<Tag> tags = new List<Tag>();
            if (newTags != null)
            {
                foreach (var t in newTags)
                {
                    var tagFromDB = Database.Tags.GetAll().FirstOrDefault(tag => tag.Name == t);
                    if (tagFromDB != null)
                        tags.Add(tagFromDB);
                    else
                    {
                        Tag newTag = new Tag { Name = t };
                        tags.Add(newTag);
                    }
                }
            }
            else
            {
                tags = null;
            }
            Article art = new Article
            {
                Title = article.Title,
                ArticleText = article.ArticleText,
                CreationDate = DateTime.Now,
                BlogId = article.BlogId,
                Tags = tags
            };
            Database.Articles.Create(art);
            Database.Save();
        }

        public void Update(ArticleDTO article)
        {
            Mapper.CreateMap<ArticleDTO, Article>();
            Article updateArt = Mapper.Map<ArticleDTO, Article>(article);
            Database.Articles.Update(updateArt);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Articles.Delete(id);
            Database.Save();
        }

        public IEnumerable<ArticleDTO> Search(string source)
        {
            List<ArticleDTO> result = new List<ArticleDTO>() ;
            Mapper.CreateMap<Article, ArticleDTO>();
            //foreach (var a in Mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(Database.Articles.GetAll()))
            //{
            //    if (a.ArticleText.Contains(source) || a.Title.Contains(source))
            //        result.Add(a);
            //}

            result = Mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(Database.Articles.GetAll().Where(a => a.ArticleText.Contains(source)));

            foreach (var a in result)
                a.CommentsCount = Database.Comments.GetAll(a.Id).Count();
            return result;
        }
    }
}
