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
    public class ResponsablesController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Responsables
        public ActionResult Index(string buscar)
        {
            var responsables = from s in db.Responsables
                               select s;
            db.Responsables.Include(r => r.Departamento).Include(r => r.Periodo);
            if(!string.IsNullOrEmpty(buscar))
            {
                responsables = responsables.Where(s => s.Nombres.Contains(buscar));
            }
            return View(responsables.ToList());

            //var depto = from s in db.Departamentos
            //            select s;
            //if (!string.IsNullOrEmpty(searching))
            //{
            //    depto = depto.Where(s => s.Nombre_Departamento.Contains(searching));
            //}

            //var personas = db.Personas.Include(p => p.Departamento);
            //return View(personas.ToList());
        }

        // GET: Responsables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsable responsable = (Responsable)db.Personas.Find(id);
            if (responsable == null)
            {
                return HttpNotFound();
            }
            return View(responsable);
        }

        // GET: Responsables/Create
        public ActionResult Create()
        {
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento");
            ViewBag.PeriodoId = new SelectList(db.Periodos, "Id", "Desde");
            return View();
        }

        // POST: Responsables/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,PeriodoId")] Responsable responsable)
        {
            if (ModelState.IsValid)
            {
                db.Personas.Add(responsable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }


            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", responsable.DepartamentoId);
            ViewBag.PeriodoId = new SelectList(db.Periodos, "Id", "Desde", responsable.PeriodoId);
            return View(responsable);
        }

        // GET: Responsables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsable responsable = (Responsable)db.Personas.Find(id);
            if (responsable == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", responsable.DepartamentoId);
            ViewBag.PeriodoId = new SelectList(db.Periodos, "Id", "Desde", responsable.PeriodoId);
            return View(responsable);
        }

        // POST: Responsables/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,PeriodoId")] Responsable responsable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(responsable).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Cod_Departamento", responsable.DepartamentoId);
            ViewBag.PeriodoId = new SelectList(db.Periodos, "Id", "Id", responsable.PeriodoId);
            return View(responsable);
        }

        // GET: Responsables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsable responsable = (Responsable)db.Personas.Find(id);
            if (responsable == null)
            {
                return HttpNotFound();
            }
            return View(responsable);
        }

        // POST: Responsables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Responsable responsable = (Responsable)db.Personas.Find(id);
            db.Personas.Remove(responsable);
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
