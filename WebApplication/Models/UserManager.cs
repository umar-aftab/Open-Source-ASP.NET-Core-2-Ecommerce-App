﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class UserManager
    {
       public string UserName { get; set; }
       public string Password { get; set; }
       public Guid WebsiteUserId { get; set; }
    }
}
