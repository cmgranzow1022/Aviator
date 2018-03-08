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
        public int? FlightIdentification { get; set; }
        public virtual Flight FlightId { get; set; }


        [Display(Name = "Starting Engine Hours")]
        public double StartingEngineHours { get; set; }
        [Display(Name = "Starting Total Hours")]
        public double StartingHobbsHours { get; set; }
        [Display(Name = "Oil Level")]
        public double StartingOilLevel { get; set; }
        [Display(Name = "Oil Added")]
        public double AmountOilAdded { get; set; }
        [Display(Name = "Maintenance Flight")]
        public bool MaintenanceFlight { get; set; }
    }
}