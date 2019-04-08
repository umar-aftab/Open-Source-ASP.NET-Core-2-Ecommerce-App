using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class AdminAccesLevel
    {
        public AdminAccesLevel()
        {
            AdminUser = new HashSet<AdminUser>();
        }

        public Guid AdminAccesLevelId { get; set; }
        public string AccessLevel { get; set; }

        public ICollection<AdminUser> AdminUser { get; set; }
    }
}
