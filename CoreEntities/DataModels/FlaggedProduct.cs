using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class FlaggedProduct
    {
        public Guid ProductId { get; set; }
        public Guid AdminUserId { get; set; }
        public string Comments { get; set; }

        public AdminUser AdminUser { get; set; }
        public Product Product { get; set; }
    }
}
