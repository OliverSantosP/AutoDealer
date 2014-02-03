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
    public class GastoController : Controller
    {
        private AutoDealerEntities db = new AutoDealerEntities();

        //
        // GET: /Gasto/

        public ActionResult Index(string AutomovilId,  FormCollection Form)
        {
            var gastos = db.Gastos.Include(g => g.TiposDeGastos);
            
            if (!String.IsNullOrEmpty(AutomovilId))
            {
                int AutomovilIdInt =Int32.Parse(AutomovilId);
                gastos = db.Gastos.Include(g => g.TiposDeGastos).Where(x => x.Automovil == AutomovilIdInt);
                return View(gastos.ToList());
            }
            else

            {
                if (Form.Count>0)
                {
                    if (Form["Desde"]!="" && Form["Hasta"]!="")
                    {
                        DateTime DesdeDT = DateTime.Parse(Form["Desde"]);
                        DateTime HastaDT = DateTime.Parse(Form["Hasta"]);
                        ViewBag.Total = AutoDealer.Models.Gastos.TotalGastos(DesdeDT, HastaDT);
                        return View(gastos.Where(x => x.FechaCreacion >= DesdeDT && x.FechaCreacion <= HastaDT).ToList());
                    }  
                }
                
            }

            return View(gastos.ToList());
        }

        //
        // GET: /Gasto/Details/5

        public ActionResult Details(int id = 0)
        {
            Gastos gastos = db.Gastos.Find(id);
            if (gastos == null)
            {
                return HttpNotFound();
            }
            return View(gastos);
        }

        //
        // GET: /Gasto/Create

        public ActionResult Create()
        {
            ViewBag.Tipo = new SelectList(db.TiposDeGastos, "Id", "Nombre");
            return View();
        }

        //
        // POST: /Gasto/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gastos gastos)
        {
            if (ModelState.IsValid)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["AutomovilId"]))
                { gastos.Automovil = Int32.Parse(Request.QueryString["AutomovilId"]);}
                
                gastos.FechaCreacion = DateTime.Now;
                db.Gastos.Add(gastos);
                db.SaveChanges();
                return Redirect("?AutomovilId=" + Request.QueryString["AutomovilId"]);
            }

            ViewBag.Tipo = new SelectList(db.TiposDeGastos, "Id", "Nombre", gastos.Tipo);
            return View(gastos);
        }

        //
        // GET: /Gasto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Gastos gastos = db.Gastos.Find(id);
            if (gastos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo = new SelectList(db.TiposDeGastos, "Id", "Nombre", gastos.Tipo);
            return View(gastos);
        }

        //
        // POST: /Gasto/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gastos gastos)
        {
            if (ModelState.IsValid)
            {
                gastos.FechaModificacion = DateTime.Now;
                db.Entry(gastos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo = new SelectList(db.TiposDeGastos, "Id", "Nombre", gastos.Tipo);
            return View(gastos);
        }

        //
        // GET: /Gasto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Gastos gastos = db.Gastos.Find(id);
            if (gastos == null)
            {
                return HttpNotFound();
            }
            return View(gastos);
        }

        //
        // POST: /Gasto/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gastos gastos = db.Gastos.Find(id);
            db.Gastos.Remove(gastos);
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