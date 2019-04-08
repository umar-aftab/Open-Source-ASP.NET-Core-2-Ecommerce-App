using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class Order
    {
        public Order()
        {
            FacilityItem = new HashSet<FacilityItem>();
            FlaggedOrder = new HashSet<FlaggedOrder>();
            OrderProduct = new HashSet<OrderProduct>();
        }

        public Guid OrderId { get; set; }
        public Guid WebsiteUserId { get; set; }
        public DateTime? Date { get; set; }
        public string Cost { get; set; }
        public bool Completed { get; set; }
        public bool Flagged { get; set; }

        public WebsiteUser WebsiteUser { get; set; }
        public ICollection<FacilityItem> FacilityItem { get; set; }
        public ICollection<FlaggedOrder> FlaggedOrder { get; set; }
        public ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
