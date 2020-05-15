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
    public class TutoriasController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

       
    // GET: Tutorias
    public ActionResult Index()
        {
            var tutorias = db.Tutorias.Include(t => t.Persona);
            return View(tutorias.ToList());
        }

        // GET: Tutorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutoria tutoria = db.Tutorias.Find(id);
            if (tutoria == null)
            {
                return HttpNotFound();
            }
            return View(tutoria);
        }

        // GET: Tutorias/Create
        public ActionResult Create(int idpersona )
        {
            ViewBag.PersonaId = db.Personas.Where(x => x.Id == idpersona).FirstOrDefault();
            //ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Nombres");
            return View();
        }

        // POST: Tutorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Parentezco,PersonaId")] Tutoria tutoria)
        {
            if (ModelState.IsValid)
            {
                db.Tutorias.Add(tutoria);
                db.SaveChanges();
                return RedirectToAction("SolicitudJuvenil","Juvenils", new { idtutor  = tutoria.Id});
            }

            ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Nombres", tutoria.PersonaId);
            return View(tutoria);
        }



        ///vista tutor
        ///
        //[AllowAnonymous]
        public ActionResult TutorSolicitud(int idpersona)
        {
            ViewBag.Persona = db.Personas.Where(x => x.Id == idpersona).FirstOrDefault();
            return View();
        }


        //[AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TutorSolicitud([Bind(Include = "Id,Parentezco,PersonaId")] Tutoria tutoria)
        {
            if (ModelState.IsValid)
            {
                db.Tutorias.Add(tutoria);
                db.SaveChanges();
                ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Nombres", tutoria.PersonaId);
                return RedirectToAction("SolicitudJuvenil", "Juvenils", new { idtutor  = tutoria.Id });
                //return View(tutoria);
            }


            return RedirectToAction("Index");
        }

        // GET: Tutorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutoria tutoria = db.Tutorias.Find(id);
            if (tutoria == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Nombres", tutoria.PersonaId);
            return View(tutoria);
        }

        // POST: Tutorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Parentezco,PersonaId")] Tutoria tutoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tutoria).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Nombres", tutoria.PersonaId);
            return View(tutoria);
        }

        // GET: Tutorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutoria tutoria = db.Tutorias.Find(id);
            if (tutoria == null)
            {
                return HttpNotFound();
            }
            return View(tutoria);
        }

        // POST: Tutorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tutoria tutoria = db.Tutorias.Find(id);
            db.Tutorias.Remove(tutoria);
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
