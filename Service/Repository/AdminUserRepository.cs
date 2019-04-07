using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class AdminUserRepository : Repository<Entities.AdminUser>
    {
        public AdminUserRepository() { }
        public AdminUserRepository(ContextEntities context) : base(context)
        {
            context.Configuration.LazyLoadingEnabled = false;
        }
    }
}
