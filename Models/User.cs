namespace CodePlayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
   

    public partial class User
    {
        [Required]
        public int UserID { get; set; }
        [Display(Name="Username: ")]
        [Required(ErrorMessage = "Please enter a username")]
        public string Name { get; set; }
        [Display(Name="First and Last name")]
        public string Last { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Please enter an E-mail address")]
        [Display(Name = "E-Mail: ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please supply you password")]
        [DataType(DataType.Password)]
        [StringLength(20,MinimumLength=4)]
        [Display(Name = "Password: ")]
        public string Pass { get; set; }
       
    }
}
