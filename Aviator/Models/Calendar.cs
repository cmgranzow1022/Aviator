using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aviator.Models
{
    public class Calendar
    {
        [Key]
        public int EventId { get; set; }
        
        [ForeignKey ("MemberId")]
        public int MemberMakingReservation { get; set; }
        public virtual Member MemberId { get; set; }
        [Display(Name = "Event Description")]
        public string EventDescription { get; set;}
        [Display(Name ="Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }
        [Display(Name = "End Date/Time")]
        public DateTime EndDate { get; set; }
        [Display(Name = "End Time")]
        public string EndTime { get; set; }
        public string color { get; set; }
    }
}