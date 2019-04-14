using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;
using CoreEntities;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FacilityApp.Controllers
{
    public class DropOffFacilityController : MainController
    {
        private readonly DropOffFacilityRepository dropOffFacilityRepository;
        

        public DropOffFacilityController(ContextEntities context) : base(context)
        {
            context = _context;
            dropOffFacilityRepository = new DropOffFacilityRepository(context);
            
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

    }
}
