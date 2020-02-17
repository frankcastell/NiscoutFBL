﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NiscoutFBL2019.Models;
using Microsoft.Reporting.WebForms;
using Microsoft.AspNet.Identity;
using NiscoutFBL2019.Models.ReporteScouts;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NiscoutFBL2019.Controllers
{
    [Authorize]
    public class PersonasController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Personas
        public ActionResult Index(string buscar)
        {
            var personas = db.Personas.Include(p => p.Departamento);

            if (!string.IsNullOrEmpty(buscar))
            {
                personas = personas.Where(x => x.Nombres.Contains(buscar));
            }
            return View(personas.ToList());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
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
                new SelectListItem { Value = "Ajuntados", Text = "Ajuntados" }
                                               }, "Value", "Text");

            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento");
            return View();
        }

       
        public ActionResult Listarnotificacion()
        {

            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Estado");
            return View();
        }
       
        // POST: Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,Profesion,Centro_Laboral,Tipo_Sangre")] Persona persona, string txtpass)
        {
          
             if (ModelState.IsValid)
            {
                db.Personas.Add(persona);
                db.SaveChanges();
                //accedemos al modelo de la seguridad integrada
                ApplicationDbContext context = new ApplicationDbContext();
                //definimos las variables manejadoras de roles y usuarios
                var ManejadorRol = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var ManejadorUsuario = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var user = new ApplicationUser();
                user.Nombre = persona.Nombres;
                user.Apellido = persona.Apellidos;
                user.UserName = persona.E_Mail;
                user.Email = persona.E_Mail;
                string PWD = txtpass;
                var chkUser = ManejadorUsuario.Create(user, PWD);
                //si se creo con exito
                if (chkUser.Succeeded)
                {
                    ManejadorUsuario.AddToRole(user.Id, "Usuario");
                }
                //generar el carnet
                //persona.Cod_Persona = "NS-" + System.DateTime.Today.Year.ToString() + persona.Id.ToString();
                //db.SaveChanges();

                return RedirectToAction("Create", "Tutorias", new { idpersona = persona.Id });
            }

            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", persona.DepartamentoId);
            return View(persona);
        }

        [AllowAnonymous]
        public ActionResult SolicitudTutor( )
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
                new SelectListItem { Value = "Ajuntados", Text = "Ajuntados" }
                                               }, "Value", "Text");
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento");
          
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SolicitudTutor([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,Profesion,Centro_Laboral,Tipo_Sangre")] Persona persona, string txtpass)
        {

            if (ModelState.IsValid)
            {
                db.Personas.Add(persona); 
                db.SaveChanges();
                //accedemos al modelo de la seguridad integrada
                ApplicationDbContext context = new ApplicationDbContext();
                //definimos las variables manejadoras de roles y usuarios
                var ManejadorRol = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var ManejadorUsuario = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var user = new ApplicationUser();
                user.Nombre = persona.Nombres;
                user.Apellido = persona.Apellidos;
                user.UserName = persona.E_Mail;
                user.Email = persona.E_Mail;
                string PWD = txtpass;
                var chkUser = ManejadorUsuario.Create(user, PWD);
                //si se creo con exito
                if (chkUser.Succeeded)
                {
                    ManejadorUsuario.AddToRole(user.Id, "Tutores");
                }
                //generar el carnet
                //persona.Cod_Persona = "NS-" + System.DateTime.Today.Year.ToString() + persona.Id.ToString();
                //db.SaveChanges();

                ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", persona.DepartamentoId);
                //return RedirectToAction("tutorsolicitud", "Tutorias", new { idpersona = persona.Id });
                return RedirectToAction("Login", "Account");
            }

            return RedirectToAction("Index");
        }
        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
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

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", persona.DepartamentoId);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,Profesion,Centro_Laboral,Tipo_Sangre")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Cod_Departamento", persona.DepartamentoId);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Personas.Find(id);
            db.Personas.Remove(persona);
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
