using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Models
{
    public class UserManager
    {
       public Guid AdminId { get; set; } 
       public string Name { get; set; }
       public string Password { get; set; }
    }
}
