using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReadersNetwork.Models
{
    public class Post
    {
        public string UserId { get; set; }
        [Key]
        public int PostId { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime PostedTime { get; set; }
        public virtual User User { get; set; }
    }
}