using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's first name.")]
        [StringLength(50, ErrorMessage = "First name can't be bigger than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter customer's last name.")]
        [StringLength(50, ErrorMessage = "Last name can't be bigger than 50 characters.")]
        public string LastName { get; set; }

        public string Name
        {
            get { return FirstName + " " + LastName; }
        }

        public DateTime? Birthdate { get; set; }

        [Required(ErrorMessage = "Please select membersip type.")]
        public byte MembershipTypeId { get; set; }

        public bool IsSybscribedToNewsletter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
    }
}