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

    public class AsistentesController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Asistentes
        public ActionResult Index(string  busqueda)
        {
            var asistentes = db.Asistentes.Include(a => a.Departamento);
            
            if (!string.IsNullOrEmpty(busqueda))
            {
                asistentes = asistentes.Where(s => s.Nombres.Contains(busqueda));
            }
            return View(asistentes.ToList());
        }

        // GET: Asistentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistente asistente = (Asistente)db.Personas.Find(id);
            if (asistente == null)
            {
                return HttpNotFound();
            }
            return View(asistente);
        }

        // GET: Asistentes/Create
        public ActionResult Create()
        {
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento");
            return View();
        }

        // POST: Asistentes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId")] Asistente asistente)
        {
            if (ModelState.IsValid)
            {
                db.Personas.Add(asistente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", asistente.DepartamentoId);
            return View(asistente);
        }

        // GET: Asistentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistente asistente = (Asistente)db.Personas.Find(id);
            if (asistente == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Cod_Departamento", asistente.DepartamentoId);
            return View(asistente);
        }

        // POST: Asistentes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId")] Asistente asistente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asistente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Cod_Departamento", asistente.DepartamentoId);
            return View(asistente);
        }

        // GET: Asistentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistente asistente = (Asistente)db.Personas.Find(id);
            if (asistente == null)
            {
                return HttpNotFound();
            }
            return View(asistente);
        }

        // POST: Asistentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asistente asistente = (Asistente)db.Personas.Find(id);
            db.Personas.Remove(asistente);
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
