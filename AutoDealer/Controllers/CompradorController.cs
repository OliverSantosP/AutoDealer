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
    public class CompradorController : Controller
    {
        private AutoDealerEntities db = new AutoDealerEntities();

        //
        // GET: /Comprador/

        public ActionResult Index()
        {
            return View(db.Compradores.Where(db.Compradores.Status==1).ToList());
        }

        //
        // GET: /Comprador/Details/5

        public ActionResult Details(int id = 0)
        {
            Compradores compradores = db.Compradores.Find(id);
            if (compradores == null)
            {
                return HttpNotFound();
            }
            return View(compradores);
        }

        //
        // GET: /Comprador/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Comprador/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Compradores compradores)
        {
            if (string.IsNullOrEmpty(compradores.Nombre))
                ModelState.AddModelError("name", "El nombre es obligatorio.");
            if (compradores.Celular.Length != 12)
                ModelState.AddModelError("celular", "El celular debe de tener 10 digitos. Ejemplo: 809-655-3434.");
            if (compradores.Telefono.Length != 12)
                ModelState.AddModelError("telefono", "El telefono debe de tener 10 digitos. Ejemplo: 809-655-3434.");
            if (ModelState.IsValid)
            {
                compradores.FechaCreacion = System.DateTime.Now;
                db.Compradores.Add(compradores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compradores);
        }

        //
        // GET: /Comprador/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Compradores compradores = db.Compradores.Find(id);
            if (compradores == null)
            {
                return HttpNotFound();
            }
            return View(compradores);
        }

        //
        // POST: /Comprador/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Compradores compradores)
        {
            if (string.IsNullOrEmpty(compradores.Nombre))
                ModelState.AddModelError("name", "El nombre es obligatorio.");
            if (compradores.Celular.Length != 12)
                ModelState.AddModelError("celular", "El celular debe de tener 10 digitos. Ejemplo: 809-655-3434.");
            if (compradores.Telefono.Length != 12)
                ModelState.AddModelError("telefono", "El telefono debe de tener 10 digitos. Ejemplo: 809-655-3434.");

            if (ModelState.IsValid)
            {
                db.Entry(compradores).State = EntityState.Modified;
                compradores.FechaModificacion = System.DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compradores);
        }

        //
        // GET: /Comprador/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Compradores compradores = db.Compradores.Find(id);
            if (compradores == null)
            {
                return HttpNotFound();
            }
            return View(compradores);
        }

        //
        // POST: /Comprador/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compradores compradores = db.Compradores.Find(id);
            db.Compradores.Remove(compradores);
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