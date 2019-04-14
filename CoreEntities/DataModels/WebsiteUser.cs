using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class WebsiteUser
    {
        public WebsiteUser()
        {
            BillingInfo = new HashSet<BillingInfo>();
            FacilityItemBuyer = new HashSet<FacilityItem>();
            FacilityItemSeller = new HashSet<FacilityItem>();
            FlaggedUser = new HashSet<FlaggedUser>();
            Order = new HashSet<Order>();
            ReviewReviewedUser = new HashSet<Review>();
            ReviewReviewingUser = new HashSet<Review>();
            TransactionHistory = new HashSet<TransactionHistory>();
        }

        public Guid WebsiteUserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Flagged { get; set; }

        public ICollection<BillingInfo> BillingInfo { get; set; }
        public ICollection<FacilityItem> FacilityItemBuyer { get; set; }
        public ICollection<FacilityItem> FacilityItemSeller { get; set; }
        public ICollection<FlaggedUser> FlaggedUser { get; set; }
        public ICollection<Order> Order { get; set; }
        public ICollection<Review> ReviewReviewedUser { get; set; }
        public ICollection<Review> ReviewReviewingUser { get; set; }
        public ICollection<TransactionHistory> TransactionHistory { get; set; }
    }
}
