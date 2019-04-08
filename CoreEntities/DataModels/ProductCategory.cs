using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Product = new HashSet<Product>();
        }

        public Guid ProductCategoryId { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
