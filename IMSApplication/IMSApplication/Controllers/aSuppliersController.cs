using IMSApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IMSApplication.Controllers
{
    public class aSuppliersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/aSuppliers
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public HttpResponseMessage Get([FromUri] string search)
        {
            List<Helper.Option> options = new List<Helper.Option>();
            var dbresults = db.Suppliers.Where(s => s.Name.Contains(search) || s.Id.ToString() == search).ToList();
            foreach(var row in dbresults)
            {
                options.Add(new Helper.Option { id = row.Id.ToString(), text = row.Name });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { results = options });
        }

        // GET: api/aSuppliers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/aSuppliers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/aSuppliers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/aSuppliers/5
        public void Delete(int id)
        {
        }
    }
}
