using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubDeCarte.Models
{
    public class BookAuthorViewModel
    {
        public int BookAuthorViewModelID {get; set;}
        public int BookID { get; set; }

        public int AuthorID { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public string UrlPhotoCover { get; set; }
       
        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(100, ErrorMessage = "String too long (max 100 chars")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(100, ErrorMessage = "String too long (max 100 chars")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max 250 chars")]
        public string Title { get; set; }

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

    
    }
}