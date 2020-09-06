using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookHotel.Data;
using System.Linq.Expressions;

namespace BookHotel.WebMVC.Controllers
{
    public class RoomNumbersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RoomNumbers
        public async Task<ActionResult> Index()
        {
            return View(await db.RoomNumbers.ToListAsync());
        }

        // GET: RoomNumbers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomNumber roomNumber = await db.RoomNumbers.FindAsync(id);
            if (roomNumber == null)
            {
                return HttpNotFound();
            }
            return View(roomNumber);
        }

        // GET: RoomNumbers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomNumbers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "roomId,King,Queen,IsCityView,IsRiverView,IsSuite")] RoomNumber roomNumber)
        {

            if (ModelState.IsValid)
            {
                db.RoomNumbers.Add(roomNumber);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(roomNumber);
        }

        // GET: RoomNumbers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomNumber roomNumber = await db.RoomNumbers.FindAsync(id);
            if (roomNumber == null)
            {
                return HttpNotFound();
            }
            return View(roomNumber);
        }

        // POST: RoomNumbers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "roomId,King,Queen,IsCityView,IsRiverView,IsSuite")] RoomNumber roomNumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomNumber).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(roomNumber);
        }

        // GET: RoomNumbers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomNumber roomNumber = await db.RoomNumbers.FindAsync(id);
            if (roomNumber == null)
            {
                return HttpNotFound();
            }
            return View(roomNumber);
        }

        // POST: RoomNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RoomNumber roomNumber = await db.RoomNumbers.FindAsync(id);
            db.RoomNumbers.Remove(roomNumber);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
