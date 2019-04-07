using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
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

        public ActionResult CreateProduct()
        {
            return null;
        }

        public ActionResult ViewProduct()
        {
            return null;
        }

        public ActionResult RemoveProduct()
        {
            return null;
        }

        public ActionResult EditProduct()
        {
            return null;
        }

        public ActionResult FlagProduct()
        {
            return null;
        }

        public ActionResult ViewProductList()
        {
            return null;
        }

    }
}
