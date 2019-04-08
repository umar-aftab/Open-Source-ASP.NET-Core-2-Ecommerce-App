using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class ProductType
    {
        public ProductType()
        {
            Product = new HashSet<Product>();
        }

        public Guid ProductTypeId { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
