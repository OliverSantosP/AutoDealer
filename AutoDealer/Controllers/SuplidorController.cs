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
    public class SuplidorController : Controller
    {
        private AutoDealerEntities db = new AutoDealerEntities();

        //
        // GET: /Suplidor/

        // <summary>
        /// Este metodo cuando recibe un parametro String hace una busqueda. Esta busqueda se hace tanto en el Nombre como en el Apellido.
        /// </summary>
        /// <param name="Buscar">String para buscar.</param>
        /// <returns>ActionResult</returns>
        public ActionResult Index(string Buscar)
        {
            var suplidores = db.Suplidores.Where(Suplidores => Suplidores.Status == 1);
            var suplidoresapellidos = db.Suplidores.Where(SuplidorApellidos => SuplidorApellidos.Status == 1);
            var suplidoresunion = suplidores;

            if (!String.IsNullOrEmpty(Buscar))
            {
                suplidores = suplidores.Where(Suplidores => Suplidores.Nombre.Contains(Buscar));
                suplidoresapellidos = suplidoresapellidos.Where(SuplidorApellidos => SuplidorApellidos.Apellido.Contains(Buscar));

                if (suplidores.Count() > 0 && suplidoresapellidos.Count() > 0)
                {
                    suplidoresapellidos = suplidores.Union(suplidoresapellidos);
                }
                else
                {
                    if (suplidores.Count() > 0)
                    {
                        suplidoresunion = suplidores;
                    }
                    if (suplidoresapellidos.Count() > 0)
                    {
                        suplidoresunion = suplidoresapellidos;
                    }

                }


            }
            return View(suplidoresunion.ToList());
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
                suplidores.Status = 1;
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
                suplidores.FechaModificacion = DateTime.Now;
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
            suplidores.Status = 0;
            suplidores.FechaModificacion = DateTime.Now;
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