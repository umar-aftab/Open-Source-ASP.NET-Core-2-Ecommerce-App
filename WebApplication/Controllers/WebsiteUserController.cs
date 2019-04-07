using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Entities;
using Service;

namespace WebAppUser.Controllers
{
    public class WebsiteUserController : MainController
    {
        private readonly WebsiteUserRepository websiteUserRepository;
        public WebsiteUserController() { }
        public WebsiteUserController(ContextEntities context): base(context)
        {
            context = _context;
            websiteUserRepository = new WebsiteUserRepository(context);
        }

        public ActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Register()
        //{

        //}

    }
}