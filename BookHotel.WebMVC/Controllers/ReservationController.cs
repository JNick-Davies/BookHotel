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
    [Authorize]
    public class ReservationController : Controller
    {
        private ReservationService CreateReservationService()
        {
            var StaffIdLogin = Guid.Parse(User.Identity.GetUserId());
            var service = new ReservationService(StaffIdLogin);
            return service;
        }

        // GET: Reservation

        public ActionResult Index()
        {
            var StaffIdLogin = Guid.Parse(User.Identity.GetUserId());
            var service = new ReservationService(StaffIdLogin);
            var model = service.GetReservationById();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Reservation/Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateReservationService();

            if (service.CreateReservation(model))
            {
                TempData["SaveResult"] = "Your reservation was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your reservation is unable to be completed");

            return View(model);
        }

        

        /*[HttpGet]
        [Route("Reservation/{ReservationId}")]
        public ActionResult GetReservation(int ReservationId)
        {
            ReservationService reservationService = CreateReservationService();
            var currentReservation = reservationService.GetReservationById(ReservationId);
            return View(currentReservation);
        }*/


    } 
}
