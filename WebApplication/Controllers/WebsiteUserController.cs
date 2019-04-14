using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreEntities;
using Service;
using WebApplication.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace WebApplication.Controllers
{
    public class WebsiteUserController : MainController
    {
        private readonly WebsiteUserRepository websiteUserRepository;
        private UserManager user;
        public WebsiteUserController(ContextEntities context) : base(context)
        {
            context = _context;
            user = new UserManager()
            {
                UserName = "default",
                Password = null
            };
            websiteUserRepository = new WebsiteUserRepository(context);
            
        }

        public bool isValidAuth(string username,string password)
        {
            return websiteUserRepository.Any(x => x.UserName == username && x.Password == password);
        }

        public IActionResult Index(UserManager user)
        {
            ViewBag.Message = "Welcome " + user.UserName + "!";
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(WebsiteUser websiteUser)
        {
            if (ModelState.IsValid) {
                websiteUser.WebsiteUserId = Guid.NewGuid();
                websiteUserRepository.Insert(websiteUser);
                websiteUserRepository.CommitChanges();
                this.user.UserName = websiteUser.UserName;
                this.user.Password = websiteUser.Password;
                TempData["user"] = user;
                return RedirectToAction("Index","WebsiteUser",this.user);
                //WebsiteUser wUser = new WebsiteUser();wUser.WebsiteUserId = Guid.NewGuid();wUser.FirstName = websiteUser.FirstName;wUser.LastName = websiteUser.LastName;wUser.UserName = websiteUser.UserName;wUser.Email = websiteUser.Email;wUser.Password = websiteUser.Password;
                //websiteUserRepository.Insert(wUser);
            }
            else
            {
                return View(websiteUser);
            }
        }
      

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserManager loggedUser)
        {
            if (!isValidAuth(loggedUser.UserName, loggedUser.Password))
                return View();
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"User"),
                new Claim(ClaimTypes.NameIdentifier,loggedUser.UserName)
            };
          
            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, scheme);

            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(scheme, principal);
            this.user.UserName = loggedUser.UserName;
            this.user.Password = loggedUser.Password;
            return RedirectToAction("Index","WebsiteUser",this.user);
        }

        public async Task<IActionResult> Logout()
        {
            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;
            await HttpContext.SignOutAsync(scheme);
            return RedirectToAction("Login");
        }


    }
}