using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Service
{
    public class DropOffFacilityRepository : Repository<Entities.DropOffFacility>
    {
        public DropOffFacilityRepository() { }
        public DropOffFacilityRepository(ContextEntities context) : base(context)
        {
            context.Configuration.LazyLoadingEnabled = false;
        }
    }
}
