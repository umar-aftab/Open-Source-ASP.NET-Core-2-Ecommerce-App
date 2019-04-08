using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class FlaggedUser
    {
        public Guid WebsiteUserId { get; set; }
        public Guid AdminUserId { get; set; }
        public string Comments { get; set; }

        public AdminUser AdminUser { get; set; }
        public WebsiteUser WebsiteUser { get; set; }
    }
}
