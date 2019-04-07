using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class OrderRepository : Repository<Entities.Order>
    {
        public OrderRepository() { }
        public OrderRepository(ContextEntities context) : base(context)
        {
            context.Configuration.LazyLoadingEnabled = false;
        }
    }
}
