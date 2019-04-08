using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class Review
    {
        public Review()
        {
            FlaggedReview = new HashSet<FlaggedReview>();
        }

        public Guid ReviewId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Guid ReviewingUserId { get; set; }
        public Guid ReviewedUserId { get; set; }
        public string Stars { get; set; }
        public DateTime Date { get; set; }
        public bool Flagged { get; set; }

        public WebsiteUser ReviewedUser { get; set; }
        public WebsiteUser ReviewingUser { get; set; }
        public ICollection<FlaggedReview> FlaggedReview { get; set; }
    }
}
