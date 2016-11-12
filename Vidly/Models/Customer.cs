using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter customer's first name.")]
        [StringLength(50, ErrorMessage = "First name can't be bigger than 50 characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter customer's last name.")]
        [StringLength(50, ErrorMessage = "Last name can't be bigger than 50 characters.")]
        public string LastName { get; set; }

        [Min18YearsIfAMember]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? Birthdate { get; set; }

        public bool IsSybscribedToNewsletter { get; set; }

        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }

        [Display(Name = "Membership Type")]
        [Required(ErrorMessage = "Please select membersip type.")]
        public byte MembershipTypeId { get; set; }

        public virtual MembershipType MembershipType { get; set; }
    }
}