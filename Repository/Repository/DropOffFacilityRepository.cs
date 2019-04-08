using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;

namespace Service
{
    public class DropOffFacilityRepository : Repository<DropOffFacility>
    {
        public DropOffFacilityRepository() { }
        public DropOffFacilityRepository(ContextEntities context) : base(context)
        {
        }
    }
}
