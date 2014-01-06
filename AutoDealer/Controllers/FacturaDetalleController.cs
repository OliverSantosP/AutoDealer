using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoDealer.Models;

namespace AutoDealer.Controllers
{
    public class FacturaDetalleController : Controller
    {
        private AutoDealerEntities db = new AutoDealerEntities();

        //
        // GET: /FacturaDetalle/

        public ActionResult Index()
        {
            return View(db.FacturasDetalles.ToList());
        }

        //
        // GET: /FacturaDetalle/Details/5

        public ActionResult Details(int id = 0)
        {
            FacturasDetalles facturasdetalles = db.FacturasDetalles.Find(id);
            if (facturasdetalles == null)
            {
                return HttpNotFound();
            }
            return View(facturasdetalles);
        }

        //
        // GET: /FacturaDetalle/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /FacturaDetalle/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FacturasDetalles facturasdetalles)
        {
            if (ModelState.IsValid)
            {
                db.FacturasDetalles.Add(facturasdetalles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(facturasdetalles);
        }

        //
        // GET: /FacturaDetalle/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FacturasDetalles facturasdetalles = db.FacturasDetalles.Find(id);
            if (facturasdetalles == null)
            {
                return HttpNotFound();
            }
            return View(facturasdetalles);
        }

        //
        // POST: /FacturaDetalle/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FacturasDetalles facturasdetalles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturasdetalles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(facturasdetalles);
        }

        //
        // GET: /FacturaDetalle/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FacturasDetalles facturasdetalles = db.FacturasDetalles.Find(id);
            if (facturasdetalles == null)
            {
                return HttpNotFound();
            }
            return View(facturasdetalles);
        }

        //
        // POST: /FacturaDetalle/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FacturasDetalles facturasdetalles = db.FacturasDetalles.Find(id);
            db.FacturasDetalles.Remove(facturasdetalles);
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