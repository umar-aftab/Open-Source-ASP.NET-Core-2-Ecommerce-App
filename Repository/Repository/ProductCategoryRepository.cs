using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;

namespace Service
{
    public class ProductCategoryRepository : Repository<ProductCategory>
    {
        public ProductCategoryRepository() { }
        public ProductCategoryRepository(ContextEntities context) : base(context)
        {
        }
 
    }
}
