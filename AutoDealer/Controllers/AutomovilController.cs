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
    public class AutomovilController : Controller
    {
        private AutoDealerEntities db = new AutoDealerEntities();

        //
        // GET: /Automovil/

        public ActionResult Index()
        {
            var automoviles = db.Automoviles.Include(a => a.Facturas).Include(a => a.Liquidaciones1).Include(a => a.Showrooms).Include(a => a.Status1).Include(a => a.Suplidores);
            return View(automoviles.ToList());
        }

        //
        // GET: /Automovil/Details/5

        public ActionResult Details(int id = 0)
        {
            Automoviles automoviles = db.Automoviles.Find(id);
            if (automoviles == null)
            {
                return HttpNotFound();
            }
            return View(automoviles);
        }

        //
        // GET: /Automovil/Create

        public ActionResult Create()
        {
            ViewBag.Factura = new SelectList(db.Facturas, "Id", "NCF");
            ViewBag.Liquidaciones = new SelectList(db.Liquidaciones, "Id", "Id");
            ViewBag.Showroom = new SelectList(db.Showrooms, "Id", "Nombre");
            ViewBag.Status = new SelectList(db.Status, "Id", "Nombre");
            ViewBag.Suplidor = new SelectList(db.Suplidores, "Id", "Nombre");
            return View();
        }

        //
        // POST: /Automovil/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Automoviles automoviles)
        {
            if (ModelState.IsValid)
            {
                db.Automoviles.Add(automoviles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Factura = new SelectList(db.Facturas, "Id", "NCF", automoviles.Factura);
            ViewBag.Liquidaciones = new SelectList(db.Liquidaciones, "Id", "Id", automoviles.Liquidaciones);
            ViewBag.Showroom = new SelectList(db.Showrooms, "Id", "Nombre", automoviles.Showroom);
            ViewBag.Status = new SelectList(db.Status, "Id", "Nombre", automoviles.Status);
            ViewBag.Suplidor = new SelectList(db.Suplidores, "Id", "Nombre", automoviles.Suplidor);
            return View(automoviles);
        }

        //
        // GET: /Automovil/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Automoviles automoviles = db.Automoviles.Find(id);
            if (automoviles == null)
            {
                return HttpNotFound();
            }
            ViewBag.Factura = new SelectList(db.Facturas, "Id", "NCF", automoviles.Factura);
            ViewBag.Liquidaciones = new SelectList(db.Liquidaciones, "Id", "Id", automoviles.Liquidaciones);
            ViewBag.Showroom = new SelectList(db.Showrooms, "Id", "Nombre", automoviles.Showroom);
            ViewBag.Status = new SelectList(db.Status, "Id", "Nombre", automoviles.Status);
            ViewBag.Suplidor = new SelectList(db.Suplidores, "Id", "Nombre", automoviles.Suplidor);
            return View(automoviles);
        }

        //
        // POST: /Automovil/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Automoviles automoviles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automoviles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Factura = new SelectList(db.Facturas, "Id", "NCF", automoviles.Factura);
            ViewBag.Liquidaciones = new SelectList(db.Liquidaciones, "Id", "Id", automoviles.Liquidaciones);
            ViewBag.Showroom = new SelectList(db.Showrooms, "Id", "Nombre", automoviles.Showroom);
            ViewBag.Status = new SelectList(db.Status, "Id", "Nombre", automoviles.Status);
            ViewBag.Suplidor = new SelectList(db.Suplidores, "Id", "Nombre", automoviles.Suplidor);
            return View(automoviles);
        }

        //
        // GET: /Automovil/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Automoviles automoviles = db.Automoviles.Find(id);
            if (automoviles == null)
            {
                return HttpNotFound();
            }
            return View(automoviles);
        }

        //
        // POST: /Automovil/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Automoviles automoviles = db.Automoviles.Find(id);
            db.Automoviles.Remove(automoviles);
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