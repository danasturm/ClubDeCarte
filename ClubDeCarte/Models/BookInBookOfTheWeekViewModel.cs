using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubDeCarte.Models
{
    public class BookInBookOfTheWeekViewModel
    {
        public int BookInBookOfTheWeekViewModelID { get; set; }
        public int BookOfTheWeekID { get; set; }
        public int BookID { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max 250 chars")]
        public string Title { get; set; }

        [Display(Name = "Photo Cover")]
        public string UrlPhotoCover { get; set; }

        public string Description { get; set; }

        [Display(Name = "Valid From")]
        public DateTime ValidFrom { get; set; }

        [Display(Name = "Valid To")]
        public DateTime ValidTo { get; set; }
    }
}