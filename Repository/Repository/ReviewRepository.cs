using CoreEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
   public class ReviewRepository : Repository<Review>
   {
        public ReviewRepository() { }
        public ReviewRepository(ContextEntities context):base(context) {
        }
   }
}
