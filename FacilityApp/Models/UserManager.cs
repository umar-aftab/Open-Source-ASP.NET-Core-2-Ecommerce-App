using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacilityApp.Models
{
    public class UserManager
    {
       public string Name { get; set; }
       public string Password { get; set; }
       public Guid EmployeeId { get; set; }
       public Guid FacilityId { get; set; }
    }
}
