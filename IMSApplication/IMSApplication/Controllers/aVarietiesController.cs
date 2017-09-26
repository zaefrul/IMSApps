using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IMSApplication.Models;

namespace IMSApplication.Controllers
{
    public class aVarietiesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/aVarieties
        public HttpResponseMessage Get([FromUri] string search)
        {
            List<Helper.Option> options = new List<Helper.Option>();
            var dbresults = db.Varieties.Where(v => v.Product.Name.Contains(search) || v.Id.ToString() == search).ToList();
            foreach (var row in dbresults)
            {
                string label = row.Product.Name + " | " + row.Size.Label + " | " + row.Color.Label;
                Helper.Option opt = new Helper.Option { id = row.Id.ToString(), text = label };
                options.Add(opt);
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { results = options });
        }

        // GET: api/aVarieties/5
        public HttpResponseMessage Get(int id)
        {
            var dbresults = db.Varieties.FirstOrDefault(v => v.Id == id);
            return Request.CreateResponse(HttpStatusCode.OK, new { Cost = dbresults.Product.Cost });
        }

        // POST: api/aVarieties
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/aVarieties/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/aVarieties/5
        public void Delete(int id)
        {
        }
    }
}
