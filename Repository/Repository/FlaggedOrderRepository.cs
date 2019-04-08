using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;

namespace Service
{
    public class FlaggedOrderRepository : Repository<FlaggedOrder>
    {
        public FlaggedOrderRepository() { }
        public FlaggedOrderRepository(ContextEntities context) : base(context)
        {
        }
    }
}
