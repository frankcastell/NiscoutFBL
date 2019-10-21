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

    public class JuvenilsController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Juvenils
        public ActionResult Index()
        {
            var juveniles = db.Juveniles.Include(j => j.Centro_Estudio);
            return View(juveniles.ToList());
        }

        // GET: Juvenils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juvenil juvenil = db.Juveniles.Find(id);
            if (juvenil == null)
            {
                return HttpNotFound();
            }
            return View(juvenil);
        }

        // GET: Juvenils/Create
        public ActionResult Create()
        {
            ViewBag.Centro_EstudioId = new SelectList(db.Centro_Estudios, "Id", "Cod_Centro");
            return View();
        }

        // POST: Juvenils/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Centro_EstudioId")] Juvenil juvenil)
        {
            if (ModelState.IsValid)
            {
                db.Juveniles.Add(juvenil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Centro_EstudioId = new SelectList(db.Centro_Estudios, "Id", "Cod_Centro", juvenil.Centro_EstudioId);
            return View(juvenil);
        }

        // GET: Juvenils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juvenil juvenil = db.Juveniles.Find(id);
            if (juvenil == null)
            {
                return HttpNotFound();
            }
            ViewBag.Centro_EstudioId = new SelectList(db.Centro_Estudios, "Id", "Cod_Centro", juvenil.Centro_EstudioId);
            return View(juvenil);
        }

        // POST: Juvenils/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Centro_EstudioId")] Juvenil juvenil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(juvenil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Centro_EstudioId = new SelectList(db.Centro_Estudios, "Id", "Cod_Centro", juvenil.Centro_EstudioId);
            return View(juvenil);
        }

        // GET: Juvenils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juvenil juvenil = db.Juveniles.Find(id);
            if (juvenil == null)
            {
                return HttpNotFound();
            }
            return View(juvenil);
        }

        // POST: Juvenils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Juvenil juvenil = db.Juveniles.Find(id);
            db.Juveniles.Remove(juvenil);
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
