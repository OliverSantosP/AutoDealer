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
            var facturas = db.Facturas.Include(f => f.Empresas).Include(f => f.Personas).Include(f => f.Personas1);
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
            ViewBag.Empresa = new SelectList(db.Empresas, "Id", "Nombre");
            ViewBag.Comprador = new SelectList(db.Personas, "Id", "Nombre");
            ViewBag.Vendedor = new SelectList(db.Personas, "Id", "Nombre");
            return View();
        }

        //
        // POST: /Factura/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Facturas facturas, FormCollection FormData)
        {
            if (FormData.Keys.Count > 0)
            {
                int Comprador = Int32.Parse(FormData["Compradores"]);
                int Vendedor = Int32.Parse(FormData["Vendedores"]);
                int Automovil = Int32.Parse(Request.QueryString["AutomovilId"]);
                facturas.Comprador = Comprador;
                facturas.Vendedor = Vendedor;
            }
            facturas.FechaCreacion = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Facturas.Add(facturas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empresa = new SelectList(db.Empresas, "Id", "Nombre", facturas.Empresa);
            ViewBag.Comprador = new SelectList(db.Personas, "Id", "Nombre", facturas.Comprador);
            ViewBag.Vendedor = new SelectList(db.Personas, "Id", "Nombre", facturas.Vendedor);
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
            ViewBag.Empresa = new SelectList(db.Empresas, "Id", "Nombre", facturas.Empresa);
            ViewBag.Comprador = new SelectList(db.Personas, "Id", "Nombre", facturas.Comprador);
            ViewBag.Vendedor = new SelectList(db.Personas, "Id", "Nombre", facturas.Vendedor);
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
            ViewBag.Empresa = new SelectList(db.Empresas, "Id", "Nombre", facturas.Empresa);
            ViewBag.Comprador = new SelectList(db.Personas, "Id", "Nombre", facturas.Comprador);
            ViewBag.Vendedor = new SelectList(db.Personas, "Id", "Nombre", facturas.Vendedor);
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