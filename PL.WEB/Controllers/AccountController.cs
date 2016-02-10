using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfaces;
using PL.WEB.Models;
using PL.WEB.Providers;

namespace PL.WEB.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;
        public AccountController(IUserService us)
        {
            userService = us;
        }
        //
        // GET: /Account/

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel viewModel)
        {
            var AllEmails = userService.GetUsers().Any(u=>u.Email == viewModel.Email);

            if (AllEmails)
            {
                ModelState.AddModelError("", "User with this password has already been registered! ");
                return View(viewModel);
            }

            if (ModelState.IsValid)
            {
                var membershipUser = ((NewMembershipProvider)Membership.Provider).CreateUser(viewModel.Email, viewModel.Password);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, false);
                    return RedirectToAction("ViewProfile", "Profile");
                }
                else
                {
                    ModelState.AddModelError("","Error registration!");
                }
            }
            return View(viewModel);
        }

        [AllowAnonymous]
        public ActionResult Login(string returlUrl)
        {
            var type = HttpContext.User.GetType();
            var inen = HttpContext.User.Identity.GetType();
            ViewBag.ReturnUrl = returlUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LogViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Email, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    return RedirectToAction("ViewProfile", "Profile");
                }
                else
                {
                    ModelState.AddModelError("","Incorrect password or login!\n Try again");
                }                
            }
            return View(model);
        }

        [Authorize]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login","Account");
        }
    
    }
}
