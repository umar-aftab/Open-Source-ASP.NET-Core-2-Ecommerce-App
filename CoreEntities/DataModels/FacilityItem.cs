using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class FacilityItem
    {
        public Guid ItemId { get; set; }
        public Guid FacilityId { get; set; }
        public Guid OrderId { get; set; }
        public Guid SellerId { get; set; }
        public Guid BuyerId { get; set; }
        public bool DroppedOf { get; set; }
        public bool PickedUp { get; set; }

        public WebsiteUser Buyer { get; set; }
        public DropOffFacility Facility { get; set; }
        public Order Order { get; set; }
        public WebsiteUser Seller { get; set; }
    }
}
