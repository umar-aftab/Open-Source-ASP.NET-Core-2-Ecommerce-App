using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class DropOffFacility
    {
        public DropOffFacility()
        {
            FacilityEmployee = new HashSet<FacilityEmployee>();
            FacilityItem = new HashSet<FacilityItem>();
        }

        public Guid FacilityId { get; set; }
        public string FacilityName { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Hours { get; set; }

        public ICollection<FacilityEmployee> FacilityEmployee { get; set; }
        public ICollection<FacilityItem> FacilityItem { get; set; }
    }
}
