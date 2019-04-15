using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreEntities;
using Service;
using System.Security.Claims;
using WebApplication.ViewModel;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace WebApplication.Controllers
{
    public class ProductController : MainController
    {
        private readonly ProductRepository productRepository;
        private readonly ProductCategoryRepository productCategoryRepository;
        private readonly ProductTypeRepository productTypeRepository;
        private readonly ProductViewModel productViewModel;
        public ProductController(ContextEntities context) : base(context)
        {
            context = _context;
            productRepository = new ProductRepository(context);
            productTypeRepository = new ProductTypeRepository(context);
            productCategoryRepository = new ProductCategoryRepository(context);
            productViewModel = new ProductViewModel();
        }

        public IActionResult CreateProduct()
        {
            // 
            productViewModel.Categories = productCategoryRepository.All();
            productViewModel.Types = productTypeRepository.All();
            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel productVM,List<IFormFile> Image)
        {
            // this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {

                Product product = new Product();
                product.ProductId = Guid.NewGuid();
                product.Price = productVM.Price;
                product.ProductCreator = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                product.ProductCategoryId = productVM.ProductCategoryId;
                product.ProductTypeId = productVM.ProductTypeId;
                product.Description = productVM.Description;
                product.Condition = productVM.Condition;
                product.Flagged = false;
                foreach (var item in Image)
                {
                    if (item.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await item.CopyToAsync(stream);
                            product.Image = stream.ToArray();
                            productVM.Image = stream.ToArray();
                        }
                    }
                }
                productRepository.Insert(product);
                productRepository.CommitChanges();
                return RedirectToAction("ViewMyProducts", "Product");

            }
            else
            {
                return View(productVM);
            }
        }

        public IActionResult ViewMyProducts()
        {
           //// var product = productRepository.GetById(ProductId);
           // product.ProductType = productTypeRepository.GetById(product.ProductTypeId);
           // product.ProductCategory = productCategoryRepository.GetById(product.ProductCategoryId);
            return View();
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
