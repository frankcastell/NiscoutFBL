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

    public class Detalle_Evento_PatroController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Detalle_Evento_Patro
        public ActionResult Index( string searching)
        {
            var detalle_Evento_Patros = db.Detalle_Evento_Patros.Include(d => d.Asistente_Evento).Include(d => d.Evento).Include(d => d.Local_Evento).Include(d => d.Patrocinador);

            if(!string.IsNullOrEmpty(searching))
            {
                detalle_Evento_Patros = detalle_Evento_Patros.Where(dep => dep.Local_Evento.Nombre.Contains(searching));
            }
            return View(detalle_Evento_Patros.ToList());
        }

        // GET: Detalle_Evento_Patro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Evento_Patro detalle_Evento_Patro = db.Detalle_Evento_Patros.Find(id);
            if (detalle_Evento_Patro == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Evento_Patro);
        }

        // GET: Detalle_Evento_Patro/Create
        public ActionResult Create()
        {
            ViewBag.Asistente_EventoId = new SelectList(db.Asistente_Eventos, "Id", "Id");
            ViewBag.EventoId = new SelectList(db.Eventos, "Id", "Cod_Evento");
            ViewBag.Local_EventoId = new SelectList(db.Local_Eventos, "Id", "Nombre");
            ViewBag.PatrocinadorId = new SelectList(db.Personas, "Id", "Cod_Persona");
            return View();
        }

        // POST: Detalle_Evento_Patro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Desde,PatrocinadorId,EventoId,Hasta,Local_EventoId,Asistente_EventoId")] Detalle_Evento_Patro detalle_Evento_Patro)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_Evento_Patros.Add(detalle_Evento_Patro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Asistente_EventoId = new SelectList(db.Asistente_Eventos, "Id", "Id", detalle_Evento_Patro.Asistente_EventoId);
            ViewBag.EventoId = new SelectList(db.Eventos, "Id", "Cod_Evento", detalle_Evento_Patro.EventoId);
            ViewBag.Local_EventoId = new SelectList(db.Local_Eventos, "Id", "Nombre", detalle_Evento_Patro.Local_EventoId);
            ViewBag.PatrocinadorId = new SelectList(db.Personas, "Id", "Cod_Persona", detalle_Evento_Patro.PatrocinadorId);
            return View(detalle_Evento_Patro);
        }

        // GET: Detalle_Evento_Patro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Evento_Patro detalle_Evento_Patro = db.Detalle_Evento_Patros.Find(id);
            if (detalle_Evento_Patro == null)
            {
                return HttpNotFound();
            }
            ViewBag.Asistente_EventoId = new SelectList(db.Asistente_Eventos, "Id", "Id", detalle_Evento_Patro.Asistente_EventoId);
            ViewBag.EventoId = new SelectList(db.Eventos, "Id", "Cod_Evento", detalle_Evento_Patro.EventoId);
            ViewBag.Local_EventoId = new SelectList(db.Local_Eventos, "Id", "Nombre", detalle_Evento_Patro.Local_EventoId);
            ViewBag.PatrocinadorId = new SelectList(db.Personas, "Id", "Cod_Persona", detalle_Evento_Patro.PatrocinadorId);
            return View(detalle_Evento_Patro);
        }

        // POST: Detalle_Evento_Patro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Desde,PatrocinadorId,EventoId,Hasta,Local_EventoId,Asistente_EventoId")] Detalle_Evento_Patro detalle_Evento_Patro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_Evento_Patro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Asistente_EventoId = new SelectList(db.Asistente_Eventos, "Id", "Id", detalle_Evento_Patro.Asistente_EventoId);
            ViewBag.EventoId = new SelectList(db.Eventos, "Id", "Cod_Evento", detalle_Evento_Patro.EventoId);
            ViewBag.Local_EventoId = new SelectList(db.Local_Eventos, "Id", "Nombre", detalle_Evento_Patro.Local_EventoId);
            ViewBag.PatrocinadorId = new SelectList(db.Personas, "Id", "Cod_Persona", detalle_Evento_Patro.PatrocinadorId);
            return View(detalle_Evento_Patro);
        }

        // GET: Detalle_Evento_Patro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Evento_Patro detalle_Evento_Patro = db.Detalle_Evento_Patros.Find(id);
            if (detalle_Evento_Patro == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Evento_Patro);
        }

        // POST: Detalle_Evento_Patro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_Evento_Patro detalle_Evento_Patro = db.Detalle_Evento_Patros.Find(id);
            db.Detalle_Evento_Patros.Remove(detalle_Evento_Patro);
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
