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

        /// <summary>
        /// Este metodo cuando recibe un parametro String hace una busqueda. Esta busqueda se hace tanto en el Nombre como en el Apellido.
        /// </summary>
        /// <param name="Buscar">String para buscar.</param>
        /// <returns>ActionResult</returns>
        public ActionResult Index(string Buscar)
        {
            var compradores = db.Compradores.Where(Compradores => Compradores.Status == 1);
            var compradoresapellidos = db.Compradores.Where(CompradoresApellidos => CompradoresApellidos.Status == 1);
            var compradoresunion = compradores;
            
            if (!String.IsNullOrEmpty(Buscar))
            {
                compradores = compradores.Where(Compradores => Compradores.Nombre.Contains(Buscar));
                compradoresapellidos = compradoresapellidos.Where(CompradoresApellidos => CompradoresApellidos.Apellido.Contains(Buscar));

                if (compradores.Count() > 0 && compradoresapellidos.Count() > 0)
                {
                    compradoresunion = compradores.Union(compradoresapellidos);  
                }
                else
                {
                    if (compradores.Count() > 0)
                    {
                        compradoresunion = compradores;
                    }
                    if (compradoresapellidos.Count() > 0)
                    {
                        compradoresunion = compradoresapellidos;
                    }
                }


            }
            return View(compradoresunion.ToList());
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
            if (ModelState.IsValid)
            {
                compradores.FechaCreacion = System.DateTime.Now;
                compradores.Status = 1;
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

            if (ModelState.IsValid)
            {
                db.Entry(compradores).State = EntityState.Modified;
                compradores.FechaModificacion = System.DateTime.Now;
                compradores.Status = 1;
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
            compradores.Status = 0;
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