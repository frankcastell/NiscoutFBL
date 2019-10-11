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
    public class Asistente_EventoController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Asistente_Evento
        public ActionResult Index()
        {
            return View(db.Asistente_Eventos.ToList());
        }

        // GET: Asistente_Evento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistente_Evento asistente_Evento = db.Asistente_Eventos.Find(id);
            if (asistente_Evento == null)
            {
                return HttpNotFound();
            }
            return View(asistente_Evento);
        }

        // GET: Asistente_Evento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asistente_Evento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Hora_Llegada")] Asistente_Evento asistente_Evento)
        {
            if (ModelState.IsValid)
            {
                db.Asistente_Eventos.Add(asistente_Evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asistente_Evento);
        }

        // GET: Asistente_Evento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistente_Evento asistente_Evento = db.Asistente_Eventos.Find(id);
            if (asistente_Evento == null)
            {
                return HttpNotFound();
            }
            return View(asistente_Evento);
        }

        // POST: Asistente_Evento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Hora_Llegada")] Asistente_Evento asistente_Evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asistente_Evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asistente_Evento);
        }

        // GET: Asistente_Evento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistente_Evento asistente_Evento = db.Asistente_Eventos.Find(id);
            if (asistente_Evento == null)
            {
                return HttpNotFound();
            }
            return View(asistente_Evento);
        }

        // POST: Asistente_Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asistente_Evento asistente_Evento = db.Asistente_Eventos.Find(id);
            db.Asistente_Eventos.Remove(asistente_Evento);
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
