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
using System.Dynamic;

namespace IMSApps_v1.Controllers
{
    public class aColorsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/aColors
        public IQueryable<Color> GetColors()
        {
            return db.Colors;
        }

        public HttpResponseMessage Get([FromUri] string keyword)
        {
            var results = db.Colors.Where(c => c.Label.ToUpper().Contains(keyword.ToUpper())).ToList();
            List<object> options = new List<object>();
            if (results.Count == 0)
            {
                options.Add(new { id = keyword.ToUpper(), text = keyword.ToUpper() });
                return Request.CreateResponse(HttpStatusCode.OK, new { results = options});
            }
            foreach (var result in results)
            {
                options.Add(new { id = result.Id, text = result.Label.ToUpper() });
            }
            
            return Request.CreateResponse(HttpStatusCode.OK,new { results = options });
        }

        // PUT: api/aColors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutColor(int id, Color color)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != color.Id)
            {
                return BadRequest();
            }

            db.Entry(color).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorExists(id))
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

        // POST: api/aColors
        [ResponseType(typeof(Color))]
        public IHttpActionResult PostColor(Color color)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Colors.Add(color);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = color.Id }, color);
        }

        // DELETE: api/aColors/5
        [ResponseType(typeof(Color))]
        public IHttpActionResult DeleteColor(int id)
        {
            Color color = db.Colors.Find(id);
            if (color == null)
            {
                return NotFound();
            }

            db.Colors.Remove(color);
            db.SaveChanges();

            return Ok(color);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColorExists(int id)
        {
            return db.Colors.Count(e => e.Id == id) > 0;
        }
    }
}