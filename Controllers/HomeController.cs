using CodePlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CodePlayer.Controllers
{
    public class HomeController : Controller
    {
        private UserModel md = new UserModel();
        // GET: Index
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                HttpCookie cookie = Request.Cookies.Get(FormsAuthentication.FormsCookieName);
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                var userName = ticket.Name;
                var user = md.Users.FirstOrDefault(x => x.Name == userName);
                List<Post> posts = md.getPostsByUserId(user.UserID);
                if (posts == null) return View();
                return View(posts);

            }
            return View();
        }
        [HttpGet]
        public ActionResult Open(int idP) {
          
            Post post = md.getPost(idP);
              
            if (post == null)
                return View();
           else  return View(post);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SavePost(PostModel model)
        {
            try
            {
                using (var context = new UserModel())
                {
                    var post = new Post();
                    post.CSS = model.CSS;
                    post.Html = model.Html;
                    post.Name = model.Name;
                    post.JS = model.JS;

                    //Se zema user od avtentikacisko Cookie
                    HttpCookie cookie = Request.Cookies.Get(FormsAuthentication.FormsCookieName);
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                    var userName = ticket.Name;

                    var user = context.Users.FirstOrDefault(x => x.Name == userName);
                    post.UserID = user.UserID;

                    context.Posts.Add(post);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return null;
        }

    }
}