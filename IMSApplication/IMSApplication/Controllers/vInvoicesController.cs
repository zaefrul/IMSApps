using IMSApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMSApplication.Controllers
{
    public class vInvoicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: vInvoices
        public ActionResult Index()
        {
            return View();
        }

        // GET: vInvoices/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Invoices.Find(id));
        }

        // GET: vInvoices/Create
        public ActionResult Create()
        {
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name");
            ViewBag.VendorId = new SelectList(db.Vendors, "Id", "Brand");
            ViewBag.VarietyId = new SelectList(db.Varieties, "Id", "Id");
            return View();
        }

        // POST: vInvoices/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // Create InvoiceItems Collection
                var varietiesid = Request.Form["varieties[]"].Split(',');
                var qtys = Request.Form["qtys[]"].Split(',');
                var costs = Request.Form["cost[]"].Split(',');
                var total = Request.Form["total[]"].Split(',');
                List<InvoiceItem> items = new List<InvoiceItem>();
                for(int i=0; i<varietiesid.Length; i++)
                {
                    items.Add(new InvoiceItem {
                        Price = Double.Parse(costs[i]),
                        Quantity = int.Parse(qtys[i]),
                        Total = Double.Parse(total[i]),
                        VarietyId = int.Parse(varietiesid[i])
                    });
                }
                // Create Invoice and associate it with invoice items
                var reference = Request.Form["Number"];
                var date = Request.Form["Date"];
                var supplierId = Request.Form["SupplierId"];
                var vendorId = Request.Form["VendorId"];
                var type = Request.Form["Type"];
                Invoice inv = new Invoice()
                {
                    Date = DateTime.Parse(date),
                    SupplierId = int.Parse(supplierId),
                    VendorId = int.Parse(vendorId),
                    Number = reference,
                    Type = type,
                    Items = items
                };
                db.Invoices.Add(inv);
                db.SaveChanges();
                return RedirectToAction("Index", "Invoices");
            }
            catch
            {
                return View();
            }
        }

        // GET: vInvoices/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: vInvoices/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: vInvoices/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: vInvoices/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
