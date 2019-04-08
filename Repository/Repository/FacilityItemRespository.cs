using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;

namespace Service
{
    public class FacilityItemRespository : Repository<FacilityItem>
    {
        public FacilityItemRespository() { }
        public FacilityItemRespository(ContextEntities context) : base(context)
        {
        }
    }
}
