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
    public class TiposGastoController : Controller
    {
        private AutoDealerEntities db = new AutoDealerEntities();

        //
        // GET: /TiposGasto/

        public ActionResult Index()
        {
            return View(db.TiposDeGastos.ToList());
        }

        //
        // GET: /TiposGasto/Details/5

        public ActionResult Details(int id = 0)
        {
            TiposDeGastos tiposdegastos = db.TiposDeGastos.Find(id);
            if (tiposdegastos == null)
            {
                return HttpNotFound();
            }
            return View(tiposdegastos);
        }

        //
        // GET: /TiposGasto/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TiposGasto/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TiposDeGastos tiposdegastos)
        {
            if (ModelState.IsValid)
            {
                db.TiposDeGastos.Add(tiposdegastos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tiposdegastos);
        }

        //
        // GET: /TiposGasto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TiposDeGastos tiposdegastos = db.TiposDeGastos.Find(id);
            if (tiposdegastos == null)
            {
                return HttpNotFound();
            }
            return View(tiposdegastos);
        }

        //
        // POST: /TiposGasto/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TiposDeGastos tiposdegastos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiposdegastos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tiposdegastos);
        }

        //
        // GET: /TiposGasto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TiposDeGastos tiposdegastos = db.TiposDeGastos.Find(id);
            if (tiposdegastos == null)
            {
                return HttpNotFound();
            }
            return View(tiposdegastos);
        }

        //
        // POST: /TiposGasto/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TiposDeGastos tiposdegastos = db.TiposDeGastos.Find(id);
            db.TiposDeGastos.Remove(tiposdegastos);
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