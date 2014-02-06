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
    public class LiquidacionController : Controller
    {
        private AutoDealerEntities db = new AutoDealerEntities();

        //
        // GET: /Liquidacion/

        public ActionResult Index()
        {
            var liquidaciones = db.Liquidaciones.Include(l => l.Facturas).Include(l => l.Gastos1).Include(l => l.Personas).Include(l => l.Personas1);
            return View(liquidaciones.ToList());
        }

        //
        // GET: /Liquidacion/Details/5

        public ActionResult Details(int id = 0)
        {
            Liquidaciones liquidaciones = db.Liquidaciones.Find(id);
            if (liquidaciones == null)
            {
                return HttpNotFound();
            }
            return View(liquidaciones);
        }

        //
        // GET: /Liquidacion/Create

        public ActionResult Create()
        {
            ViewBag.Factura = new SelectList(db.Facturas, "Id", "NCF");
            ViewBag.Gastos = new SelectList(db.Gastos, "Id", "PagadoA");
            ViewBag.Comprador = new SelectList(db.Personas, "Id", "Nombre");
            ViewBag.Suplidor = new SelectList(db.Personas, "Id", "Nombre");
            return View();
        }

        //
        // POST: /Liquidacion/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Liquidaciones liquidaciones)
        {
            if (ModelState.IsValid)
            {
                db.Liquidaciones.Add(liquidaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Factura = new SelectList(db.Facturas, "Id", "NCF", liquidaciones.Factura);
            ViewBag.Gastos = new SelectList(db.Gastos, "Id", "PagadoA", liquidaciones.Gastos);
            ViewBag.Comprador = new SelectList(db.Personas, "Id", "Nombre", liquidaciones.Comprador);
            ViewBag.Suplidor = new SelectList(db.Personas, "Id", "Nombre", liquidaciones.Suplidor);
            return View(liquidaciones);
        }

        //
        // GET: /Liquidacion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Liquidaciones liquidaciones = db.Liquidaciones.Find(id);
            if (liquidaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Factura = new SelectList(db.Facturas, "Id", "NCF", liquidaciones.Factura);
            ViewBag.Gastos = new SelectList(db.Gastos, "Id", "PagadoA", liquidaciones.Gastos);
            ViewBag.Comprador = new SelectList(db.Personas, "Id", "Nombre", liquidaciones.Comprador);
            ViewBag.Suplidor = new SelectList(db.Personas, "Id", "Nombre", liquidaciones.Suplidor);
            return View(liquidaciones);
        }

        //
        // POST: /Liquidacion/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Liquidaciones liquidaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(liquidaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Factura = new SelectList(db.Facturas, "Id", "NCF", liquidaciones.Factura);
            ViewBag.Gastos = new SelectList(db.Gastos, "Id", "PagadoA", liquidaciones.Gastos);
            ViewBag.Comprador = new SelectList(db.Personas, "Id", "Nombre", liquidaciones.Comprador);
            ViewBag.Suplidor = new SelectList(db.Personas, "Id", "Nombre", liquidaciones.Suplidor);
            return View(liquidaciones);
        }

        //
        // GET: /Liquidacion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Liquidaciones liquidaciones = db.Liquidaciones.Find(id);
            if (liquidaciones == null)
            {
                return HttpNotFound();
            }
            return View(liquidaciones);
        }

        //
        // POST: /Liquidacion/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Liquidaciones liquidaciones = db.Liquidaciones.Find(id);
            db.Liquidaciones.Remove(liquidaciones);
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