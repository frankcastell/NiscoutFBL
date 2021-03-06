﻿using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NiscoutFBL2019.Models;
using Microsoft.AspNet.Identity;
using NiscoutFBL2019.Models.ReporteScouts;
using Microsoft.AspNet.Identity.EntityFramework;


namespace NiscoutFBL2019.Controllers
{
    [Authorize]
    public class Personal_AdmonController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Personal_Admon
        public ActionResult Index(string busqueda)
        {
            var personal_admon = db.Personal_Admon.Include(p => p.Departamento).Include(p => p.Cargo);

            if (!string.IsNullOrEmpty(busqueda))
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
            Personal_Admon personal_Admon = db.Personal_Admon.Find(id);
            if (personal_Admon == null)
            {
                return HttpNotFound();
            }
            return View(personal_Admon);
        }

        // GET: Personal_Admon/Create
        public ActionResult Create()
        {
            ViewBag.sexo = new SelectList(new[] {
                new SelectListItem { Value = "Masculino", Text = "Masculino" },
                new SelectListItem { Value = "Femenino", Text = "Femenino" }
                                               }, "Value", "Text");
            //Validando Estado Civil
            ViewBag.Estado_Civil = new SelectList(new[] {
                new SelectListItem { Value = "Soltero(a)", Text = "Soltero(a)" },
                new SelectListItem { Value = "Casado(a)", Text = "Casado(a)" },
                new SelectListItem { Value = "Divorciado(a)", Text = "Divorciado(a)" },
                new SelectListItem { Value = "Agutados", Text = "Aguntados" }
                                               }, "Value", "Text");
            ViewBag.Tipo_Sangre = new SelectList(new[] {
                new SelectListItem { Value = "O+", Text = "O+" },
                new SelectListItem { Value = "O-", Text = "O-" },
                new SelectListItem { Value = "A+", Text = "A+" },
                new SelectListItem { Value = "A-", Text = "A-" },
                new SelectListItem { Value = "B+", Text = "B+" },
                new SelectListItem { Value = "B-", Text = "B-" },
                new SelectListItem { Value = "AB+", Text = "AB+" },
                new SelectListItem { Value = "AB-", Text = "AB-" }
                                               }, "Value", "Text");

            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento");
            ViewBag.CargoId = new SelectList(db.Cargos, "Id", "Nombre_Cargo");
            return View();
        }

        // POST: Personal_Admon/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,Profesion,Centro_Laboral,Tipo_Sangre,CargoId")] Personal_Admon personal_Admon, string txtpass)
        {
            personal_Admon.Cod_Persona = "ASN" + personal_Admon.Fecha_Nac.ToShortDateString() + DateTime.Now.Year.ToString();
            if (ModelState.IsValid)
            {
                db.Personas.Add(personal_Admon);
                db.SaveChanges();

                //accedemos al modelo de la seguridad integrada
                ApplicationDbContext context = new ApplicationDbContext();
                //definimos las variables manejadoras de roles y usuarios
                var ManejadorRol = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var ManejadorUsuario = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var user = new ApplicationUser();
                user.Nombre = personal_Admon.Nombres;
                user.Apellido = personal_Admon.Apellidos;
                user.UserName = personal_Admon.E_Mail;
                user.Email = personal_Admon.E_Mail;
                string PWD = txtpass;
                var chkUser = ManejadorUsuario.Create(user, PWD);
                //si se creo con exito
                if (chkUser.Succeeded)
                {
                    ManejadorUsuario.AddToRole(user.Id, "Manager");
                }
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", personal_Admon.DepartamentoId);
            ViewBag.CargoId = new SelectList(db.Cargos, "Id", "Nombre_Cargo", personal_Admon.CargoId);
            return View(personal_Admon);
        }

        // GET: Personal_Admon/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Sexo = new SelectList(new[] {
                new SelectListItem { Value = "Masculino", Text = "Masculino" },
                new SelectListItem { Value = "Femenino", Text = "Femenino" }
                                               }, "Value", "Text");
            //Validando Estado Civil
            ViewBag.Estado_Civil = new SelectList(new[] {
                new SelectListItem { Value = "Soltero(a)", Text = "Soltero(a)" },
                new SelectListItem { Value = "Casado(a)", Text = "Casado(a)" },
                new SelectListItem { Value = "Divorciado(a)", Text = "Divorciado(a)" },
                new SelectListItem { Value = "Agutados", Text = "Aguntados" }
                                               }, "Value", "Text");
            ViewBag.Tipo_Sangre = new SelectList(new[] {
                new SelectListItem { Value = "O+", Text = "O+" },
                new SelectListItem { Value = "O-", Text = "O-" },
                new SelectListItem { Value = "A+", Text = "A+" },
                new SelectListItem { Value = "A-", Text = "A-" },
                new SelectListItem { Value = "B+", Text = "B+" },
                new SelectListItem { Value = "B-", Text = "B-" },
                new SelectListItem { Value = "AB+", Text = "AB+" },
                new SelectListItem { Value = "AB-", Text = "AB-" }
                                               }, "Value", "Text");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Admon personal_Admon = db.Personal_Admon.Find(id);
            if (personal_Admon == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", personal_Admon.DepartamentoId);
            ViewBag.CargoId = new SelectList(db.Cargos, "Id", "Nombre_Cargo", personal_Admon.CargoId);
            return View(personal_Admon);
        }

        // POST: Personal_Admon/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,Profesion,Centro_Laboral,Tipo_Sangre,CargoId")] Personal_Admon personal_Admon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personal_Admon).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", personal_Admon.DepartamentoId);
            ViewBag.CargoId = new SelectList(db.Cargos, "Id", "Nombre_Cargo", personal_Admon.CargoId);
            return View(personal_Admon);
        }

        // GET: Personal_Admon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Admon personal_Admon = db.Personal_Admon.Find(id);
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
            Personal_Admon personal_Admon = db.Personal_Admon.Find(id);
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
