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

    public class Membresia_AdultoController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Membresia_Adulto
        public ActionResult Index( string buscar)
        {
            var membresia_Adultos = db.Membresia_Adultos.Include(m => m.Adulto).Include(m => m.Etapa_Aprobacion1);

            if(!string.IsNullOrEmpty(buscar))
            {
                membresia_Adultos = membresia_Adultos.Where(ma => ma.Adulto.Nombres.Contains(buscar));
            }
            return View(membresia_Adultos.ToList());
        }

        // GET: Membresia_Adulto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membresia_Adulto membresia_Adulto = db.Membresia_Adultos.Find(id);
            if (membresia_Adulto == null)
            {
                return HttpNotFound();
            }
            return View(membresia_Adulto);
        }

        // GET: Membresia_Adulto/Create
        public ActionResult Create()
        {
            ViewBag.AdultoId = new SelectList(db.Personas, "Id", "Nombres");
            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Estado");
            return View();
        }

        // POST: Membresia_Adulto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Carta_Compromiso,Carta_Intencion,Record_Policia,Carta_Ref_Personal,Certifi_Salvo_Peligro,AdultoId,Etapa_AprobacionId")] Membresia_Adulto membresia_Adulto)
        {
            if (ModelState.IsValid)
            {
                db.Membresia_Adultos.Add(membresia_Adulto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            ViewBag.AdultoId = new SelectList(db.Personas, "Id", "Nombres", membresia_Adulto);
            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Estado", membresia_Adulto.Etapa_AprobacionId);
            return View(membresia_Adulto);
        }

        // GET: Membresia_Adulto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membresia_Adulto membresia_Adulto = db.Membresia_Adultos.Find(id);
            if (membresia_Adulto == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdultoId = new SelectList(db.Personas, "Id", "Cod_Persona", membresia_Adulto.AdultoId);
            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Cod_Etapa", membresia_Adulto.Etapa_AprobacionId);
            return View(membresia_Adulto);
        }

        // POST: Membresia_Adulto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Carta_Compromiso,Carta_Intencion,Record_Policia,Carta_Ref_Personal,Certifi_Salvo_Peligro,AdultoId,Etapa_AprobacionId")] Membresia_Adulto membresia_Adulto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membresia_Adulto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdultoId = new SelectList(db.Personas, "Id", "Cod_Persona", membresia_Adulto.AdultoId);
            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Cod_Etapa", membresia_Adulto.Etapa_AprobacionId);
            return View(membresia_Adulto);
        }

        // GET: Membresia_Adulto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membresia_Adulto membresia_Adulto = db.Membresia_Adultos.Find(id);
            if (membresia_Adulto == null)
            {
                return HttpNotFound();
            }
            return View(membresia_Adulto);
        }

        // POST: Membresia_Adulto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Membresia_Adulto membresia_Adulto = db.Membresia_Adultos.Find(id);
            db.Membresia_Adultos.Remove(membresia_Adulto);
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
