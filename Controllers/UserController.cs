using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodePlayer.Models;

namespace CodePlayer.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult LogIn()
        {
            using (var db = new Models.PlayerContext())
            {
                // Create and save a new Blog 



                var user = new User();
                user.Email = "aa@gmail.com";
                user.Last = "AAA";
                user.Name = "TTT";
                user.Pass = "aaa";

                db.Users.Add(user);
                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.Users
                            orderby b.Name
                            select b;


                foreach (var item in query)
                {
                }

            }

            return View();
        }
    }
}