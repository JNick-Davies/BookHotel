using BookHotel.Models;
using BookHotel.Services;
using Microsoft.AspNet.Identity;
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
            var userId = int.Parse(User.Identity.GetUserId());
            var service = new ReservationService(userId);
            var model = service.GetReservations();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = int.Parse(User.Identity.GetUserId());
            var service = new ReservationService(userId);

            service.CreateReservation(model);

            return RedirectToAction("Index");
        }

    }
}