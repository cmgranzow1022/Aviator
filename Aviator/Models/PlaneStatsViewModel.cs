using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aviator.Models
{
    public class PlaneStatsViewModel
    {
        public virtual Flight FlightModel { get; set; }
        public virtual PreFlight PreModel { get; set; }
        public virtual PostFlight PostModel { get; set; }
        public virtual Member MemberModel { get; set; }
    }
}