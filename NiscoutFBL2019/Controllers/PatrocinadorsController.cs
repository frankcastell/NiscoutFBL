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

    public class PatrocinadorsController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Patrocinadors
        public ActionResult Index( string buscar)
        {
            var patrocinadores = db.Patrocinadores.Include(p => p.Departamento);

            if(!string.IsNullOrEmpty(buscar))
            {
                patrocinadores = patrocinadores.Where(p => p.Nombre_Insti.Contains(buscar));
            }
            return View(patrocinadores.ToList());
        }

        // GET: Patrocinadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patrocinador patrocinador = (Patrocinador)db.Personas.Find(id);
            if (patrocinador == null)
            {
                return HttpNotFound();
            }
            return View(patrocinador);
        }

        // GET: Patrocinadors/Create
        public ActionResult Create()
        {
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento");
            return View();
        }

        // POST: Patrocinadors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,Nombre_Insti,Nombre_Representante,Trabajo")] Patrocinador patrocinador)
        {
            if (ModelState.IsValid)
            {
                db.Personas.Add(patrocinador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", patrocinador.DepartamentoId);
            return View(patrocinador);
        }

        // GET: Patrocinadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patrocinador patrocinador = (Patrocinador)db.Personas.Find(id);
            if (patrocinador == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Cod_Departamento", patrocinador.DepartamentoId);
            return View(patrocinador);
        }

        // POST: Patrocinadors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,Nombre_Insti,Nombre_Representante,Trabajo")] Patrocinador patrocinador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patrocinador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Cod_Departamento", patrocinador.DepartamentoId);
            return View(patrocinador);
        }

        // GET: Patrocinadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patrocinador patrocinador = (Patrocinador)db.Personas.Find(id);
            if (patrocinador == null)
            {
                return HttpNotFound();
            }
            return View(patrocinador);
        }

        // POST: Patrocinadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patrocinador patrocinador = (Patrocinador)db.Personas.Find(id);
            db.Personas.Remove(patrocinador);
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
