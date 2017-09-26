using IMSApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IMSApplication.Controllers
{
    public class aVendorsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/aVendors
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        public HttpResponseMessage Get([FromUri] string search)
        {
            List<Helper.Option> options = new List<Helper.Option>();
            var dbresults = db.Vendors.Where(v => v.Name.Contains(search) || v.Brand.Contains(search) || v.Id.ToString() == search).ToList();
            foreach (var row in dbresults)
            {
                string optionstext = row.Brand + " | " + row.Name;
                options.Add(new Helper.Option { id = row.Id.ToString(), text = optionstext });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { results = options });
        }
        // GET: api/aVendors/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/aVendors
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/aVendors/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/aVendors/5
        public void Delete(int id)
        {
        }
    }
}
