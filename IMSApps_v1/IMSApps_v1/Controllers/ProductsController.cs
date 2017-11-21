using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IMSApps_v1.Models;
using IMSApps_v1.Helper;

namespace IMSApps_v1.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Include(P => P.Varieties).FirstOrDefault(P => P.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,Category,Cost,Sell,Description,Status,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Products.Add(product);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(product);
        //}
        [HttpPost]
        public ActionResult Create(FormCollection fc)
        {
            //Validation
            Product p = new Product();
            p.Name = Request.Form["Name"];
            p.Description = Request.Form["Description"];
            p.Category = Request.Form["Category"];
            p.Cost = Double.Parse(Request.Form["Cost"]);
            p.Sell = Double.Parse(Request.Form["Sell"]);
            p.CreatedBy = System.Web.HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
            p.ModifiedBy = System.Web.HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
            p.CreatedDate = DateTime.Now;
            p.ModifiedDate = DateTime.Now;
            string[] color = Request.Form["colors[]"].Split(',');
            string[] size = Request.Form["sizes[]"].Split(',');
            string[] qty = Request.Form["qtys[]"].Split(',');
            List<Variety> varieties = new List<Variety>();
            for (int i = 0; i < color.Length; i++)
            {
                var v = new Variety();
                if (Validator.IsNumber(color[i]))
                {
                    v.ColorId = int.Parse(color[i]);
                }
                else
                {
                    Color c = new Color()
                    {
                        Label = color[i],
                        CreatedBy = System.Web.HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = System.Web.HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name,
                        ModifiedDate = DateTime.Now
                    };
                    v.Color = c;
                }

                if (Validator.IsNumber(size[i]))
                {
                    v.SizeId = int.Parse(size[i]);
                }
                else
                {
                    Size s = new Size()
                    {
                        Label = size[i],
                        CreatedBy = System.Web.HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = System.Web.HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name,
                        ModifiedDate = DateTime.Now
                    };
                    v.Size = s;
                }
                v.Quantity = int.Parse(qty[i]);
                v.CreatedBy = System.Web.HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
                v.ModifiedBy = System.Web.HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
                v.CreatedDate = DateTime.Now;
                v.ModifiedDate = DateTime.Now;

                varieties.Add(v);
            }
            if (Validator.Product(Request))
            {
                p.Varieties = varieties;
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(p);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Include(p => p.Varieties).FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //// POST: Products/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,Category,Cost,Sell,Description,Status,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(product).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(product);
        //}
        [HttpPost]
        public ActionResult Edit(FormCollection fc)
        {
            //Validation
            Product p = new Product();
            p.Name = Request.Form["Name"];
            p.Description = Request.Form["Description"];
            p.Category = Request.Form["Category"];
            p.Cost = Double.Parse(Request.Form["Cost"]);
            p.Sell = Double.Parse(Request.Form["Sell"]);
            p.CreatedBy = System.Web.HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
            p.ModifiedBy = System.Web.HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
            p.CreatedDate = DateTime.Now;
            p.ModifiedDate = DateTime.Now;
            string[] color = Request.Form["colors[]"].Split(',');
            string[] size = Request.Form["sizes[]"].Split(',');
            string[] qty = Request.Form["qtys[]"].Split(',');
            List<Variety> varieties = new List<Variety>();
            for (int i = 0; i < color.Length; i++)
            {
                var v = new Variety();
                if (Validator.IsNumber(color[i]))
                {
                    v.ColorId = int.Parse(color[i]);
                }
                else
                {
                    Color c = new Color()
                    {
                        Label = color[i],
                        CreatedBy = System.Web.HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = System.Web.HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name,
                        ModifiedDate = DateTime.Now
                    };
                    v.Color = c;
                }

                if (Validator.IsNumber(size[i]))
                {
                    v.SizeId = int.Parse(size[i]);
                }
                else
                {
                    Size s = new Size()
                    {
                        Label = size[i],
                        CreatedBy = System.Web.HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = System.Web.HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name,
                        ModifiedDate = DateTime.Now
                    };
                    v.Size = s;
                }
                v.Quantity = int.Parse(qty[i]);
                v.CreatedBy = System.Web.HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
                v.ModifiedBy = System.Web.HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
                v.CreatedDate = DateTime.Now;
                v.ModifiedDate = DateTime.Now;

                varieties.Add(v);
            }
            if (Validator.Product(Request))
            {
                p.Varieties = varieties;
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(p);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
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
