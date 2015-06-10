﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Tuincentrum1.Models;

namespace MVC_Tuincentrum1.Controllers
{
    public class LeverancierController : Controller
    {
        private MVCTuinCentrumEntities db = new MVCTuinCentrumEntities();

        // GET: Leverancier
        public ActionResult Index()
        {
            return View(db.Leveranciers.ToList());
        }

        // GET: Leverancier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leverancier leverancier = db.Leveranciers.Find(id);
            if (leverancier == null)
            {
                return HttpNotFound();
            }
            return View(leverancier);
        }

        // GET: Leverancier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Leverancier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LevNr,Naam,Adres,PostNr,Woonplaats")] Leverancier leverancier)
        {
            if (ModelState.IsValid)
            {
                db.Leveranciers.Add(leverancier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leverancier);
        }

        // GET: Leverancier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leverancier leverancier = db.Leveranciers.Find(id);
            if (leverancier == null)
            {
                return HttpNotFound();
            }
            return View(leverancier);
        }

        // POST: Leverancier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LevNr,Naam,Adres,PostNr,Woonplaats")] Leverancier leverancier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leverancier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leverancier);
        }

        // GET: Leverancier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leverancier leverancier = db.Leveranciers.Find(id);
            if (leverancier == null)
            {
                return HttpNotFound();
            }
            return View(leverancier);
        }

        // POST: Leverancier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Leverancier leverancier = db.Leveranciers.Find(id);
            db.Leveranciers.Remove(leverancier);
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
