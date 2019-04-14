using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;
using CoreEntities;
using FacilityApp.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FacilityApp.Controllers
{
    public class DropOffFacilityController : MainController
    {
        private readonly DropOffFacilityRepository dropOffFacilityRepository;
        private readonly FacilityItemRespository facilityItemRespository;
        private readonly WebsiteUserRepository websiteUserRepository;
        private readonly OrderRepository orderRepository;

        public DropOffFacilityController(ContextEntities context) : base(context)
        {
            context = _context;
            dropOffFacilityRepository = new DropOffFacilityRepository(context);
            facilityItemRespository = new FacilityItemRespository(context);
            websiteUserRepository = new WebsiteUserRepository(context);
            orderRepository = new OrderRepository(context);
        }
        // GET: /<controller>/
        public IActionResult Index(UserManager user)
        {
            ViewBag.Message = "Welcome " + user.Name + "!";
            return View();
        }

        public IActionResult ViewItems()
        {
            var items=facilityItemRespository.All();
            foreach (var item in items)
            {
                item.Buyer = websiteUserRepository.GetById(item.BuyerId);
                item.Seller = websiteUserRepository.GetById(item.Seller);
                item.Facility = dropOffFacilityRepository.GetById(item.FacilityId);
                item.Order = orderRepository.GetById(item.OrderId);
            }
            return View(items);
        }

        public IActionResult DroppedOff(Guid ItemId)
        {
            var item = facilityItemRespository.GetById(ItemId);
            item.DroppedOf = true;
            facilityItemRespository.Update(item);
            facilityItemRespository.CommitChanges();
            return RedirectToAction("ViewItems");
        }


        public IActionResult PickedUp(Guid ItemId)
        {
            var item = facilityItemRespository.GetById(ItemId);
            item.PickedUp = true;
            facilityItemRespository.Update(item);
            facilityItemRespository.CommitChanges();
            return RedirectToAction("ViewItems");
        }


    }
}
