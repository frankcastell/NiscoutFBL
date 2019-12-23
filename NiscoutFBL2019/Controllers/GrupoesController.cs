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
    public class GrupoesController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Grupoes
        public ActionResult Index()
        {
            var grupos = db.Grupos.Include(g => g.Responsable).Include(g => g.Distrito);
            return View(grupos.ToList());
        }

        // GET: Grupoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupo grupo = db.Grupos.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        // GET: Grupoes/Create
        public ActionResult Create()
        {
            ViewBag.ResponsableId = new SelectList(db.Personas, "Id", "Cod_Persona");
            ViewBag.DistritoId = new SelectList(db.Distritos, "Id", "Cod_Distrito");
            return View();
        }

        // POST: Grupoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Grupo,Nombre_Grupo,Num_Solicitud,Pañoleta,Insignia,Sello_Grupo,ResponsableId,DistritoId,Carta_Solicitud")] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                db.Grupos.Add(grupo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResponsableId = new SelectList(db.Personas, "Id", "Cod_Persona", grupo.ResponsableId);
            ViewBag.DistritoId = new SelectList(db.Distritos, "Id", "Cod_Distrito", grupo.DistritoId);
            return View(grupo);
        }

        // GET: Grupoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupo grupo = db.Grupos.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResponsableId = new SelectList(db.Personas, "Id", "Cod_Persona", grupo.ResponsableId);
            ViewBag.DistritoId = new SelectList(db.Distritos, "Id", "Cod_Distrito", grupo.DistritoId);
            return View(grupo);
        }

        // POST: Grupoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Grupo,Nombre_Grupo,Num_Solicitud,Pañoleta,Insignia,Sello_Grupo,ResponsableId,DistritoId,Carta_Solicitud")] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResponsableId = new SelectList(db.Personas, "Id", "Cod_Persona", grupo.ResponsableId);
            ViewBag.DistritoId = new SelectList(db.Distritos, "Id", "Cod_Distrito", grupo.DistritoId);
            return View(grupo);
        }

        // GET: Grupoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupo grupo = db.Grupos.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        // POST: Grupoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grupo grupo = db.Grupos.Find(id);
            db.Grupos.Remove(grupo);
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
