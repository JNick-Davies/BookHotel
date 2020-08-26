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
            var StaffIdLogin = Guid.Parse(User.Identity.GetUserId());
            var service = new ReservationService(StaffIdLogin);
            var model = service.GetReservations();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateReservationService();

            if (service.CreateReservation(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        private ReservationService CreateReservationService()
        {
            var StaffIdLogin = Guid.Parse(User.Identity.GetUserId());
            var service = new ReservationService(StaffIdLogin);
            return service;
        }

    }
}