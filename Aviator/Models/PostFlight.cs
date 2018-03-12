using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aviator.Models
{
    public class PostFlight
    {
        [Key]
        public int PostFlightId { get; set; }

        [ForeignKey("FlightId")]
        public int FlightIdentification { get; set; }
        public virtual Flight FlightId { get; set; }

        [Display(Name = "Ending Engine Hours")]
        public double EndingEngineHours { get; set; }
        [Display(Name = "Ending Total Hours")]
        public double EndingHobbsHours { get; set; }
        public string Squawks { get; set; }
        [Display(Name = "Split Time")]
        public bool SplitTime { get; set; }

        [ForeignKey("MemberId")]
        [Display(Name = "Pilot Splitting Time With")]
        public int? SplitTimePilotId { get; set; }
        public virtual Member MemberId { get; set; }
    }
}