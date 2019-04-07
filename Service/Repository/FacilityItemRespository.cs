using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Service
{
    public class FacilityItemRespository : Repository<Entities.FacilityItem>
    {
        public FacilityItemRespository() { }
        public FacilityItemRespository(ContextEntities context) : base(context)
        {
            context.Configuration.LazyLoadingEnabled = false;
        }
    }
}
