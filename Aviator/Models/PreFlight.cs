using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aviator.Models
{
    public class PreFlight
    {
        [Key]
        public int PreFlightId { get; set; }

        [ForeignKey("FlightId")]
        public int Flight { get; set; }
        public virtual Flight FlightId { get; set; }

        public double StartngEngineHours { get; set; }
        public double StartingHobbsHours { get; set; }
        public double StartingOilLevel { get; set; }
        public double AmountOilAdded { get; set; }
        public bool MaintenanceFlight { get; set; }
    }
}