using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class BillingInfo
    {
        public BillingInfo()
        {
            TransactionHistory = new HashSet<TransactionHistory>();
        }

        public Guid BillingInfoId { get; set; }
        public Guid WebsiteUserId { get; set; }
        public bool PaymentStatus { get; set; }
        public byte[] Password { get; set; }
        public string PayPalEmail { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public WebsiteUser WebsiteUser { get; set; }
        public ICollection<TransactionHistory> TransactionHistory { get; set; }
    }
}
