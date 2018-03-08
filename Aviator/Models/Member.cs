using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aviator.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [Required]
        public string MemberRole { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Cell Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }


        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
