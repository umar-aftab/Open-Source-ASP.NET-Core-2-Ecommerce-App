using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities;

namespace WebAppUser.Controllers
{
    public class MainController : Controller
    {
        protected readonly ContextEntities _context;

        public MainController() { }

        public MainController(ContextEntities context)
        {
            _context = context;
        }
    }
}