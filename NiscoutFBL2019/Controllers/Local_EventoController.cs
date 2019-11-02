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

    public class Local_EventoController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Local_Evento
        public ActionResult Index()
        {
            return View(db.Local_Eventos.ToList());
        }

        // GET: Local_Evento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Local_Evento local_Evento = db.Local_Eventos.Find(id);
            if (local_Evento == null)
            {
                return HttpNotFound();
            }
            return View(local_Evento);
        }

        // GET: Local_Evento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Local_Evento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Direccion,Telefono,E_Mail")] Local_Evento local_Evento)
        {
            if (ModelState.IsValid)
            {
                db.Local_Eventos.Add(local_Evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(local_Evento);
        }

        // GET: Local_Evento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Local_Evento local_Evento = db.Local_Eventos.Find(id);
            if (local_Evento == null)
            {
                return HttpNotFound();
            }
            return View(local_Evento);
        }

        // POST: Local_Evento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Direccion,Telefono,E_Mail")] Local_Evento local_Evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(local_Evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(local_Evento);
        }

        // GET: Local_Evento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Local_Evento local_Evento = db.Local_Eventos.Find(id);
            if (local_Evento == null)
            {
                return HttpNotFound();
            }
            return View(local_Evento);
        }

        // POST: Local_Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Local_Evento local_Evento = db.Local_Eventos.Find(id);
            db.Local_Eventos.Remove(local_Evento);
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
