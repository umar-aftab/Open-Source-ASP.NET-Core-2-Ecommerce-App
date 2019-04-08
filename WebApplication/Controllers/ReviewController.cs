using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreEntities;
using Service;

namespace WebApp.Controllers
{
    public class ReviewController : MainController
    {
        private readonly ReviewRepository reviewRepository;
        public ReviewController(ContextEntities context) : base(context)
        {
            context = _context;
            reviewRepository = new ReviewRepository(context);
        }


        public IActionResult ViewReviews()
        {
            var reviews = reviewRepository.Get(a => a.Flagged == false);
            return View(reviews);
        }

    }
}