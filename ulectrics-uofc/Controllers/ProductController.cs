using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Service;

namespace WebAppUser.Controllers
{
    public class ProductController : MainController
    {
        private readonly ProductRepository productRepository;
        public ProductController(ContextEntities context):base(context)
        {
            context = _context;
            productRepository = new ProductRepository(context);
        }

        public IActionResult CreateProduct()
        {
            return null;
        }

        public IActionResult ViewProduct()
        {
            return null;
        }

        public IActionResult RemoveProduct()
        {
            return null;
        }

        public IActionResult EditProduct()
        {
            return null;
        }

        public IActionResult FlagProduct()
        {
            return null;
        }

        public IActionResult ViewProductList()
        {
            return null;
        }

    }
}
