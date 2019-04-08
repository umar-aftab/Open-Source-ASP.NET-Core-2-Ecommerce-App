using CoreEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class AdminUserRepository : Repository<AdminUser>
    {
        public AdminUserRepository() { }
        public AdminUserRepository(ContextEntities context) : base(context)
        {
        }
    }
}
