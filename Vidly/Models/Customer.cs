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
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Display(Name = "Birthdate")]
        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }
        public bool IsSybscribedToNewsletter { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        //public byte MembershipTypeId { get; set; }
        public virtual MembershipType MembershipType { get; set; }
    }
}