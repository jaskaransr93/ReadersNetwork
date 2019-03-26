using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReadersNetwork.Models
{
    public class Question
    {
        [Key]
        [Column(Order = 1)]
        public int QuesId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int BookId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
        public DateTime Added { get; set; }
    }
}