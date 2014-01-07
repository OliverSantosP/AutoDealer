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
            return View(db.Automoviles.ToList());
        }

        public ActionResult FabricantesList()
        {
            List<Fabricantes> fabricantes = Fabricantes.GetFabricantes();

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(
                            fabricantes,
                            "Id",
                            "Nombre"), JsonRequestBehavior.AllowGet
                            );
            }

            return View(fabricantes);
        }

        public ActionResult ModelosList(int Id)
        {
            List<Modelos> modelos = Modelos.GetModelos(Id);

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(
                            modelos,
                            "Id",
                            "Nombre"), JsonRequestBehavior.AllowGet
                            );
            }

            return View(modelos);
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