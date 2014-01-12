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
    public class PersonaController : Controller
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
            var personas = db.Personas.Where(Personas => Personas.Status == 1);
            var personasapellidos = db.Personas.Where(PersonasApellidos => PersonasApellidos.Status == 1);
            var personasunion = personas;

            if (!String.IsNullOrEmpty(Buscar))
            {
                personas = personas.Where(Personas => Personas.Nombre.Contains(Buscar));
                personasapellidos = personasapellidos.Where(PersonasApellidos => PersonasApellidos.Apellido.Contains(Buscar));

                if (personas.Count() > 0 && personasapellidos.Count() > 0)
                {
                    personasunion = personas.Union(personasapellidos);
                }
                else
                {
                    if (personas.Count() > 0)
                    {
                        personasunion = personas;
                    }
                    if (personasapellidos.Count() > 0)
                    {
                        personasunion = personasapellidos;
                    }
                }


            }
            return View(personasunion.ToList());
        }
        //
        // GET: /Persona/Details/5

        public ActionResult Details(int id = 0)
        {
            Personas personas = db.Personas.Find(id);
            if (personas == null)
            {
                return HttpNotFound();
            }
            return View(personas);
        }

        //
        // GET: /Persona/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Persona/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Personas personas)
        {
            if (ModelState.IsValid)
            {
                personas.FechaCreacion = DateTime.Now;
                personas.Status = 1;
                db.Personas.Add(personas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personas);
        }

        //
        // GET: /Persona/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Personas personas = db.Personas.Find(id);
            if (personas == null)
            {
                return HttpNotFound();
            }
            return View(personas);
        }

        //
        // POST: /Persona/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Personas personas)
        {
            if (ModelState.IsValid)
            {
                personas.FechaModificacion = DateTime.Now;
                personas.Status = 1;
                db.Entry(personas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personas);
        }

        //
        // GET: /Persona/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Personas personas = db.Personas.Find(id);
            if (personas == null)
            {
                return HttpNotFound();
            }
            return View(personas);
        }

        //
        // POST: /Persona/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personas personas = db.Personas.Find(id);
            personas.Status = 0;
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