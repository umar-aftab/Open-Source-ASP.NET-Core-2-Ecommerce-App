using CoreEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class FacilityEmployeeRepository: Repository<FacilityEmployee>
    {
        public FacilityEmployeeRepository() { }
        public FacilityEmployeeRepository(ContextEntities context) : base(context)
        {
        }
    }
}
