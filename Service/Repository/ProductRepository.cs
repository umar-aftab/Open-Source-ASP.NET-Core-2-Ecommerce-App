using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class ProductRepository: Repository<Entities.Product>
    {
        public ProductRepository() { }
        public ProductRepository(ContextEntities context) : base(context)
        {
            context.Configuration.LazyLoadingEnabled = false;
        }

    }
}
