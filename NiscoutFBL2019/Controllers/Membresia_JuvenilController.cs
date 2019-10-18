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
    public class Membresia_JuvenilController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Membresia_Juvenil
        public ActionResult Index()
        {
            var membresia_Juveniles = db.Membresia_Juveniles.Include(m => m.Juvenil).Include(m => m.SubGrupo).Include(m => m.Tutor);
            return View(membresia_Juveniles.ToList());
        }

        // GET: Membresia_Juvenil/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membresia_Juvenil membresia_Juvenil = db.Membresia_Juveniles.Find(id);
            if (membresia_Juvenil == null)
            {
                return HttpNotFound();
            }
            return View(membresia_Juvenil);
        }

        // GET: Membresia_Juvenil/Create
        public ActionResult Create()
        {
            ViewBag.JuvenilId = new SelectList(db.Juveniles, "Id", "Id");
            ViewBag.SubGrupoId = new SelectList(db.SubGrupos, "Id", "Cod_Subgrupo");
            ViewBag.TutorId = new SelectList(db.Personas, "Id", "Cod_Persona");
            return View();
        }

        // POST: Membresia_Juvenil/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubGrupoId,JuvenilId,TutorId")] Membresia_Juvenil membresia_Juvenil)
        {
            if (ModelState.IsValid)
            {
                db.Membresia_Juveniles.Add(membresia_Juvenil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JuvenilId = new SelectList(db.Juveniles, "Id", "Id", membresia_Juvenil.JuvenilId);
            ViewBag.SubGrupoId = new SelectList(db.SubGrupos, "Id", "Cod_Subgrupo", membresia_Juvenil.SubGrupoId);
            ViewBag.TutorId = new SelectList(db.Personas, "Id", "Cod_Persona", membresia_Juvenil.TutorId);
            return View(membresia_Juvenil);
        }

        // GET: Membresia_Juvenil/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membresia_Juvenil membresia_Juvenil = db.Membresia_Juveniles.Find(id);
            if (membresia_Juvenil == null)
            {
                return HttpNotFound();
            }
            ViewBag.JuvenilId = new SelectList(db.Juveniles, "Id", "Id", membresia_Juvenil.JuvenilId);
            ViewBag.SubGrupoId = new SelectList(db.SubGrupos, "Id", "Cod_Subgrupo", membresia_Juvenil.SubGrupoId);
            ViewBag.TutorId = new SelectList(db.Personas, "Id", "Cod_Persona", membresia_Juvenil.TutorId);
            return View(membresia_Juvenil);
        }

        // POST: Membresia_Juvenil/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubGrupoId,JuvenilId,TutorId")] Membresia_Juvenil membresia_Juvenil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membresia_Juvenil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JuvenilId = new SelectList(db.Juveniles, "Id", "Id", membresia_Juvenil.JuvenilId);
            ViewBag.SubGrupoId = new SelectList(db.SubGrupos, "Id", "Cod_Subgrupo", membresia_Juvenil.SubGrupoId);
            ViewBag.TutorId = new SelectList(db.Personas, "Id", "Cod_Persona", membresia_Juvenil.TutorId);
            return View(membresia_Juvenil);
        }

        // GET: Membresia_Juvenil/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membresia_Juvenil membresia_Juvenil = db.Membresia_Juveniles.Find(id);
            if (membresia_Juvenil == null)
            {
                return HttpNotFound();
            }
            return View(membresia_Juvenil);
        }

        // POST: Membresia_Juvenil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Membresia_Juvenil membresia_Juvenil = db.Membresia_Juveniles.Find(id);
            db.Membresia_Juveniles.Remove(membresia_Juvenil);
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