using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using IMSApps_v1.Models;

namespace IMSApps_v1.Controllers
{
    public class aSizesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/aSizes
        public IQueryable<Size> GetSizes()
        {
            return db.Sizes;
        }

        // GET: api/aSizes/5
        [ResponseType(typeof(Size))]
        public IHttpActionResult GetSize(int id)
        {
            Size size = db.Sizes.Find(id);
            if (size == null)
            {
                return NotFound();
            }

            return Ok(size);
        }

        public HttpResponseMessage Get([FromUri] string keyword)
        {
            var results = db.Sizes.Where(s => s.Label.ToUpper().Contains(keyword.ToUpper())).ToList();
            List<object> options = new List<object>();
            if (results.Count == 0)
            {
                options.Add(new { id = keyword.ToUpper(), text = keyword.ToUpper() });
            }
            else
            {
                foreach(var result in results)
                {
                    options.Add(new { id = result.Id, text = result.Label.ToUpper() });
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { results = options });
        }

        // PUT: api/aSizes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSize(int id, Size size)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != size.Id)
            {
                return BadRequest();
            }

            db.Entry(size).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizeExists(id))
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

        // POST: api/aSizes
        [ResponseType(typeof(Size))]
        public IHttpActionResult PostSize(Size size)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sizes.Add(size);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = size.Id }, size);
        }

        // DELETE: api/aSizes/5
        [ResponseType(typeof(Size))]
        public IHttpActionResult DeleteSize(int id)
        {
            Size size = db.Sizes.Find(id);
            if (size == null)
            {
                return NotFound();
            }

            db.Sizes.Remove(size);
            db.SaveChanges();

            return Ok(size);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SizeExists(int id)
        {
            return db.Sizes.Count(e => e.Id == id) > 0;
        }
    }
}