using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class OrderProduct
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
