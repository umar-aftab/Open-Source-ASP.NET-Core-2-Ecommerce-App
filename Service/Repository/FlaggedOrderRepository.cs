using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Service
{
    public class FlaggedOrderRepository : Repository<Entities.FlaggedOrder>
    {
        public FlaggedOrderRepository() { }
        public FlaggedOrderRepository(ContextEntities context) : base(context)
        {
            context.Configuration.LazyLoadingEnabled = false;
        }
    }
}
