using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aviator.Models;
using System.Web.Mvc;

namespace Aviator.Models
{
    public class PostFlightViewModel
    {    
        public virtual PostFlight postModel { get; set; }
        public List<SelectListItem> AvailablePilots { get; set; }
        public PostFlightViewModel()
        {
            AvailablePilots = new List<SelectListItem>();
            postModel = new PostFlight();
        }

    }


}
