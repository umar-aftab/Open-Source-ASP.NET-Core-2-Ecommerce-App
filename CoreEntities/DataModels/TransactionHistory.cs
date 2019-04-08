using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class TransactionHistory
    {
        public Guid HistoryId { get; set; }
        public Guid WebsiteUserId { get; set; }
        public Guid BillingInfoId { get; set; }
        public Guid ProductId { get; set; }

        public BillingInfo BillingInfo { get; set; }
        public Product Product { get; set; }
        public WebsiteUser WebsiteUser { get; set; }
    }
}
