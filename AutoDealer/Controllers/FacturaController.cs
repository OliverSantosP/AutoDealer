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
            return View(facturas.OrderByDescending(x=>x.FechaModificacion).ToList());
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

                facturas.Comprador = Comprador;
                facturas.Vendedor = Vendedor;
                
                List<int> ListaAutomoviles = new List<int>();
                for (int i = 0; i < FormData.Keys.Count; i++)
                {
                    if (FormData.Keys[i].Contains("Automovil"))
                    {
                        ListaAutomoviles.Add(Int32.Parse(FormData.Keys[i].Replace("AutomovilId", "")));
                    }
                }


                facturas.FechaCreacion = DateTime.Now;

                if (ModelState.IsValid)
                {
                    db.Facturas.Add(facturas);
                    db.SaveChanges();
                    foreach (var AutomovilId in ListaAutomoviles)
                    {
                        Automoviles Automovil = new Automoviles();
                        Automovil = db.Automoviles.Find(AutomovilId);
                        Automovil.Factura = facturas.Id;
                        db.Entry(Automovil).State = EntityState.Modified;
                    }

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

                ViewBag.Empresa = new SelectList(db.Empresas, "Id", "Nombre", facturas.Empresa);
                ViewBag.Comprador = new SelectList(db.Personas, "Id", "Nombre", facturas.Comprador);
                ViewBag.Vendedor = new SelectList(db.Personas, "Id", "Nombre", facturas.Vendedor);
                return View(facturas);
            }
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
        public ActionResult Edit(Facturas facturas, FormCollection FormData)
        {
            

            if (ModelState.IsValid)
            {
                facturas.FechaCreacion = Facturas.GetFactura(facturas.Id).FechaCreacion;
                facturas.FechaModificacion = DateTime.Now;
                facturas.Comprador = Int32.Parse(FormData["Compradores"]);
                facturas.Vendedor = Int32.Parse(FormData["Vendedores"]);

                db.Entry(facturas).State = EntityState.Modified;

                //Buscando todos los Automoviles que tienen esta factura.
                List<Automoviles> AutomovilesConFactura = new List<Automoviles>();
                AutomovilesConFactura = Automoviles.GetAutomovilOfFactura(facturas.Id);

                //Borrando el campo Factura a todos los Automoviles de esta factura.
                //Luego asignaremos el nuevo valor.
                foreach (var item in AutomovilesConFactura)
                {
                    Automoviles Automovil = new Automoviles();
                    Automovil = db.Automoviles.Find(item.Id);
                    Automovil.Factura = null;
                    db.Entry(Automovil).State = EntityState.Modified;
                }

                //Buscando todos los Automoviles que existen en esta factura al momento de editarla.
                for (int i = 0; i < FormData.Keys.Count; i++)
                {
                    if (FormData.Keys[i].Contains("Automovil"))
                    {
                        //Asigando el valor de Factura a los Automoviles.
                        Automoviles Automovil = new Automoviles();
                        Automovil = db.Automoviles.Find(Int32.Parse(FormData.Keys[i].Replace("AutomovilId", "")));
                        Automovil.Factura = facturas.Id;
                        db.Entry(Automovil).State = EntityState.Modified;
                    }

                }

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

            List<Automoviles> ListaAutomoviles = new List<Automoviles>();
            ListaAutomoviles = Automoviles.GetAutomovilOfFactura(id);

            foreach (var item in ListaAutomoviles)
            {
                Automoviles Automovil = new Automoviles();
                Automovil = db.Automoviles.Find(item.Id);
                Automovil.Factura = null;
                db.Entry(Automovil).State = EntityState.Modified;
            }
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