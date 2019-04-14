using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreEntities;
using Service;
using AdminApp.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace AdminApp.Controllers
{
    [Authorize]
    public class AdminUserController : MainController
    {
        private readonly AdminUserRepository adminUserRepository;
        private readonly WebsiteUserRepository websiteUserRepository;
        private readonly ProductRepository productRepository;
        private readonly ReviewRepository reviewRepository;
        private readonly OrderRepository orderRepository;
        private readonly DropOffFacilityRepository dropOffFacilityRepository;
        private readonly FacilityEmployeeRepository facilityEmployeeRepository;
        private readonly FlaggedUserRepository flaggedUserRepository;
        private readonly FlaggedReviewRepository flaggedReviewRepository;
        private readonly FlaggedProductRepository flaggedProductRepository;
        private readonly FlaggedOrderRepository flaggedOrderRepository;
        private UserManager user;
        public AdminUserController(ContextEntities context) : base(context)
        {
            context = _context;
            user = new UserManager()
            {
                Name = "defualt",
                Password = null,
                AdminId = Guid.Empty
            };
            adminUserRepository = new AdminUserRepository(context);
            websiteUserRepository = new WebsiteUserRepository(context);
            productRepository = new ProductRepository(context);
            reviewRepository = new ReviewRepository(context);
            orderRepository = new OrderRepository(context);
            dropOffFacilityRepository = new DropOffFacilityRepository(context);
            facilityEmployeeRepository = new FacilityEmployeeRepository(context);
            flaggedOrderRepository = new FlaggedOrderRepository(context);
            flaggedProductRepository = new FlaggedProductRepository(context);
            flaggedReviewRepository = new FlaggedReviewRepository(context);
            flaggedUserRepository = new FlaggedUserRepository(context);
        }
        public IActionResult Index(UserManager user)
        {
            ViewBag.Message = "Welcome " + user.Name + " !";
            return View();
        }

        public bool isValidAuth(string username, string password)
        {
            return adminUserRepository.Any(x => x.Name == username && x.Password == password);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserManager loggedUser)
        {
            if (!isValidAuth(loggedUser.Name, loggedUser.Password))
            {
                return View();
            }
            else
            {
                loggedUser.AdminId = adminUserRepository.First(x => x.Name == loggedUser.Name && x.Password == loggedUser.Password).AdminUserId;
            }
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"Admin"),
                new Claim(ClaimTypes.Name,loggedUser.Name),
                new Claim(ClaimTypes.NameIdentifier,loggedUser.AdminId.ToString())
            };

            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, scheme);

            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(scheme, principal);
            this.user.Name = loggedUser.Name;
            this.user.Password = loggedUser.Password;
            this.user.AdminId = loggedUser.AdminId;
            return RedirectToAction("Index", "AdminUser", this.user);
        }

        public async Task<IActionResult> Logout()
        {
            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;
            await HttpContext.SignOutAsync(scheme);
            return RedirectToAction("Login");
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult ViewUsers()
        {
            var users=websiteUserRepository.All();
            return View(users);
        }

        public IActionResult ViewProducts()
        {
            var products = productRepository.All();
            return View(products);
        }

        public IActionResult ViewReviews()
        {
            var reviews = reviewRepository.All();
            return View(reviews);
        }

        public IActionResult ViewOrders()
        {
            var orders = orderRepository.All();
            return View(orders);
        }

        public IActionResult ViewFacilities()
        {
            var facilities = dropOffFacilityRepository.All();
            return View(facilities);
        }

        public IActionResult ViewFacilityEmployees()
        {
            var employees = facilityEmployeeRepository.All();
            return View(employees);
        }

        public IActionResult AddFacility()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFacility(DropOffFacility dropOffFacility)
        {
            if (ModelState.IsValid)
            {
                dropOffFacility.FacilityId = Guid.NewGuid();
                dropOffFacilityRepository.Insert(dropOffFacility);
                dropOffFacilityRepository.CommitChanges();
                return RedirectToAction("ViewFacilities", "AdminUser");
            }
            else
            {
                return View(dropOffFacility);
            }
        }

        public IActionResult EditFacility(Guid FacilityId)
        {
            if (ModelState.IsValid)
            {
                DropOffFacility facilityD = new DropOffFacility();
                var facility = dropOffFacilityRepository.GetById(FacilityId);
                facilityD.FacilityId = facility.FacilityId;
                facilityD.PostalCode = facility.PostalCode;
                facilityD.Street = facility.Street;
                facilityD.City = facility.City;
                facilityD.FacilityName = facility.FacilityName;
                facilityD.Hours = facility.Hours;
                return View(facilityD);
            }
            else
            {
                ModelState.AddModelError("Error", "Facility could not be edited.");
                return RedirectToAction("Error", "AdminUser");
            }
        }

        [HttpPost]
        public IActionResult EditFacility(DropOffFacility dropOffFacility)
        {
            if (ModelState.IsValid)
            {
                dropOffFacilityRepository.Update(dropOffFacility);
                dropOffFacilityRepository.CommitChanges();
                return RedirectToAction("ViewFacilities", "AdminUser");
            }
            else
            {
                return View(dropOffFacility);
            }
        }

        public IActionResult DeleteFacility(Guid FacilityId)
        {
            var facility = dropOffFacilityRepository.GetById(FacilityId);
            DropOffFacility facilityD = new DropOffFacility();
            facilityD.FacilityId = facility.FacilityId;
            facilityD.PostalCode = facility.PostalCode;
            facilityD.Street = facility.Street;
            facilityD.City = facility.City;
            facilityD.FacilityName = facility.FacilityName;
            facilityD.Hours = facility.Hours;
            dropOffFacilityRepository.Delete(facilityD);
            return RedirectToAction("ViewFacilities");
        }

        public IActionResult AddFacilityEmployee(Guid FacilityId)
        {
            if (ModelState.IsValid)
            {
                FacilityEmployee facilityEmployee = new FacilityEmployee();
                var facility = dropOffFacilityRepository.GetById(FacilityId);
                facilityEmployee.FacilityId = facility.FacilityId;
                facilityEmployee.PostalCode = facility.PostalCode;
                facilityEmployee.Street = facility.Street;
                facilityEmployee.City = facility.City;

                return View(facilityEmployee);
            }
            else
            {
                ModelState.AddModelError("Error", "Facility Employee cannot be added.");
                return RedirectToAction("Error", "AdminUser");
            }
        }

        [HttpPost]
        public IActionResult AddFacilityEmployee(FacilityEmployee facilityEmployee)
        {
            if (ModelState.IsValid)
            {
                facilityEmployee.EmployeeId = Guid.NewGuid();
                facilityEmployeeRepository.Insert(facilityEmployee);
                facilityEmployeeRepository.CommitChanges();
                return RedirectToAction("Index", "FacilityEmployee");
            }
            else
            {
                return View(facilityEmployee);
            }
        }

        public IActionResult EditFacilityEmployee(Guid EmployeeId)
        {
            if (ModelState.IsValid)
            {
                FacilityEmployee facilityEmp = new FacilityEmployee();
                var facility = facilityEmployeeRepository.GetById(EmployeeId);
                facilityEmp.FacilityId = facility.FacilityId;
                facilityEmp.PostalCode = facility.PostalCode;
                facilityEmp.Street = facility.Street;
                facilityEmp.City = facility.City;
                facilityEmp.Email = facility.Email;
                facilityEmp.EmployeeId = facility.EmployeeId;
                facilityEmp.Name = facility.Name;
                facilityEmp.Password = facility.Password;
                return View(facilityEmp);
            }
            else
            {
                ModelState.AddModelError("Error", "Facility Emp could not be edited.");
                return RedirectToAction("Error", "AdminUser");
            }
        }

        [HttpPost]
        public IActionResult EditFacilityEmployee(FacilityEmployee employee)
        {
            if (ModelState.IsValid)
            {
                facilityEmployeeRepository.Update(employee);
                facilityEmployeeRepository.CommitChanges();
                return RedirectToAction("ViewFacilityEmployees", "AdminUser");
            }
            else
            {
                return View(employee);
            }
        }

        public IActionResult DeleteFacilityEmployee(Guid EmployeeId)
        {
            FacilityEmployee facilityEmp = new FacilityEmployee();
            var facility = facilityEmployeeRepository.GetById(EmployeeId);
            facilityEmp.FacilityId = facility.FacilityId;
            facilityEmp.PostalCode = facility.PostalCode;
            facilityEmp.Street = facility.Street;
            facilityEmp.City = facility.City;
            facilityEmp.Email = facility.Email;
            facilityEmp.EmployeeId = facility.EmployeeId;
            facilityEmp.Name = facility.Name;
            facilityEmp.Password = facility.Password;
            facilityEmployeeRepository.Delete(facilityEmp);
            return RedirectToAction("ViewFacilityEmployees");
        }

        /*Flagging Methods*/

        public IActionResult FlagUser(Guid WebsiteUserId)
        {
            if (ModelState.IsValid)
            {
                var user = websiteUserRepository.GetById(WebsiteUserId);
                user.Flagged = true;
                WebsiteUser webUser = new WebsiteUser();
                webUser.WebsiteUserId = user.WebsiteUserId;
                webUser.UserName = user.UserName;
                webUser.Email = user.Email;
                webUser.FirstName = user.FirstName;
                webUser.LastName = user.LastName;
                webUser.Password = user.Password;
                webUser.Flagged = user.Flagged;
                websiteUserRepository.Update(webUser);
                websiteUserRepository.CommitChanges();
                Guid AdminId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                FlaggedUser flaggedUser = new FlaggedUser();
                flaggedUser.AdminUserId = AdminId;
                flaggedUser.WebsiteUserId = WebsiteUserId;
                flaggedUser.Comments = " ";
                flaggedUserRepository.Insert(flaggedUser);
                flaggedUserRepository.CommitChanges();
                return RedirectToAction("ViewUsers");
            }
            else
            {
                ModelState.AddModelError("Error", "User couldnt be flagged.");
                return RedirectToAction("Error", "AdminUser");
            }
        }

        public IActionResult FlagProduct(Guid ProductId)
        {
            if (ModelState.IsValid)
            {
                var product = productRepository.GetById(ProductId);
                product.Flagged = true;
                Product webProduct= new Product();
                webProduct.ProductId = product.ProductId;
                webProduct.Condition = product.Condition;
                webProduct.Description = product.Description;
                webProduct.Image = product.Image;
                webProduct.Price = product.Price;
                webProduct.ProductCategoryId = product.ProductCategoryId;
                webProduct.ProductTypeId = product.ProductTypeId;
                webProduct.Flagged = product.Flagged;
                productRepository.Update(webProduct);
                productRepository.CommitChanges();
                Guid AdminId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                FlaggedProduct flaggedPro = new FlaggedProduct();
                flaggedPro.AdminUserId = AdminId;
                flaggedPro.ProductId = ProductId;
                flaggedPro.Comments = " ";
                flaggedProductRepository.Insert(flaggedPro);
                flaggedProductRepository.CommitChanges();
                return RedirectToAction("ViewProducts");
            }
            else
            {
                ModelState.AddModelError("Error", "Product couldnt be flagged.");
                return RedirectToAction("Error", "AdminUser");
            }
        }

        public IActionResult FlagReview(Guid ReviewId)
        {
            if (ModelState.IsValid)
            {
                var rev = reviewRepository.GetById(ReviewId);
                rev.Flagged = true;
                Review review = new Review();
                review.Content = rev.Content;
                review.Date = rev.Date;
                review.Flagged = rev.Flagged;
                review.ReviewedUserId = rev.ReviewedUserId;
                review.ReviewingUserId = rev.ReviewingUserId;
                review.Stars = rev.Stars;
                review.Subject = rev.Subject;
                review.ReviewId = rev.ReviewId;
                reviewRepository.Update(review);
                reviewRepository.CommitChanges();
                Guid AdminId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                FlaggedReview flaggedRev = new FlaggedReview();
                flaggedRev.AdminUserId = AdminId;
                flaggedRev.ReviewId = ReviewId;
                flaggedRev.Comments = " ";
                flaggedReviewRepository.Insert(flaggedRev);
                flaggedReviewRepository.CommitChanges();
                return RedirectToAction("ViewReviews");
            }
            else
            {
                ModelState.AddModelError("Error", "Review couldnt be flagged.");
                return RedirectToAction("Error", "AdminUser");
            }
        }

        public IActionResult FlagOrder(Guid OrderId)
        {
            if (ModelState.IsValid)
            {
                var order = orderRepository.GetById(OrderId);
                order.Flagged = true;
                Order webOrder = new Order();
                webOrder.Completed = order.Completed;
                webOrder.Cost = order.Cost;
                webOrder.Date = order.Date;
                webOrder.Flagged = order.Flagged;
                webOrder.OrderId = order.OrderId;
                webOrder.WebsiteUserId = order.WebsiteUserId;
                orderRepository.Update(webOrder);
                orderRepository.CommitChanges();
                Guid AdminId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                FlaggedOrder flaggedOrd = new FlaggedOrder();
                flaggedOrd.AdminUserId = AdminId;
                flaggedOrd.OrderId = OrderId;
                flaggedOrd.Comments = " ";
                flaggedOrderRepository.Insert(flaggedOrd);
                flaggedOrderRepository.CommitChanges();
                return RedirectToAction("ViewOrders");
            }
            else
            {
                ModelState.AddModelError("Error", "Order couldnt be flagged.");
                return RedirectToAction("Error", "AdminUser");
            }
        }

    }
}