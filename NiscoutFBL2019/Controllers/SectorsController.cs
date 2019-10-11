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
    public class SectorsController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Sectors
        public ActionResult Index()
        {
            var sectores = db.Sectores.Include(s => s.Municipio).Include(s => s.Distrito);
            return View(sectores.ToList());
        }

        // GET: Sectors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sector sector = db.Sectores.Find(id);
            if (sector == null)
            {
                return HttpNotFound();
            }
            return View(sector);
        }

        // GET: Sectors/Create
        public ActionResult Create()
        {
            ViewBag.MunicipioId = new SelectList(db.Municipios, "Id", "Cod_Municipio");
            ViewBag.DistritoId = new SelectList(db.Distritos, "Id", "Cod_Distrito");
            return View();
        }

        // POST: Sectors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Sector,Nombre_Sector,MunicipioId,DistritoId")] Sector sector)
        {
            if (ModelState.IsValid)
            {
                db.Sectores.Add(sector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MunicipioId = new SelectList(db.Municipios, "Id", "Cod_Municipio", sector.MunicipioId);
            ViewBag.DistritoId = new SelectList(db.Distritos, "Id", "Cod_Distrito", sector.DistritoId);
            return View(sector);
        }

        // GET: Sectors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sector sector = db.Sectores.Find(id);
            if (sector == null)
            {
                return HttpNotFound();
            }
            ViewBag.MunicipioId = new SelectList(db.Municipios, "Id", "Cod_Municipio", sector.MunicipioId);
            ViewBag.DistritoId = new SelectList(db.Distritos, "Id", "Cod_Distrito", sector.DistritoId);
            return View(sector);
        }

        // POST: Sectors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Sector,Nombre_Sector,MunicipioId,DistritoId")] Sector sector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MunicipioId = new SelectList(db.Municipios, "Id", "Cod_Municipio", sector.MunicipioId);
            ViewBag.DistritoId = new SelectList(db.Distritos, "Id", "Cod_Distrito", sector.DistritoId);
            return View(sector);
        }

        // GET: Sectors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sector sector = db.Sectores.Find(id);
            if (sector == null)
            {
                return HttpNotFound();
            }
            return View(sector);
        }

        // POST: Sectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sector sector = db.Sectores.Find(id);
            db.Sectores.Remove(sector);
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
