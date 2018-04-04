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
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double HourlyFlightRate{ get; set; }
        [Display(Name = "Amount Due for Flight Time")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double HoursBilled { get; set; }
        [Display(Name = "Hours Flown")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double HoursFlown { get; set; }
        [Display(Name = "Monthly Dues")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double MonthlyDues { get; set; }
        [Display(Name = "Total Due")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double TotalAmountOwed { get; set; }

    }
}