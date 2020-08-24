using BookHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookHotel.WebMVC.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        [Authorize]
        public ActionResult Index()
        {
            var model = new ReservationListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }

    }
}