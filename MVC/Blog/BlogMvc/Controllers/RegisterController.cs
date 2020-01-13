using BlogMvc.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMvc.Controllers
{
    public class RegisterController : Controller
    {
        IAuthenticationManager AuthManger => HttpContext.GetOwinContext().Authentication;
        ApplicationUserManager UserManger => HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Index(RegisterModel model)
        {

            // Default UserStore constructor uses the default connection string named: DefaultConnection
            var user = new ApplicationUser() { UserName = model.UserName, Email = model.UserName };
            IdentityResult result = UserManger.Create(user, model.Password);
            // Default UserStore constructor uses the default connection string named: DefaultConnection



            if (result.Succeeded)
            {
                ViewBag.StatusMessage = string.Format("User {0} was created successfully!", user.UserName);

                var userIdentity = UserManger.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                //AuthManger.SignIn(new AuthenticationProperties() { }, userIdentity);
                UserManger.SendEmailAsync(userIdentity.GetUserId(), "Confirmation", "");
                UserManger.SendSmsAsync(userIdentity.GetUserId(), "Confirmation");
                return View("Register");
            }
            else
            {
                ViewBag.StatusMessage = result.Errors.FirstOrDefault();
            }

            return View("Register");
        }
    }
}