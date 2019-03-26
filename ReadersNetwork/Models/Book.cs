using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReadersNetwork.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        public string Description { get; set; }
        public string[] PhotoUrls { get; set; }
        public Genres Genres { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BookAdded { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }

    public enum Genres
    {
        Fantasy,
        Westerns,
        Romance,
        Thriller,
        Mystery,
        Erotica,
        DetectiveStory,
        Dystopia,
        Biographgy,
        Journalism,
        Textbook
    }
}