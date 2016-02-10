using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PL.WEB.Models;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;
using PagedList;
using PagedList.Mvc;

namespace PL.WEB.Controllers
{
    public class ArticleController : Controller
    {
        IArticleService artService;
        IBlogService blogService;
        ICommentService commentService;
        ITagService tagService;
        IProfileService profileService;
        IUserService userService;
        public ArticleController(IArticleService ars, IBlogService bs, ICommentService cs, ITagService ts, IProfileService ps, IUserService us)
        {
            artService = ars;
            blogService = bs;
            commentService = cs;
            tagService = ts;
            profileService = ps;
            userService = us;
        }

        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var arts = Mapper.Map<IEnumerable<ArticleDTO>, List<ArticleViewModel>>(artService.GetArticles().OrderByDescending(a=>a.CreationDate));
            return View(arts.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Details(int id)
        {
            var article = Mapper.Map<ArticleDTO, ArticleViewModel>(artService.Article(id));
            ViewBag.Blog = Mapper.Map<BlogDTO, BlogViewModel>(blogService.GetBlog(article.BlogId));
            ViewBag.Tags = Mapper.Map<IEnumerable<TagDTO>, List<TagViewModel>>(tagService.GetTagsByArticleId(id));
            var Comments = Mapper.Map<IEnumerable<CommentDTO>, List<CommentViewModel>>(commentService.GetCommentsByArticleId(id));
            foreach (var c in Comments)
                c.profile = Mapper.Map<ProfileDTO, ProfileViewModel>(profileService.GetProfile(c.ProfileId));
            var profile = Mapper.Map<ProfileDTO, ProfileViewModel>(profileService.GetProfile(blogService.GetBlog(article.BlogId).ProfileId));
            ViewBag.user = Mapper.Map<UserDTO, UserViewModel>(userService.GetUser(profile.UserId));
            ViewBag.profile = profile;
            ViewBag.Comments = Comments;
            return View(article);
        }


        [Authorize]
        public ActionResult Create(int id)
        {
            ViewBag.BlogId = id;
            CreateArticleModel cam = new CreateArticleModel() { BlogId = id };
            return View(cam);
        }


        [HttpPost]
        public ActionResult Create(CreateArticleModel model)
        {
            try
            {
                var article = Mapper.Map<CreateArticleModel, ArticleDTO>(model);
                artService.Create(article);

                return RedirectToAction("ViewArticles", new {id=model.BlogId });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var article = Mapper.Map<ArticleDTO, ArticleViewModel>(artService.Article(id));
            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(ArticleViewModel model)
        {
            try
            {
                var updateArticle = Mapper.Map<ArticleViewModel, ArticleDTO>(model);
                artService.Update(updateArticle);
                return RedirectToAction("Details", new { id = updateArticle.Id });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            artService.Delete(id);
            return View("index");
        }

        public ActionResult ViewArticles(int id, int? page)
        {
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            var Blog = blogService.GetBlog(id);
            ViewBag.user = Mapper.Map<UserDTO, UserViewModel>(userService.GetUser(profileService.GetProfile(Blog.ProfileId).UserId));
            ViewBag.blog = Blog;
            var blogArticles = Mapper.Map<IEnumerable<ArticleDTO>, List<ArticleViewModel>>(artService.GetArticlesByBlogId(id).OrderByDescending(a=>a.CreationDate));
            return View(blogArticles.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult CreateComment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateComment(CommentViewModel model)
        {
            model.ProfileId = profileService.GetProfileByUserId(userService.GetUserByEmail(User.Identity.Name).Id).Id;
            var newModel = Mapper.Map<CommentViewModel, CommentDTO>(model);
            commentService.Create(newModel);
            return RedirectToAction("Details", new {id=newModel.ArticleId });
        }

        public ActionResult ViewComments(int id)
        {
            var comments = Mapper.Map<IEnumerable<CommentDTO>, List<CommentViewModel>>(commentService.GetCommentsByArticleId(id));
            foreach (var com in comments)
            {
                com.profile = Mapper.Map<ProfileDTO, ProfileViewModel>(profileService.GetProfile(com.ProfileId));
            }
            return View(comments);
        }
    }
}
