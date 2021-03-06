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
    public class Membresia_JuvenilController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Membresia_Juvenil
        public ActionResult Index(string buscar)
        {
            var membresia_Juveniles = db.Membresia_Juveniles.Include(m => m.SubGrupo).Include(m => m.Etapa_Aprobacion).Include(m => m.Juvenil).Include(m => m.Centro_Estudio);

            if (!string.IsNullOrEmpty(buscar))
            {
                membresia_Juveniles = membresia_Juveniles.Where(x => x.Juvenil.Nombres.Contains(buscar));
            }
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
            ViewBag.SubGrupoId = new SelectList(db.SubGrupos, "Id", "Nombre_Subgrupo");
            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Estado");
            ViewBag.JuvenilId = new SelectList(db.Juveniles, "Id", "Nombres");
            ViewBag.Centro_EstudioId = new SelectList(db.Centro_Estudios, "Id", "Nombre_Centro");
            return View();
        }

        // POST: Membresia_Juvenil/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubGrupoId,Etapa_AprobacionId,JuvenilId,Annio,Id,Turno,Grado,Nivel_Academico,Centro_EstudioId")] Membresia_Juvenil membresia_Juvenil)
        {
            if (ModelState.IsValid)
            {
                db.Membresia_Juveniles.Add(membresia_Juvenil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubGrupoId = new SelectList(db.SubGrupos, "Id", "Nombre_Subgrupo", membresia_Juvenil.SubGrupoId);
            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Estado", membresia_Juvenil.Etapa_AprobacionId);
            ViewBag.JuvenilId = new SelectList(db.Juveniles, "Id", "Nombres", membresia_Juvenil.JuvenilId);
            ViewBag.Centro_EstudioId = new SelectList(db.Centro_Estudios, "Id", "Nombre_Centro", membresia_Juvenil.Centro_EstudioId);
            return View(membresia_Juvenil);
        }

        // Nueva Vista --------------------------INICIO
        // GET: Membresia_Juvenil/Create
        [AllowAnonymous]
        public ActionResult MembreJuvenil()
        {
            ViewBag.SubGrupoId = new SelectList(db.SubGrupos, "Id", "Nombre_Subgrupo");
            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Estado");
            ViewBag.JuvenilId = new SelectList(db.Juveniles, "Id", "Nombres");
            ViewBag.Centro_EstudioId = new SelectList(db.Centro_Estudios, "Id", "Nombre_Centro");
            return View();
        }

        // POST: Membresia_Juvenil/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MembreJuvenil([Bind(Include = "SubGrupoId,Etapa_AprobacionId,Centro_EstudioId,Grado,Turno,Nivel_Academico,JuvenilId,Annio,Id")] Membresia_Juvenil membresia_Juvenil)
        {
            if (ModelState.IsValid)
            {
                db.Membresia_Juveniles.Add(membresia_Juvenil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubGrupoId = new SelectList(db.SubGrupos, "Id", "Nombre_Subgrupo", membresia_Juvenil.SubGrupoId);
            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Estado", membresia_Juvenil.Etapa_AprobacionId);
            ViewBag.JuvenilId = new SelectList(db.Juveniles, "Id", "Nombres", membresia_Juvenil.JuvenilId);
            ViewBag.Centro_EstudioId = new SelectList(db.Centro_Estudios, "Id", "Nombre_Centro", membresia_Juvenil.Centro_EstudioId);
            return View(membresia_Juvenil);
        }
        // ----------------------------------------FINAL
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
            ViewBag.SubGrupoId = new SelectList(db.SubGrupos, "Id", "Nombre_Subgrupo", membresia_Juvenil.SubGrupoId);
            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Estado", membresia_Juvenil.Etapa_AprobacionId);
            ViewBag.JuvenilId = new SelectList(db.Juveniles, "Id", "Nombres", membresia_Juvenil.JuvenilId);
            ViewBag.Centro_EstudioId = new SelectList(db.Centro_Estudios, "Id", "Nombre_Centro", membresia_Juvenil.Centro_EstudioId);
            return View(membresia_Juvenil);
        }

        // POST: Membresia_Juvenil/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubGrupoId,Etapa_AprobacionId,JuvenilId,Annio,Id,Turno,Grado,Nivel_Academico,Centro_EstudioId")] Membresia_Juvenil membresia_Juvenil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membresia_Juvenil).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubGrupoId = new SelectList(db.SubGrupos, "Id", "Nombre_Subgrupo", membresia_Juvenil.SubGrupoId);
            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Estado", membresia_Juvenil.Etapa_AprobacionId);
            ViewBag.JuvenilId = new SelectList(db.Juveniles, "Id", "Nombres", membresia_Juvenil.JuvenilId);
            ViewBag.Centro_EstudioId = new SelectList(db.Centro_Estudios, "Id", "Nombre_Centro", membresia_Juvenil.Centro_EstudioId);
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
