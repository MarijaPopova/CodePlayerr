namespace CodePlayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post
    {
        public int PostID { get; set; }

        public int UserID { get; set; }

        public string Name { get; set; }

        public string Html { get; set; }
        public string CSS { get; set; }
        public string JS { get; set; }
    }
}


