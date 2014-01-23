﻿using System;
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
        public ActionResult Index(string Buscar,string TipoRol)
        {
            List<Personas> personas = new List<Personas>();
            List<Personas> personasapellidos = new List<Personas>();
            List<Personas> personasunion = new List<Personas>();

            if (!String.IsNullOrEmpty(TipoRol))
            {
                int TipoRolInt = Int32.Parse(TipoRol);
                List<PersonasRoles> Roles = new List<PersonasRoles>();
                Personas Personita = new Personas();
                Roles = db.PersonasRoles.Where(x => x.Rol == TipoRolInt).ToList();

                foreach (var item in Roles)
                {
                    Personita=db.Personas.Where(x=>x.Id==item.Persona).First();
                    personasapellidos.Add(Personita);
                    personas.Add(Personita);
                }

            }
            if (!String.IsNullOrEmpty(Buscar))
            {
                personas = personas.Where(Personas => Personas.Nombre.Contains(Buscar)).ToList();
                personasapellidos = personasapellidos.Where(PersonasApellidos => PersonasApellidos.Apellido.Contains(Buscar)).ToList();

                if (personas.Count() > 0 && personasapellidos.Count() > 0)
                {
                    personasunion = personas.Union(personasapellidos).ToList();
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
        public ActionResult Create(Personas personas,FormCollection formdata)
        {
            if (ModelState.IsValid)
            {
                
                personas.FechaCreacion = DateTime.Now;
                personas.Status = 1;
                db.Personas.Add(personas);
                db.SaveChanges();
                
                PersonasRoles Rol= new PersonasRoles();
                Rol.Persona = personas.Id;
                Rol.FechaCreacion = personas.FechaCreacion;
                Rol.Rol = Int32.Parse(formdata["Roles"].ToString());
                db.PersonasRoles.Add(Rol);
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
        public ActionResult Edit(Personas personas,FormCollection formdata)
        {
            if (ModelState.IsValid)
            {
                personas.FechaModificacion = DateTime.Now;
                personas.Status = 1;
                db.Entry(personas).State = EntityState.Modified;
                db.SaveChanges();

                PersonasRoles Rol = new PersonasRoles();
                Rol.Persona = personas.Id;
                Rol.FechaCreacion = personas.FechaCreacion;
                Rol.Rol = Int32.Parse(formdata["Roles"].ToString());
                db.PersonasRoles.Add(Rol);
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
            personas.Status = 2;
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