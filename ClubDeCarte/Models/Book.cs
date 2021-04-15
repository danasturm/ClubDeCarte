using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubDeCarte.Models
{
    public class Book
    {
        public int BookID { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max 250 chars")]
        public string Title { get; set; }

        public int AuthorID { get; set; }


        [StringLength(100, ErrorMessage = "String too long (max 100 chars")]
        [Display(Name = "Other Authors")]
        public string OtherAuthors { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(100, ErrorMessage = "String too long (max 100 chars")]
        [Display(Name = "Publishing House")]
        public string PublishingHouse { get; set; }

        [StringLength(50, ErrorMessage = "String too long (max 50 chars")]
        public string ISBN { get; set; }

        public int? Pages { get; set; }

        [Display(Name = "Photo Cover")]
        public string UrlPhotoCover { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
        public virtual Author BookAuthor { get; set; }
    }
}