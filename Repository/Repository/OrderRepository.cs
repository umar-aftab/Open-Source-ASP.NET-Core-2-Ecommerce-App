using CoreEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository() { }
        public OrderRepository(ContextEntities context) : base(context)
        {
        }
    }
}
