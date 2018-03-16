using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aviator.Models
{
    public class TotalHoursViewModel
    {
       public PreFlight PreFlight { get; set; }
       public PostFlight PostFlight { get; set; }
       public Invoice Invoice { get; set; }
       public List<Member> ListOfPilots { get; set; }
       

        public TotalHoursViewModel()
        {
            ListOfPilots = new List<Member>();
        }
    }
}