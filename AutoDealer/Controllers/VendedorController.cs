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
    public class VendedorController : Controller
    {
        private AutoDealerEntities db = new AutoDealerEntities();

        //
        // GET: /Vendedor/

        /// <summary>
        /// Este metodo cuando recibe un parametro String hace una busqueda. Esta busqueda se hace tanto en el Nombre como en el Apellido.
        /// </summary>
        /// <param name="Buscar">String para buscar.</param>
        /// <returns>ActionResult</returns>
        public ActionResult Index(string Buscar)
        {
            var vendedores = db.Vendedores.Where(Vendedores => Vendedores.Status == 1);
            var vendedoresappelidos = db.Vendedores.Where(VendedoresApellidos => VendedoresApellidos.Status == 1);
            var vendedoresunion = vendedores;

            if (!String.IsNullOrEmpty(Buscar))
            {
                vendedores = vendedores.Where(Vendedores => Vendedores.Nombre.Contains(Buscar));
                vendedoresappelidos = vendedoresappelidos.Where(VendedoresApellidos => VendedoresApellidos.Apellido.Contains(Buscar));

                if (vendedores.Count() > 0 && vendedoresappelidos.Count() > 0)
                {
                    vendedoresunion = vendedores.Union(vendedoresappelidos);
                }
                else
                {
                    if (vendedores.Count() > 0)
                    {
                        vendedoresunion = vendedores;
                    }
                    if (vendedoresappelidos.Count() > 0)
                    {
                        vendedoresunion = vendedoresappelidos;
                    }
                }


            }
            return View(vendedoresunion.ToList());
        }

        //
        // GET: /Vendedor/Details/5

        public ActionResult Details(int id = 0)
        {
            Vendedores vendedores = db.Vendedores.Find(id);
            if (vendedores == null)
            {
                return HttpNotFound();
            }
            return View(vendedores);
        }

        //
        // GET: /Vendedor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Vendedor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vendedores vendedores)
        {
            if (string.IsNullOrEmpty(vendedores.Nombre))
                ModelState.AddModelError("name", "El nombre es obligatorio.");
            if (vendedores.Celular.Length != 12)
                ModelState.AddModelError("celular", "El celular debe de tener 10 digitos. Ejemplo: 809-655-3434.");
            if (vendedores.Telefono.Length != 12)
                ModelState.AddModelError("telefono", "El telefono debe de tener 10 digitos. Ejemplo: 809-655-3434.");

            if (ModelState.IsValid)
            {
                vendedores.FechaCreacion = System.DateTime.Now;
                vendedores.Status = 1;
                db.Vendedores.Add(vendedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendedores);
        }

        //
        // GET: /Vendedor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Vendedores vendedores = db.Vendedores.Find(id);
            if (vendedores == null)
            {
                return HttpNotFound();
            }
            return View(vendedores);
        }

        //
        // POST: /Vendedor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vendedores vendedores)
        {
            if (string.IsNullOrEmpty(vendedores.Nombre))
                ModelState.AddModelError("name", "El nombre es obligatorio.");
            if (vendedores.Celular.Length != 12)
                ModelState.AddModelError("celular", "El celular debe de tener 10 digitos. Ejemplo: 809-655-3434.");
            if (vendedores.Telefono.Length != 12)
                ModelState.AddModelError("telefono", "El telefono debe de tener 10 digitos. Ejemplo: 809-655-3434.");

            if (ModelState.IsValid)
            {
                vendedores.FechaModificacion = System.DateTime.Now;
                db.Entry(vendedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendedores);
        }

        //
        // GET: /Vendedor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Vendedores vendedores = db.Vendedores.Find(id);
            if (vendedores == null)
            {
                return HttpNotFound();
            }
            return View(vendedores);
        }

        //
        // POST: /Vendedor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendedores vendedores = db.Vendedores.Find(id);
            vendedores.Status = 0;
            vendedores.FechaModificacion = DateTime.Now;
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