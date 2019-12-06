﻿using System;
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
    public class Personal_AdmonController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Personal_Admon
        public ActionResult Index( string busqueda)
        {
            var personal_admon = db.Personal_Admon.Include(p => p.Departamento).Include(p => p.Cargo);

            if(!string.IsNullOrEmpty(busqueda))
            {
                personal_admon = personal_admon.Where(pa => pa.Nombres.Contains(busqueda));
            }
            return View(personal_admon.ToList());
        }

        // GET: Personal_Admon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Admon personal_Admon = (Personal_Admon)db.Personas.Find(id);
            if (personal_Admon == null)
            {
                return HttpNotFound();
            }
            return View(personal_Admon);
        }

        // GET: Personal_Admon/Create
        public ActionResult Create()
        {
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento");
            ViewBag.CargoId = new SelectList(db.Cargos, "Id", "Nombre_Cargo");
            return View();
        }

        // POST: Personal_Admon/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,CargoId")] Personal_Admon personal_Admon)
        {
            if (ModelState.IsValid)
            {
                db.Personas.Add(personal_Admon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", personal_Admon.DepartamentoId);
            ViewBag.CargoId = new SelectList(db.Cargos, "Id", "Nombre_Cargo", personal_Admon.CargoId);
            return View(personal_Admon);
        }

        // GET: Personal_Admon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Admon personal_Admon = (Personal_Admon)db.Personas.Find(id);
            if (personal_Admon == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Cod_Departamento", personal_Admon.DepartamentoId);
            ViewBag.CargoId = new SelectList(db.Cargos, "Id", "Cod_Cargo", personal_Admon.CargoId);
            return View(personal_Admon);
        }

        // POST: Personal_Admon/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,CargoId")] Personal_Admon personal_Admon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personal_Admon).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Cod_Departamento", personal_Admon.DepartamentoId);
            ViewBag.CargoId = new SelectList(db.Cargos, "Id", "Cod_Cargo", personal_Admon.CargoId);
            return View(personal_Admon);
        }

        // GET: Personal_Admon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Admon personal_Admon = (Personal_Admon)db.Personas.Find(id);
            if (personal_Admon == null)
            {
                return HttpNotFound();
            }
            return View(personal_Admon);
        }

        // POST: Personal_Admon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personal_Admon personal_Admon = (Personal_Admon)db.Personas.Find(id);
            db.Personas.Remove(personal_Admon);
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
