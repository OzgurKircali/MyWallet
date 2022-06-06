using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using MyWalletProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete.Identity;
using DataAccessLayer.Concrete;

namespace MyWalletProject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private UserManager<AspNetUser> UserManager;
        public string UsernameHolder;


        public AccountController()
        {
            UserManager = new UserManager<AspNetUser>(new UserStore<AspNetUser>(new Context()));

            UserManager.PasswordValidator = new PasswordValidator()
            {
                RequireDigit = true,
                RequiredLength = 8,
                RequireLowercase=true,
                RequireUppercase=true
            };

            UserManager.UserValidator = new UserValidator<AspNetUser>(UserManager)
            {
                RequireUniqueEmail=true,
                
            };
        }

      

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                

                var user = UserManager.Find(model.Username, model.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Yanlış kullanıcı adı veya parola");
                }
                else
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                   
                    var identity = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties()
                    {
                        IsPersistent = true
                    };
                    authManager.SignOut();
                    authManager.SignIn(authProperties, identity);

                    Session["usernameSession"] = model.Username;
                    Session["idSession"] = user.Id;
                    

                    return Redirect(string.IsNullOrEmpty(returnUrl) ? "/":returnUrl);

                }
            }
            
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                if (model.PasswordControl == model.Password)
                {
                    var user = new AspNetUser();
                    user.UserName = model.Username;
                    user.Email = model.Email;

                    var result = UserManager.Create(user, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error);
                        }
                    }
                }
            }


            return View(model);
        }


        public ActionResult Logout()
        {
            

            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Login");
        }

        public ActionResult RegisterButton()
        {
            return RedirectToAction("Register");
        } 
    }
}