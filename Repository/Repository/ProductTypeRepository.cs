using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;

namespace Service
{
    public class ProductTypeRepository : Repository<ProductType>
    {
        public ProductTypeRepository() { }
        public ProductTypeRepository(ContextEntities context) : base(context)
        {
        }
    }
}
