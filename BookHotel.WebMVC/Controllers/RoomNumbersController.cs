using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BookHotel.Data;

namespace BookHotel.WebMVC.Controllers
{
    public class RoomNumbersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/RoomNumbers
        public IQueryable<RoomNumber> GetRoomNumbers()
        {
            return db.RoomNumbers;
        }

        // GET: api/RoomNumbers/5
        [ResponseType(typeof(RoomNumber))]
        public async Task<IHttpActionResult> GetRoomNumber(int id)
        {
            RoomNumber roomNumber = await db.RoomNumbers.FindAsync(id);
            if (roomNumber == null)
            {
                return NotFound();
            }

            return Ok(roomNumber);
        }

        // PUT: api/RoomNumbers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRoomNumber(int id, RoomNumber roomNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roomNumber.roomId)
            {
                return BadRequest();
            }

            db.Entry(roomNumber).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomNumberExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RoomNumbers
        [ResponseType(typeof(RoomNumber))]
        public async Task<IHttpActionResult> PostRoomNumber(RoomNumber roomNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RoomNumbers.Add(roomNumber);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = roomNumber.roomId }, roomNumber);
        }

        // DELETE: api/RoomNumbers/5
        [ResponseType(typeof(RoomNumber))]
        public async Task<IHttpActionResult> DeleteRoomNumber(int id)
        {
            RoomNumber roomNumber = await db.RoomNumbers.FindAsync(id);
            if (roomNumber == null)
            {
                return NotFound();
            }

            db.RoomNumbers.Remove(roomNumber);
            await db.SaveChangesAsync();

            return Ok(roomNumber);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoomNumberExists(int id)
        {
            return db.RoomNumbers.Count(e => e.roomId == id) > 0;
        }
    }
}