using CoreEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class ProductRepository: Repository<Product>
    {
        public ProductRepository() { }
        public ProductRepository(ContextEntities context) : base(context)
        {
        }

    }
}
