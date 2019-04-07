using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Service
{
    public class FlaggedProductRepository : Repository<Entities.FlaggedProduct>
    {
        public FlaggedProductRepository() { }
        public FlaggedProductRepository(ContextEntities context) : base(context)
        {
            context.Configuration.LazyLoadingEnabled = false;
        }
    }
}
