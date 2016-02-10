using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using PL.WEB.Models;
using AutoMapper;

namespace PL.WEB.Controllers
{
    public class HomeController : Controller
    {
        IUserService userService;
        IProfileService profileService;
        public HomeController(IUserService us, IProfileService ps)
        {
            userService = us;
            profileService = ps;
        }

        //
        // GET: /Home/

        [Authorize(Roles = "Administrator")]
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var email = User.Identity.Name;
            ViewBag.TimePro = email;
            Mapper.CreateMap<UserDTO, UserViewModel>();
            var users = Mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userService.GetUsers());
            var profiles = Mapper.Map<IEnumerable<ProfileDTO>, List<ProfileViewModel>>(profileService.GetProfiles()).OrderByDescending(p => p.CreationDate);
            return View(profiles);
        }
    }
}
