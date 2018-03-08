using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aviator.Models
{
    public class Billing
    {
        [Key]
        public int InvoiceId { get; set; }

        [ForeignKey("MemberId")]
        public int PilotId { get; set; }
        public virtual Member MemberId { get; set; }

        [ForeignKey("FlightId")]
        public int FlightToBillId { get; set; }
        public virtual Flight FlightId { get; set; }

    }
}