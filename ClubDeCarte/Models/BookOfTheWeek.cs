using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubDeCarte.Models
{
    public class BookOfTheWeek
    {
        public int BookOfTheWeekID { get; set; }
        public int BookID { get; set; }

        [Display(Name = "Valid From")]
        public DateTime ValidFrom { get; set; }

        [Display(Name = "Valid To")]
        public DateTime ValidTo { get; set; }
    }
}