using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class FlaggedOrder
    {
        public Guid OrderId { get; set; }
        public Guid AdminUserId { get; set; }
        public string Comments { get; set; }

        public AdminUser AdminUser { get; set; }
        public Order Order { get; set; }
    }
}
