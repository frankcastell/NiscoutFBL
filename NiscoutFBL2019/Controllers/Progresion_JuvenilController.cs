using System;
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
    public class Progresion_JuvenilController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Progresion_Juvenil
        public ActionResult Index()
        {
            var progresion_Juveniles = db.Progresion_Juveniles.Include(p => p.Membresia_Juvenil);
            return View(progresion_Juveniles.ToList());
        }

        // GET: Progresion_Juvenil/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Progresion_Juvenil progresion_Juvenil = db.Progresion_Juveniles.Find(id);
            if (progresion_Juvenil == null)
            {
                return HttpNotFound();
            }
            return View(progresion_Juvenil);
        }

        // GET: Progresion_Juvenil/Create
        public ActionResult Create()
        {
            ViewBag.Membresia_JuvenilId = new SelectList(db.Membresia_Juveniles, "Id", "Id");
            
            return View();
        }

        // POST: Progresion_Juvenil/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Etapa_Prog,Descripcion_Etapa,Membresia_JuvenilId")] Progresion_Juvenil progresion_Juvenil)
        {
            if (ModelState.IsValid)
            {
                db.Progresion_Juveniles.Add(progresion_Juvenil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Membresia_JuvenilId = new SelectList(db.Membresia_Juveniles, "Id", "Id", progresion_Juvenil.Membresia_JuvenilId);
            return View(progresion_Juvenil);
        }

        // GET: Progresion_Juvenil/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Progresion_Juvenil progresion_Juvenil = db.Progresion_Juveniles.Find(id);
            if (progresion_Juvenil == null)
            {
                return HttpNotFound();
            }
            ViewBag.Membresia_JuvenilId = new SelectList(db.Membresia_Juveniles, "Id", "Id", progresion_Juvenil.Membresia_JuvenilId);
            return View(progresion_Juvenil);
        }

        // POST: Progresion_Juvenil/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Etapa_Prog,Descripcion_Etapa,Membresia_JuvenilId")] Progresion_Juvenil progresion_Juvenil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(progresion_Juvenil).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Membresia_JuvenilId = new SelectList(db.Membresia_Juveniles, "Id", "Id", progresion_Juvenil.Membresia_JuvenilId);
            return View(progresion_Juvenil);
        }

        // GET: Progresion_Juvenil/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Progresion_Juvenil progresion_Juvenil = db.Progresion_Juveniles.Find(id);
            if (progresion_Juvenil == null)
            {
                return HttpNotFound();
            }
            return View(progresion_Juvenil);
        }

        // POST: Progresion_Juvenil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Progresion_Juvenil progresion_Juvenil = db.Progresion_Juveniles.Find(id);
            db.Progresion_Juveniles.Remove(progresion_Juvenil);
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
