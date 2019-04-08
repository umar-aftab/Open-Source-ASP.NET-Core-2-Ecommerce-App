using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;

namespace Service
{
    public class FlaggedUserRepository : Repository<FlaggedUser>
    {
        public FlaggedUserRepository() { }
        public FlaggedUserRepository(ContextEntities context) : base(context)
        {

        }
    }
}
