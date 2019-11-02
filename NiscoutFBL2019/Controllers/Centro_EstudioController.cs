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

    public class Centro_EstudioController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Centro_Estudio
        public ActionResult Index( string buscar)
        {
            var centro = from ce in db.Centro_Estudios
                         select ce;

            if(!string.IsNullOrEmpty(buscar))
            {
                centro = centro.Where(ce => ce.Nombre_Centro.Contains(buscar));
            }

            return View(centro.ToList());
        }

        // GET: Centro_Estudio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Centro_Estudio centro_Estudio = db.Centro_Estudios.Find(id);
            if (centro_Estudio == null)
            {
                return HttpNotFound();
            }
            return View(centro_Estudio);
        }

        // GET: Centro_Estudio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Centro_Estudio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Centro,Nombre_Centro,Turno,Telefono,E_Mail")] Centro_Estudio centro_Estudio)
        {
            if (ModelState.IsValid)
            {
                db.Centro_Estudios.Add(centro_Estudio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centro_Estudio);
        }

        // GET: Centro_Estudio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Centro_Estudio centro_Estudio = db.Centro_Estudios.Find(id);
            if (centro_Estudio == null)
            {
                return HttpNotFound();
            }
            return View(centro_Estudio);
        }

        // POST: Centro_Estudio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Centro,Nombre_Centro,Turno,Telefono,E_Mail")] Centro_Estudio centro_Estudio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(centro_Estudio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(centro_Estudio);
        }

        // GET: Centro_Estudio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Centro_Estudio centro_Estudio = db.Centro_Estudios.Find(id);
            if (centro_Estudio == null)
            {
                return HttpNotFound();
            }
            return View(centro_Estudio);
        }

        // POST: Centro_Estudio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Centro_Estudio centro_Estudio = db.Centro_Estudios.Find(id);
            db.Centro_Estudios.Remove(centro_Estudio);
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
