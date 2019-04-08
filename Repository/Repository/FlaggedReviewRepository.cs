using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;

namespace Service
{
    public class FlaggedReviewRepository : Repository<FlaggedReview>
    {
        public FlaggedReviewRepository() { }
        public FlaggedReviewRepository(ContextEntities context) : base(context)
        {
        }
    }
}
