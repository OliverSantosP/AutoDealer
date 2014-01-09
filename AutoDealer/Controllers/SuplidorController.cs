﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoDealer.Models;

namespace AutoDealer.Controllers
{
    public class SuplidorController : Controller
    {
        private AutoDealerEntities db = new AutoDealerEntities();

        //
        // GET: /Suplidor/

        public ActionResult Index()
        {
            return View(db.Suplidores.ToList());
        }

        //
        // GET: /Suplidor/Details/5

        public ActionResult Details(int id = 0)
        {
            Suplidores suplidores = db.Suplidores.Find(id);
            if (suplidores == null)
            {
                return HttpNotFound();
            }
            return View(suplidores);
        }

        //
        // GET: /Suplidor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Suplidor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Suplidores suplidores)
        {
            if (ModelState.IsValid)
            {
                db.Suplidores.Add(suplidores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suplidores);
        }

        //
        // GET: /Suplidor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Suplidores suplidores = db.Suplidores.Find(id);
            if (suplidores == null)
            {
                return HttpNotFound();
            }
            return View(suplidores);
        }

        //
        // POST: /Suplidor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Suplidores suplidores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suplidores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suplidores);
        }

        //
        // GET: /Suplidor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Suplidores suplidores = db.Suplidores.Find(id);
            if (suplidores == null)
            {
                return HttpNotFound();
            }
            return View(suplidores);
        }

        //
        // POST: /Suplidor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suplidores suplidores = db.Suplidores.Find(id);
            db.Suplidores.Remove(suplidores);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}