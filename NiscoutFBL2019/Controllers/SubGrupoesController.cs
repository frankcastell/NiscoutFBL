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
    public class SubGrupoesController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: SubGrupoes
        public ActionResult Index( string buscar)
        {
            var subGrupos = db.SubGrupos.Include(s => s.Asistente).Include(s => s.Tipo_Grupo).Include(s => s.Grupo);
            if(!string.IsNullOrEmpty(buscar))
            {
                subGrupos = subGrupos.Where(s => s.Nombre_Subgrupo.Contains(buscar));
            }
            return View(subGrupos.ToList());
        }

        // GET: SubGrupoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubGrupo subGrupo = db.SubGrupos.Find(id);
            if (subGrupo == null)
            {
                return HttpNotFound();
            }
            return View(subGrupo);
        }

        // GET: SubGrupoes/Create
        public ActionResult Create()
        {
            ViewBag.AsistenteId = new SelectList(db.Personas, "Id", "Cod_Persona");
            ViewBag.Tipo_GrupoId = new SelectList(db.Tipo_Grupos, "Id", "Cod_Tipo_Grupo");
            ViewBag.GrupoId = new SelectList(db.Grupos, "Id", "Cod_Grupo");
            return View();
        }

        // POST: SubGrupoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Subgrupo,Nombre_Subgrupo,Descripcion,AsistenteId,Tipo_GrupoId,GrupoId")] SubGrupo subGrupo)
        {
            if (ModelState.IsValid)
            {
                db.SubGrupos.Add(subGrupo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            ViewBag.AsistenteId = new SelectList(db.Personas, "Id", "Cod_Persona", subGrupo.AsistenteId);
            ViewBag.Tipo_GrupoId = new SelectList(db.Tipo_Grupos, "Id", "Cod_Tipo_Grupo", subGrupo.Tipo_GrupoId);
            ViewBag.GrupoId = new SelectList(db.Grupos, "Id", "Cod_Grupo", subGrupo.GrupoId);
            return View(subGrupo);
        }

        // GET: SubGrupoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubGrupo subGrupo = db.SubGrupos.Find(id);
            if (subGrupo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AsistenteId = new SelectList(db.Personas, "Id", "Cod_Persona", subGrupo.AsistenteId);
            ViewBag.Tipo_GrupoId = new SelectList(db.Tipo_Grupos, "Id", "Cod_Tipo_Grupo", subGrupo.Tipo_GrupoId);
            ViewBag.GrupoId = new SelectList(db.Grupos, "Id", "Cod_Grupo", subGrupo.GrupoId);
            return View(subGrupo);
        }

        // POST: SubGrupoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Subgrupo,Nombre_Subgrupo,Descripcion,AsistenteId,Tipo_GrupoId,GrupoId")] SubGrupo subGrupo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subGrupo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AsistenteId = new SelectList(db.Personas, "Id", "Cod_Persona", subGrupo.AsistenteId);
            ViewBag.Tipo_GrupoId = new SelectList(db.Tipo_Grupos, "Id", "Cod_Tipo_Grupo", subGrupo.Tipo_GrupoId);
            ViewBag.GrupoId = new SelectList(db.Grupos, "Id", "Cod_Grupo", subGrupo.GrupoId);
            return View(subGrupo);
        }

        // GET: SubGrupoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubGrupo subGrupo = db.SubGrupos.Find(id);
            if (subGrupo == null)
            {
                return HttpNotFound();
            }
            return View(subGrupo);
        }

        // POST: SubGrupoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubGrupo subGrupo = db.SubGrupos.Find(id);
            db.SubGrupos.Remove(subGrupo);
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
