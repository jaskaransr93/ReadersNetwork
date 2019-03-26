using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReadersNetwork.Models
{
    public class User
    {
        [Key, Required, Display(Name = "Username")]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(60, MinimumLength = 6), Display(Name="Password")]
        public string Password { get; set; }

        [Required, Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required, Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Display(Name = "Cover Picture")]
        public string CoverPictureUrl { get; set; }

        public string Summary { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public ICollection<User> Followers { get; set; }
        public ICollection<User> Following { get; set; }

        public DateTime UserAdded { get; set; }

        public User()
        {


        }

        public User(string id, string password, string name, DateTime dob, Gender gender, string coverPictureUrl, string summary)
        {
            this.Id = id;
            this.Password = password;
            this.Name = name;
            this.DateOfBirth = dob;
            this.Gender = gender;
            this.CoverPictureUrl = coverPictureUrl;
            this.Summary = summary;
        }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}