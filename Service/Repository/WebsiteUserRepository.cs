using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class WebsiteUserRepository : Repository<Entities.WebsiteUser>
    {
        public WebsiteUserRepository() { }
        public WebsiteUserRepository(ContextEntities context) : base(context)
        {
            context.Configuration.LazyLoadingEnabled = false;
        }
    }
}
