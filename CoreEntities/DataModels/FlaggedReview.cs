using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class FlaggedReview
    {
        public Guid ReviewId { get; set; }
        public Guid AdminUserId { get; set; }
        public string Comments { get; set; }

        public AdminUser AdminUser { get; set; }
        public Review Review { get; set; }
    }
}
