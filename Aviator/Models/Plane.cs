using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aviator.Models
{
    public class Plane
    {
        [Key]
        public int PlaneId { get; set; }
        public string TailNumber { get; set; }
        public double TotalEngineHours { get; set; }
        public double TotalHobbsHours { get; set; }
    }
}