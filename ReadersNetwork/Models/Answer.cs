using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReadersNetwork.Models
{
    public class Answer
    {
        [Key]
        [Column(Order=1)]
        public int QuesId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string UserId { get; set; }
        public string Text { get; set; }

        public virtual Question Question { get; set; }
        public virtual User User { get; set; }
        public DateTime AnsweredOn { get; set; }

    }
}