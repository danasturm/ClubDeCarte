using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubDeCarte.Models
{
    public class Event
    {
        public int EventID { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(5000, ErrorMessage = "String too long (max 5000 chars")]
        [Display(Name = "Event Description")]
        public string EventDescription { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max 250 chars")]
        [Display(Name = "Event Location")]
        public string EventLocation { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [Display(Name = "Event Day")]
        public DateTime EventDay { get; set; }

        [Display(Name = "Added By")]
        public string AddedBy { get; set; }

        //public string Hour { get; set; }

        public Event()
        {
            //AddedBy = User.Identity.Name;
        }
    }
}