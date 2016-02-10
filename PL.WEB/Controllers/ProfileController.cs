using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.DTO;
using BLL.Interfaces;
using PL.WEB.Models;
using AutoMapper;

namespace PL.WEB.Controllers
{
    public class ProfileController : Controller
    {
        IProfileService profileService;
        IUserService userService;
        IBlogService blogService;
        IArticleService artService;

        public ProfileController(IProfileService ps, IUserService us, IBlogService bs, IArticleService arts)
        {
            this.profileService = ps;
            this.userService = us;
            this.blogService = bs;
            this.artService = arts;
        }
        

        [HttpGet]
        [Authorize]
        public ActionResult ViewProfile(int? id)
        {
            if (id == null)
            {
                id = profileService.GetProfileByUserId(userService.GetUserByEmail(User.Identity.Name).Id).Id;
            }
            var requiredProfile = Mapper.Map<ProfileDTO, ProfileViewModel>(profileService.GetProfile(id));
            ViewBag.UserProfile = Mapper.Map<UserDTO, UserViewModel>(userService.GetUser(requiredProfile.UserId));
            ViewBag.NomberOfBlogs = blogService.GetBlogs().Where(b => b.ProfileId == id).Count();
            return View(requiredProfile);
        }

        [HttpGet]
        public ActionResult UpdateProfile()
        {
            var profile = Mapper.Map<ProfileDTO, ProfileViewModel>(profileService.GetProfileByUserId(userService.GetUserByEmail(User.Identity.Name).Id));
            return View(profile);
        }

        [HttpPost]
        public ActionResult UpdateProfile(ProfileViewModel uProfile)
        {
            var updateProfile = Mapper.Map<ProfileViewModel, ProfileDTO>(uProfile);
            profileService.Update(updateProfile);
            return RedirectToAction("ViewProfile/4");
        }

        [HttpGet]
        public ActionResult ViewBlogs(int? Id)
        {
            try
            {
                if (Id == null)
                {
                    Id = profileService.GetProfileByUserId(userService.GetUserByEmail(User.Identity.Name).Id).Id;
                }
                var userBlogs = Mapper.Map<IEnumerable<BlogDTO>, List<BlogViewModel>>(blogService.GetBlogsByProfileId(Id));
                var profile = Mapper.Map<BLL.DTO.ProfileDTO, ProfileViewModel>(profileService.GetProfile(Id));
                ViewBag.user = Mapper.Map<UserDTO, UserViewModel>(userService.GetUser(profile.UserId));
                ViewBag.profile = profile;
                return View(userBlogs);
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBlog(BlogViewModel model)
        {
            try
            {
                var profileId = profileService.GetProfileByUserId(userService.GetUserByEmail(User.Identity.Name).Id).Id;
                var blog = Mapper.Map<BlogViewModel, BlogDTO>(model);
                blog.ProfileId = profileId;
                blogService.Create(blog);
                // TODO: Add insert logic here

                return RedirectToAction("ViewBlogs", new {id = profileId });
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            try
            {
                var blog = Mapper.Map<BlogDTO, BlogViewModel>(blogService.GetBlog(id));
                return View(blog);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult UpdateBlog(BlogViewModel updateBlogModel)
        {
            var updateBlog = Mapper.Map<BlogViewModel, BlogDTO>(updateBlogModel);
            blogService.Update(updateBlog);
            return RedirectToAction("ViewBlogs");
        }

        [Authorize]
        [HttpGet]
        public ActionResult DeleteBlog(int id)
        {
            blogService.Delete(id);
            var profileId = profileService.GetProfileByUserId(userService.GetUserByEmail(User.Identity.Name).Id).Id;
            return RedirectToAction("ViewBlogs", new { id = profileId });
        }
    }
}
