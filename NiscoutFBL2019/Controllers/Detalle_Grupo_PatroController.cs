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
    public class Detalle_Grupo_PatroController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Detalle_Grupo_Patro
        public ActionResult Index(string searching)
        {
            var detalle_Grupo_Patros = db.Detalle_Grupo_Patros.Include(d => d.Patrocinador).Include(d => d.Grupo);

            if (!string.IsNullOrEmpty(searching))
            {
                detalle_Grupo_Patros = detalle_Grupo_Patros.Where(dgp => dgp.Patrocinador.Nombres.Contains(searching));
            }
            return View(detalle_Grupo_Patros.ToList());
           
        }

        // GET: Detalle_Grupo_Patro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Grupo_Patro detalle_Grupo_Patro = db.Detalle_Grupo_Patros.Find(id);
            if (detalle_Grupo_Patro == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Grupo_Patro);
        }

        // GET: Detalle_Grupo_Patro/Create
        public ActionResult Create()
        {
            ViewBag.PatrocinadorId = new SelectList(db.Patrocinadores, "Id", "Nombre_Insti");
            ViewBag.GrupoId = new SelectList(db.Grupos, "Id", "Nombre_Grupo");
            return View();
        }

        // POST: Detalle_Grupo_Patro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Desde,PatrocinadorId,Hasta,GrupoId")] Detalle_Grupo_Patro detalle_Grupo_Patro)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_Grupo_Patros.Add(detalle_Grupo_Patro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatrocinadorId = new SelectList(db.Patrocinadores, "Id", "Nombre_Insti", detalle_Grupo_Patro.PatrocinadorId);
            ViewBag.GrupoId = new SelectList(db.Grupos, "Id", "Nombre_Grupo", detalle_Grupo_Patro.GrupoId);
            return View(detalle_Grupo_Patro);
        }

        // GET: Detalle_Grupo_Patro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Grupo_Patro detalle_Grupo_Patro = db.Detalle_Grupo_Patros.Find(id);
            if (detalle_Grupo_Patro == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatrocinadorId = new SelectList(db.Patrocinadores, "Id", "Nombre_Insti", detalle_Grupo_Patro.PatrocinadorId);
            ViewBag.GrupoId = new SelectList(db.Grupos, "Id", "Nombre_Grupo", detalle_Grupo_Patro.GrupoId);
            return View(detalle_Grupo_Patro);
        }

        // POST: Detalle_Grupo_Patro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Desde,PatrocinadorId,Hasta,GrupoId")] Detalle_Grupo_Patro detalle_Grupo_Patro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_Grupo_Patro).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatrocinadorId = new SelectList(db.Patrocinadores, "Id", "Nombre_Insti", detalle_Grupo_Patro.PatrocinadorId);
            ViewBag.GrupoId = new SelectList(db.Grupos, "Id", "Nombre_Grupo", detalle_Grupo_Patro.GrupoId);
            return View(detalle_Grupo_Patro);
        }

        // GET: Detalle_Grupo_Patro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Grupo_Patro detalle_Grupo_Patro = db.Detalle_Grupo_Patros.Find(id);
            if (detalle_Grupo_Patro == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Grupo_Patro);
        }

        // POST: Detalle_Grupo_Patro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_Grupo_Patro detalle_Grupo_Patro = db.Detalle_Grupo_Patros.Find(id);
            db.Detalle_Grupo_Patros.Remove(detalle_Grupo_Patro);
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
