using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aviator.Models
{
    public class PreFlightViewModel
    {
        public virtual Flight FlightModel { get; set; }
        public virtual PreFlight PreFlightModel { get; set; }
    }
}