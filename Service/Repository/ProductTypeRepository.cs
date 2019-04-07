using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Service
{
    public class ProductTypeRepository : Repository<Entities.ProductType>
    {
        public ProductTypeRepository() { }
        public ProductTypeRepository(ContextEntities context) : base(context)
        {
            context.Configuration.LazyLoadingEnabled = false;
        }
    }
}
