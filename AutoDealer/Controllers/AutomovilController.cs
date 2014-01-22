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

        //public ActionResult Index()
        //{
        //    return View(db.Automoviles.ToList());
        //}
        //
        // GET: /Automovil/1
        public ActionResult Index(string Id, FormCollection FormData)
        {

            if (FormData.Keys.Count>0)
            {
                string Fabricante = FormData["Fabricantes"];
                string Modelo = FormData["Modelos"];
                int TipoAutomovil = TiposAutomoviles.GetTipoAutomovil(Fabricante, Modelo);
                return View(db.Automoviles.Where(x => x.TipoAutomovil == TipoAutomovil).ToList());
            }
            return View(db.Automoviles.Where(x=>x.Status==3).ToList());
        }






        /// <summary>
        /// Retorna una lista de Empresas.
        /// </summary>
        /// <returns></returns>
        public ActionResult EmpresasList()
        {
            List<Empresas> empresas = Empresas.GetEmpresas();

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(
                            empresas,
                            "Id",
                            "Nombre"), JsonRequestBehavior.AllowGet
                            );
            }

            return View(empresas);
        }

        /// <summary>
        /// Retorna la lista de Showrooms dada una empresa.
        /// </summary>
        /// <param name="Id">Id de la Empresa.</param>
        /// <returns>Lista de Showrooms.</Showrooms></returns>
        public ActionResult ShowroomsList(int Id)
        {
            List<Showrooms> showrooms = Showrooms.GetShowrooms(Id);

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(
                            showrooms,
                            "Id",
                            "Nombre"), JsonRequestBehavior.AllowGet
                            );
            }

            return View(showrooms);
        }



        /// <summary>
        /// Retorna la lista de Fabricantes.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Retorna la lista de Modelos dado un fabricante.
        /// </summary>
        /// <param name="Id">Id del fabricante.</param>
        /// <returns>Lista de Modelos.</Showrooms></returns>
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
        public ActionResult Create(Automoviles automoviles, FormCollection FormData)
        {
            automoviles.Showroom = Int32.Parse(FormData["Showrooms"]);
            automoviles.TipoAutomovil = TiposAutomoviles.GetTipoAutomovil(FormData["Fabricantes"], FormData["Modelos"]);
            automoviles.Suplidor = Int32.Parse(FormData["Suplidores"]);
            automoviles.FechaCreacion = DateTime.Now;
            automoviles.FechaEntrada = DateTime.Now;
            automoviles.Status = 1;
            string Year = FormData["Year"];
            string FormatedYear = "01/01/YYYY";
            FormatedYear = FormatedYear.Replace("YYYY", Year);
            automoviles.Year = DateTime.Parse(FormatedYear);
            //if (ModelState.IsValid)
            //{
                
                db.Automoviles.Add(automoviles);
                db.SaveChanges();
                return RedirectToAction("Index");
            //}

            //return View(automoviles);
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
        public ActionResult Edit(Automoviles automoviles, FormCollection FormData)
        {
            automoviles.Showroom = Int32.Parse(FormData["Showrooms"]);
            automoviles.TipoAutomovil = TiposAutomoviles.GetTipoAutomovil(FormData["Fabricantes"], FormData["Modelos"]);
            automoviles.Suplidor = Int32.Parse(FormData["Suplidores"]);
            automoviles.FechaCreacion = DateTime.Now;
            automoviles.FechaEntrada = DateTime.Now;
            automoviles.Status = 1;
            string Year = FormData["Year"];
            string FormatedYear = "01/01/YYYY";
            FormatedYear = FormatedYear.Replace("YYYY", Year);
            automoviles.Year = DateTime.Parse(FormatedYear);
            //if (ModelState.IsValid)
            //{

            db.Automoviles.Add(automoviles);
            db.SaveChanges();
            return RedirectToAction("Index");
            //return View(automoviles);
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
            automoviles.Status = 2;
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