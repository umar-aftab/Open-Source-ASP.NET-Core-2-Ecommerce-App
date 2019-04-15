using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEntities;

namespace WebApplication.ViewModel
{
    public class ProductViewModel
    {
        public Guid ProductCategoryId { get; set; }
        public IEnumerable<ProductCategory> Categories;
        public Guid ProductTypeId { get; set; }
        public IEnumerable<ProductType> Types;
        public string Price { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Condition { get; set; }

    }
}
