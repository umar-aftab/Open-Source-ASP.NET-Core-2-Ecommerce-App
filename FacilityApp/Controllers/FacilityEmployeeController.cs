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
        }

        public bool isValidAuth(string username, string password)
        {
            return facilityEmployeeRepository.Any(x => x.Name == username && x.Password == password);
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
                var emp = facilityEmployeeRepository.First(a => a.Name == loggedUser.Name && a.Password == loggedUser.Password);
                loggedUser.EmployeeId = emp.EmployeeId;
                loggedUser.FacilityId = emp.FacilityId;
            }
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"User"),
                new Claim(ClaimTypes.NameIdentifier,loggedUser.EmployeeId.ToString()),
                new Claim(ClaimTypes.Name,loggedUser.Name),
                new Claim(ClaimTypes.PrimaryGroupSid,loggedUser.FacilityId.ToString())
            };

            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, scheme);

            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(scheme, principal);
            this.user.Name = loggedUser.Name;
            this.user.Password = loggedUser.Password;
            this.user.EmployeeId = loggedUser.EmployeeId;
            this.user.FacilityId = loggedUser.FacilityId;
            return RedirectToAction("Index", "DropOffFacility", this.user);
        }

        public async Task<IActionResult> Logout()
        {
            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;
            await HttpContext.SignOutAsync(scheme);
            return RedirectToAction("Login");
        }

    }
}