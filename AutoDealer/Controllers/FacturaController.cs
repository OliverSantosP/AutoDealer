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
    public class FacturaController : Controller
    {
        private AutoDealerEntities db = new AutoDealerEntities();

        //
        // GET: /Factura/

        public ActionResult Index()
        {
            var facturas = db.Facturas.Include(f => f.Compradores).Include(f => f.FacturasDetalles).Include(f => f.Vendedores);
            return View(facturas.ToList());
        }

        //
        // GET: /Factura/Details/5

        public ActionResult Details(int id = 0)
        {
            Facturas facturas = db.Facturas.Find(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            return View(facturas);
        }

        //
        // GET: /Factura/Create

        public ActionResult Create()
        {
            ViewBag.Comprador = new SelectList(db.Compradores, "Id", "Nombre");
            ViewBag.Detalle = new SelectList(db.FacturasDetalles, "Id", "Descripcion");
            ViewBag.Vendedor = new SelectList(db.Vendedores, "Id", "Nombre");
            return View();
        }

        //
        // POST: /Factura/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Facturas facturas)
        {
            if (ModelState.IsValid)
            {
                db.Facturas.Add(facturas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Comprador = new SelectList(db.Compradores, "Id", "Nombre", facturas.Comprador);
            ViewBag.Detalle = new SelectList(db.FacturasDetalles, "Id", "Descripcion", facturas.Detalle);
            ViewBag.Vendedor = new SelectList(db.Vendedores, "Id", "Nombre", facturas.Vendedor);
            return View(facturas);
        }

        //
        // GET: /Factura/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Facturas facturas = db.Facturas.Find(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Comprador = new SelectList(db.Compradores, "Id", "Nombre", facturas.Comprador);
            ViewBag.Detalle = new SelectList(db.FacturasDetalles, "Id", "Descripcion", facturas.Detalle);
            ViewBag.Vendedor = new SelectList(db.Vendedores, "Id", "Nombre", facturas.Vendedor);
            return View(facturas);
        }

        //
        // POST: /Factura/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Facturas facturas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Comprador = new SelectList(db.Compradores, "Id", "Nombre", facturas.Comprador);
            ViewBag.Detalle = new SelectList(db.FacturasDetalles, "Id", "Descripcion", facturas.Detalle);
            ViewBag.Vendedor = new SelectList(db.Vendedores, "Id", "Nombre", facturas.Vendedor);
            return View(facturas);
        }

        //
        // GET: /Factura/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Facturas facturas = db.Facturas.Find(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            return View(facturas);
        }

        //
        // POST: /Factura/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Facturas facturas = db.Facturas.Find(id);
            db.Facturas.Remove(facturas);
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