using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubDeCarte.Models
{
    public class BookReview
    {
        public int BookReviewID { get; set; }

        [Display(Name = "Photo")]
        [Required(ErrorMessage = "Mandatory field")]
        public string ReviewPhoto { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(100, ErrorMessage = "String too long (max 100 chars")]
        [Display(Name = "Title")]
        public string TitleReview { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(100, ErrorMessage = "String too long (max 100 chars")]
        [Display(Name = "Author")]
        public string AuthorBookReviewed { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(5000, ErrorMessage = "String too long (max 5000 chars")]
        public string Description { get; set; }

        [Display(Name = "Added by")]
        public string AddedBy { get; set; }

        public DateTime AddedOn { get; set; }

        [StringLength(200, ErrorMessage = "String too long (max 200 chars")]
        public string Tags { get; set; }

        public BookReview()
        {
            AddedOn = DateTime.Now;
            AddedBy = System.Web.HttpContext.Current.User.Identity.Name;
        }

    }
}