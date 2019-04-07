using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Service
{
    public class FlaggedReviewRepository : Repository<Entities.FlaggedReview>
    {
        public FlaggedReviewRepository() { }
        public FlaggedReviewRepository(ContextEntities context) : base(context)
        {
            context.Configuration.LazyLoadingEnabled = false;
        }
    }
}
