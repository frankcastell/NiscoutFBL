﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NiscoutFBL2019.Models;

namespace NiscoutFBL2019.Controllers
{
    [Authorize]
    public class PeriodoesController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Periodoes
        public ActionResult Index( string buscar)
        {
            var periodos = db.Periodos.Include(p => p.Responsable);

            var responsables = db.Responsables.Include(r => r.Departamento);

            if (!string.IsNullOrEmpty(buscar))
            {
                responsables = responsables.Where(s => s.Nombres.Contains(buscar));
            }
            return View(periodos.ToList());
        }

        // GET: Periodoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodo periodo = db.Periodos.Find(id);
            if (periodo == null)
            {
                return HttpNotFound();
            }
            return View(periodo);
        }

        // GET: Periodoes/Create
        public ActionResult Create()
        {
            ViewBag.ResponsableId = new SelectList(db.Personas, "Id", "Nombres");
            return View();
        }

        // POST: Periodoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Desde,Hasta,ResponsableId")] Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                db.Periodos.Add(periodo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResponsableId = new SelectList(db.Personas, "Id", "Nombres", periodo.ResponsableId);
            return View(periodo);
        }

        // GET: Periodoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodo periodo = db.Periodos.Find(id);
            if (periodo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResponsableId = new SelectList(db.Personas, "Id", "Nombres", periodo.ResponsableId);
            return View(periodo);
        }

        // POST: Periodoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Desde,Hasta,ResponsableId")] Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periodo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResponsableId = new SelectList(db.Personas, "Id", "Nombres", periodo.ResponsableId);
            return View(periodo);
        }

        // GET: Periodoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodo periodo = db.Periodos.Find(id);
            if (periodo == null)
            {
                return HttpNotFound();
            }
            return View(periodo);
        }

        // POST: Periodoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Periodo periodo = db.Periodos.Find(id);
            db.Periodos.Remove(periodo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
