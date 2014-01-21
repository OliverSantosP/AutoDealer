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
    public class ShowroomController : Controller
    {
        private AutoDealerEntities db = new AutoDealerEntities();

        //
        // GET: /Showroom/

        public ActionResult Index()
        {
            var showrooms = db.Showrooms.Include(s => s.Empresas);
            return View(showrooms.ToList());
        }

        //
        // GET: /Showroom/Details/5

        public ActionResult Details(int id = 0)
        {
            Showrooms showrooms = db.Showrooms.Find(id);
            if (showrooms == null)
            {
                return HttpNotFound();
            }
            return View(showrooms);
        }

        //
        // GET: /Showroom/Create

        public ActionResult Create()
        {
            ViewBag.Empresa = new SelectList(db.Empresas, "Id", "Nombre");
            return View();
        }

        //
        // POST: /Showroom/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Showrooms showrooms, FormCollection FormData)
        {
            if (FormData["Empresas"] != "0")
            {
                showrooms.Empresa = Int32.Parse(FormData["Empresas"]);
                showrooms.FechaCreacion = DateTime.Now;

                //if (ModelState.IsValid)

                db.Showrooms.Add(showrooms);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
            //ViewBag.Empresa = new SelectList(db.Empresas, "Id", "Nombre", showrooms.Empresa);
            //return View(showrooms);
        }

        //
        // GET: /Showroom/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Showrooms showrooms = db.Showrooms.Find(id);
            if (showrooms == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empresa = new SelectList(db.Empresas, "Id", "Nombre", showrooms.Empresa);
            return View(showrooms);
        }

        //
        // POST: /Showroom/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Showrooms showrooms, FormCollection FormData)
        {
            if (ModelState.IsValid)
            {
                showrooms.FechaModificacion = DateTime.Now;
                if (!String.IsNullOrEmpty(FormData["Empresa"]))
                {
                    showrooms.Empresa = Int32.Parse(FormData["Empresa"]);
                }
                db.Entry(showrooms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empresa = new SelectList(db.Empresas, "Id", "Nombre", showrooms.Empresa);
            return View(showrooms);
        }

        //
        // GET: /Showroom/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Showrooms showrooms = db.Showrooms.Find(id);
            if (showrooms == null)
            {
                return HttpNotFound();
            }
            return View(showrooms);
        }

        //
        // POST: /Showroom/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Showrooms showrooms = db.Showrooms.Find(id);
            db.Showrooms.Remove(showrooms);
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