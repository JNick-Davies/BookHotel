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
            var model = service.GetReservationList();

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

        public ActionResult Edit(int id)
        {
            var service = CreateReservationService();
            var detail = service.GetReservationById(id);
            var model =
                new ReservationEdit
                {
                    Rate = detail.Rate,
                    ArrivialDate = detail.ArrivalDate,
                    NumberOfNights = detail.NumberOfNights,
                    NumberOfRooms = detail.NumberOfRooms,
                    GuestFirstName = detail.GuestFirstName,
                    GuestlastName = detail.GuestlastName,
                    GuestEmail = detail.GuestEmail,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReservationEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ReservationId != id)
            {
                ModelState.AddModelError("", "Reservation Mismatch");
                return View(model);
            }

            var service = CreateReservationService();

            if (service.UpdateReservation(model))
            {
                TempData["SaveResult"] = "Your Reservation was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Reservation could not be updated.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateReservationService();
            var model = svc.GetReservationById(id);

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateReservationService();
            var model = svc.GetReservationById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteReservation(int id)
        {
            var service = CreateReservationService();

            service.DeleteReservation(id);

            TempData["SaveResult"] = "Your Reservation was deleted";

            return RedirectToAction("Index");
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
