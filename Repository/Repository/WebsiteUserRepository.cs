using CoreEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class WebsiteUserRepository : Repository<WebsiteUser>
    {
        public WebsiteUserRepository() { }
        public WebsiteUserRepository(ContextEntities context) : base(context)
        {
        }
    }
}
