using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CodePlayer.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Models.User user, string submit)
        {
            switch (submit)
            {
                case "Login":
                    if(!ModelState.IsValid)
                    {
                        if(isValid(user.Name,user.Pass))
                        {
                            FormsAuthentication.SetAuthCookie(user.Name, false);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Wrong Password!");
                    }
                    break;

                case "Register":
                    Register(user);
                    break;
            }
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            HttpCookie c = Request.Cookies[FormsAuthentication.FormsCookieName];
            c.Expires = DateTime.Now.AddDays(-1);
            Session.Abandon();
            Session.Clear();
            // Update the amended cookie!
            Response.Cookies.Set(c);

            return RedirectToAction("LogIn", "Account");
        }

        public void Register(Models.User registrant)
        {
            if(ModelState.IsValid)
            {
                using (var db = new Models.UserModel())
                {
                    var RegUser = db.Users.Create();
                    RegUser.Name = registrant.Name;
                    RegUser.Pass = registrant.Pass;
                    RegUser.Email = registrant.Email;
                    RegUser.Last = registrant.Last;
                    db.Users.Add(RegUser);
                    db.SaveChanges();
                  
                }
            }

            else
            {
                ModelState.AddModelError("","Incorrect data usage!");
            }
        }


        bool isValid(string User, string Pass)
        {
            bool validity = false;

            using (var db = new Models.UserModel())
            {
                var user = db.Users.FirstOrDefault(u => u.Name == User);

                if(user != null)
                {
                    if(user.Pass == Pass)
                    {
                        validity = true;
                    }
                }
            }

            return validity;
        }

    }
}