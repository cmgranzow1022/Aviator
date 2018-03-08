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
        public int Flight { get; set; }
        public virtual Flight FlightId { get; set; }

        public double EndingEngineHours { get; set; }
        public double EndingHobbsHours { get; set; }
        public string Squawks { get; set; }
        public bool SplitTime { get; set; }
    }
}