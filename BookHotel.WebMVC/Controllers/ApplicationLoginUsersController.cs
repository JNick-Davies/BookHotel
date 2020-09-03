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
    public class ApplicationLoginUsersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ApplicationLoginUsers
        public IQueryable<ApplicationLoginUser> GetApplicationLoginUsers()
        {
            return db.ApplicationLoginUsers;
        }

        // GET: api/ApplicationLoginUsers/5
        [ResponseType(typeof(ApplicationLoginUser))]
        public async Task<IHttpActionResult> GetApplicationLoginUser(Guid id)
        {
            ApplicationLoginUser applicationLoginUser = await db.ApplicationLoginUsers.FindAsync(id);
            if (applicationLoginUser == null)
            {
                return NotFound();
            }

            return Ok(applicationLoginUser);
        }

        // PUT: api/ApplicationLoginUsers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutApplicationLoginUser(Guid id, ApplicationLoginUser applicationLoginUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applicationLoginUser.StaffIdLogin)
            {
                return BadRequest();
            }

            db.Entry(applicationLoginUser).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationLoginUserExists(id))
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

        // POST: api/ApplicationLoginUsers
        [ResponseType(typeof(ApplicationLoginUser))]
        public async Task<IHttpActionResult> PostApplicationLoginUser(ApplicationLoginUser applicationLoginUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ApplicationLoginUsers.Add(applicationLoginUser);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ApplicationLoginUserExists(applicationLoginUser.StaffIdLogin))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = applicationLoginUser.StaffIdLogin }, applicationLoginUser);
        }

        // DELETE: api/ApplicationLoginUsers/5
        [ResponseType(typeof(ApplicationLoginUser))]
        public async Task<IHttpActionResult> DeleteApplicationLoginUser(Guid id)
        {
            ApplicationLoginUser applicationLoginUser = await db.ApplicationLoginUsers.FindAsync(id);
            if (applicationLoginUser == null)
            {
                return NotFound();
            }

            db.ApplicationLoginUsers.Remove(applicationLoginUser);
            await db.SaveChangesAsync();

            return Ok(applicationLoginUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationLoginUserExists(Guid id)
        {
            return db.ApplicationLoginUsers.Count(e => e.StaffIdLogin == id) > 0;
        }
    }
}