using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aviator.Models
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }
        

        [Display(Name = "Aircraft Tail Number")]
        public string AircraftNumber { get; set; }
        public string Destination{ get; set; }
        public string Date { get; set; }
    }
}