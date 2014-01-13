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
        public ActionResult Index(string Id)
        {

            if (!String.IsNullOrEmpty(Id))
            {
                int ParsedID = Int32.Parse(Id);
                return View(db.Automoviles.Where(x => x.TipoAutomovil == ParsedID).ToList());
            }
            return View(db.Automoviles.ToList());
        }

        /// <summary>
        /// Retorna un Tipo de Automovil usando el Id de un Fabricante y el Id de un modelo.
        /// </summary>
        /// <param name="Fabricante">El Id del fabricante.</param>
        /// <param name="Modelo">El Id del modelo.</param>
        /// <returns></returns>
        public ActionResult Buscar(int Fabricante, int Modelo)
        {
            AutoDealerEntities db = new AutoDealerEntities();
            List<TiposAutomoviles> ListaTiposAutomoviles = new List<TiposAutomoviles>();
            ListaTiposAutomoviles = db.TiposAutomoviles.Where(x => x.Fabricante == Fabricante).ToList();
            ListaTiposAutomoviles = ListaTiposAutomoviles.Where(x => x.Modelo == Modelo).ToList();
            return View(ListaTiposAutomoviles.First());
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
            automoviles.Status = 1;
            string Year = FormData["Year"];
            string FormatedYear = "1/1/YYYY";
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
            automoviles.Status = 1;
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