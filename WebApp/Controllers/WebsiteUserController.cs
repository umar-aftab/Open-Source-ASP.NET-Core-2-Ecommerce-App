using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreEntities;
using Service;

namespace WebApp.Controllers
{
    public class WebsiteUserController : MainController
    {
        private readonly WebsiteUserRepository websiteUserRepository;
        public WebsiteUserController(ContextEntities context) : base(context)
        {
            context = _context;
            websiteUserRepository = new WebsiteUserRepository(context);
        }

        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Register()
        //{

        //}

    }
}