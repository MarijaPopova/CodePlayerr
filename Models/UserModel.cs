namespace CodePlayer.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;

    public partial class UserModel : DbContext
    {
        public UserModel()
            : base("name=UserModel")
        {
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public Post getPost(int intId) {
 
            foreach (Post s in Posts)
            {
                if (s.PostID == intId)
                {
                    return s;
                }
               
            }
            return null;
        }
        public List<Post> getPostsByUserId(int id) {
            List<Post> post = new List<Post>();
            foreach (Post s in Posts) {
                if (s.UserID == id) {
                    post.Add(s);
                }
            }

            return post;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
