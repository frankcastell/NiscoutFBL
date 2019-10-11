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
    public class Etapa_AprobacionController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Etapa_Aprobacion
        public ActionResult Index()
        {
            return View(db.Etapa_Aprobaciones.ToList());
        }

        // GET: Etapa_Aprobacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa_Aprobacion etapa_Aprobacion = db.Etapa_Aprobaciones.Find(id);
            if (etapa_Aprobacion == null)
            {
                return HttpNotFound();
            }
            return View(etapa_Aprobacion);
        }

        // GET: Etapa_Aprobacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Etapa_Aprobacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Etapa,Estado")] Etapa_Aprobacion etapa_Aprobacion)
        {
            if (ModelState.IsValid)
            {
                db.Etapa_Aprobaciones.Add(etapa_Aprobacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(etapa_Aprobacion);
        }

        // GET: Etapa_Aprobacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa_Aprobacion etapa_Aprobacion = db.Etapa_Aprobaciones.Find(id);
            if (etapa_Aprobacion == null)
            {
                return HttpNotFound();
            }
            return View(etapa_Aprobacion);
        }

        // POST: Etapa_Aprobacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Etapa,Estado")] Etapa_Aprobacion etapa_Aprobacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etapa_Aprobacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etapa_Aprobacion);
        }

        // GET: Etapa_Aprobacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa_Aprobacion etapa_Aprobacion = db.Etapa_Aprobaciones.Find(id);
            if (etapa_Aprobacion == null)
            {
                return HttpNotFound();
            }
            return View(etapa_Aprobacion);
        }

        // POST: Etapa_Aprobacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etapa_Aprobacion etapa_Aprobacion = db.Etapa_Aprobaciones.Find(id);
            db.Etapa_Aprobaciones.Remove(etapa_Aprobacion);
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
