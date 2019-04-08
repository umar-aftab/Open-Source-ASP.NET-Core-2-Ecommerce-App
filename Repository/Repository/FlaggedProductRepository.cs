using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;

namespace Service
{
    public class FlaggedProductRepository : Repository<FlaggedProduct>
    {
        public FlaggedProductRepository() { }
        public FlaggedProductRepository(ContextEntities context) : base(context)
        {
        }
    }
}
