using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreEntities
{
    public partial class FacilityEmployee
    {
        public Guid EmployeeId { get; set; }
        [ForeignKey("DropOffFacility")]
        public Guid FacilityId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "The email address is not valid")]
        public string Email { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Password { get; set; }

        public DropOffFacility Facility { get; set; }
    }
}
