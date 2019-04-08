using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class AdminUser
    {
        public AdminUser()
        {
            FlaggedOrder = new HashSet<FlaggedOrder>();
            FlaggedProduct = new HashSet<FlaggedProduct>();
            FlaggedReview = new HashSet<FlaggedReview>();
            FlaggedUser = new HashSet<FlaggedUser>();
        }

        public Guid AdminUserId { get; set; }
        public string Name { get; set; }
        public byte[] Password { get; set; }
        public Guid AccessLevelId { get; set; }

        public AdminAccesLevel AccessLevel { get; set; }
        public ICollection<FlaggedOrder> FlaggedOrder { get; set; }
        public ICollection<FlaggedProduct> FlaggedProduct { get; set; }
        public ICollection<FlaggedReview> FlaggedReview { get; set; }
        public ICollection<FlaggedUser> FlaggedUser { get; set; }
    }
}
