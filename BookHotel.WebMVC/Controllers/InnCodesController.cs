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
    public class InnCodesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/InnCodes
        public IQueryable<InnCode> GetInncodes()
        {
            return db.Inncodes;
        }

        // GET: api/InnCodes/5
        [ResponseType(typeof(InnCode))]
        public async Task<IHttpActionResult> GetInnCode(string id)
        {
            InnCode innCode = await db.Inncodes.FindAsync(id);
            if (innCode == null)
            {
                return NotFound();
            }

            return Ok(innCode);
        }

        // PUT: api/InnCodes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInnCode(string id, InnCode innCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != innCode.HotelInnCode)
            {
                return BadRequest();
            }

            db.Entry(innCode).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InnCodeExists(id))
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

        // POST: api/InnCodes
        [ResponseType(typeof(InnCode))]
        public async Task<IHttpActionResult> PostInnCode(InnCode innCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inncodes.Add(innCode);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InnCodeExists(innCode.HotelInnCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = innCode.HotelInnCode }, innCode);
        }

        // DELETE: api/InnCodes/5
        [ResponseType(typeof(InnCode))]
        public async Task<IHttpActionResult> DeleteInnCode(string id)
        {
            InnCode innCode = await db.Inncodes.FindAsync(id);
            if (innCode == null)
            {
                return NotFound();
            }

            db.Inncodes.Remove(innCode);
            await db.SaveChangesAsync();

            return Ok(innCode);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InnCodeExists(string id)
        {
            return db.Inncodes.Count(e => e.HotelInnCode == id) > 0;
        }
    }
}