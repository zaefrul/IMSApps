﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IMSApplication.Models;

namespace IMSApplication.Controllers
{
    public class SalesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sales
        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.Channel).Include(s => s.Receipt).Include(s => s.Variety);
            return View(sales.ToList());
        }

        // GET: Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            return View(sales);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            ViewBag.ChannelId = new SelectList(db.Channels, "Id", "Label");
            ViewBag.ReceiptId = new SelectList(db.Receipts, "Id", "Method");
            ViewBag.VarietyId = new SelectList(db.Varieties, "Id", "Id");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,VarietyId,ReceiptId,Salesperson,Quantity,Price,ChannelId")] Sales sales)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(sales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChannelId = new SelectList(db.Channels, "Id", "Label", sales.ChannelId);
            ViewBag.ReceiptId = new SelectList(db.Receipts, "Id", "Method", sales.ReceiptId);
            ViewBag.VarietyId = new SelectList(db.Varieties, "Id", "Id", sales.VarietyId);
            return View(sales);
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChannelId = new SelectList(db.Channels, "Id", "Label", sales.ChannelId);
            ViewBag.ReceiptId = new SelectList(db.Receipts, "Id", "Method", sales.ReceiptId);
            ViewBag.VarietyId = new SelectList(db.Varieties, "Id", "Id", sales.VarietyId);
            return View(sales);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,VarietyId,ReceiptId,Salesperson,Quantity,Price,ChannelId")] Sales sales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChannelId = new SelectList(db.Channels, "Id", "Label", sales.ChannelId);
            ViewBag.ReceiptId = new SelectList(db.Receipts, "Id", "Method", sales.ReceiptId);
            ViewBag.VarietyId = new SelectList(db.Varieties, "Id", "Id", sales.VarietyId);
            return View(sales);
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            return View(sales);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sales sales = db.Sales.Find(id);
            db.Sales.Remove(sales);
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
