using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;
using CoreEntities;
using FacilityApp.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace FacilityApp.Controllers
{
    public class FacilityEmployeeController : MainController
    {
        private readonly FacilityEmployeeRepository facilityEmployeeRepository;
        private readonly FacilityItemRespository facilityItemRespository;
        private readonly UserManager user;


        public FacilityEmployeeController(ContextEntities context):base(context)
        {
            context = _context;
            user = new UserManager()
            {
                Name = "default",
                Password = null
            };
            facilityEmployeeRepository = new FacilityEmployeeRepository(context);
            facilityItemRespository = new FacilityItemRespository(context);
        }

        public bool isValidAuth(string username, string password)
        {
            return facilityEmployeeRepository.Any(x => x.Name == username && x.Password == password);
        }

        public IActionResult Index(UserManager user)
        {
            ViewBag.Message = "Welcome " + user.Name + "!";
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserManager loggedUser)
        {
            if (!isValidAuth(loggedUser.Name, loggedUser.Password))
                return View();
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"User"),
                new Claim(ClaimTypes.NameIdentifier,loggedUser.Name)
            };

            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, scheme);

            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(scheme, principal);
            this.user.Name = loggedUser.Name;
            this.user.Password = loggedUser.Password;
            return RedirectToAction("Index", "FacilityEmployee", this.user);
        }

        public async Task<IActionResult> Logout()
        {
            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;
            await HttpContext.SignOutAsync(scheme);
            return RedirectToAction("Login");
        }

        public IActionResult ViewItems()
        {
            var items = facilityItemRespository.All();
            return View();
        }
    }
}