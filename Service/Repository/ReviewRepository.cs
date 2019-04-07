using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
   public class ReviewRepository : Repository<Entities.Review>
   {
        public ReviewRepository() { }
        public ReviewRepository(ContextEntities context):base(context) {
            context.Configuration.LazyLoadingEnabled = false;
        }
   }
}
