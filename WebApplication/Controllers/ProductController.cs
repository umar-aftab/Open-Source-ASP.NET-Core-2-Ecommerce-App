using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreEntities;
using Service;
using System.Security.Claims;

namespace WebApplication.Controllers
{
    public class ProductController : MainController
    {
        private readonly ProductRepository productRepository;
        private readonly ProductCategoryRepository productCategoryRepository;
        private readonly ProductTypeRepository productTypeRepository;
        public ProductController(ContextEntities context) : base(context)
        {
            context = _context;
            productRepository = new ProductRepository(context);
            productTypeRepository = new ProductTypeRepository(context);
            productCategoryRepository = new ProductCategoryRepository(context);
        }

        public IActionResult CreateProduct()
        {
            // this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
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
