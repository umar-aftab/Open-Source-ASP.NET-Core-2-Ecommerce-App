using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;

namespace Service
{
    public class BillingInfoRepository : Repository<BillingInfo>
    {
        public BillingInfoRepository() { }
        public BillingInfoRepository(ContextEntities context) : base(context)
        {
        }
    }
}
