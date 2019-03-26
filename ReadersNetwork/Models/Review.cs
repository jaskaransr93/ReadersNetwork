using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReadersNetwork.Models
{
    public class Review
    {
        [Key]
        [Column(Order = 2)]
        public string UserId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int BookId { get; set; }
        [Range(1,5)]
        public int Rating { get; set; }
        public string ReviewText { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
        public DateTime ReviewdOn { get; set; }
    }
}