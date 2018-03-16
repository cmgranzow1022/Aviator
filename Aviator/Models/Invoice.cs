using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aviator.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceKey { get; set; }
        [Display(Name = "Member")]
        [ForeignKey("MemberId")]
        public int MemberBilledId { get; set; }
        public virtual Member MemberId { get; set; }
        [Display(Name = "Hourly Flight Rate")]
        public double HourlyFlightRate{ get; set; }
        [Display(Name = "Amount Due for Flight Time")]
        public double HoursBilled { get; set; }
        [Display(Name = "Hours Flown")]
        public double HoursFlown { get; set; }
        [Display(Name = "Monthly Due")]
        public double MonthlyDues { get; set; }
        [Display(Name = "Total Due")]
        public double TotalAmountOwed { get; set; }

    }
}