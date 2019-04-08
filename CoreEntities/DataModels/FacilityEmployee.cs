using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class FacilityEmployee
    {
        public Guid EmployeeId { get; set; }
        public Guid FacilityId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public DropOffFacility Facility { get; set; }
    }
}
