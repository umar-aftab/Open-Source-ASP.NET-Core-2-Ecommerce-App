using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class FacilityEmployeeRepository: Repository<Entities.FacilityEmployee>
    {
        public FacilityEmployeeRepository() { }
        public FacilityEmployeeRepository(ContextEntities context) : base(context)
        {
            context.Configuration.LazyLoadingEnabled = false;
        }
    }
}
