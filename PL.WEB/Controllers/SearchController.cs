using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using PL.WEB.Models;
using AutoMapper;

namespace PL.WEB.Controllers
{
    public class SearchController : Controller
    {
        ITagService tagService;
        IArticleService articleService;

        public SearchController(ITagService ts, IArticleService arts)
        {
            tagService = ts;
            articleService = arts;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ByTag(string tagName)
        {
            string name = Request.Params["tagName"];
            var tag = Mapper.Map<TagDTO, TagViewModel>(tagService.GetTags().FirstOrDefault(t => t.Name == name));
            var searchResults = Mapper.Map<IEnumerable<ArticleDTO>, List<ArticleViewModel>>(tagService.GetArticlesByTag((int)tag.Id));
            @ViewBag.tag = tag;
            return View(searchResults);
        }


        public ActionResult ViewSearch()
        {
            return View();
        }
        public ActionResult Search(string name)
        {
            var artciles = Mapper.Map<IEnumerable<ArticleDTO>, List<ArticleViewModel>>(articleService.Search(name));
            if (artciles == null)
                return HttpNotFound();
            return View(artciles);
        }
    }
}
