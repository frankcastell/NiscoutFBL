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
using System.ComponentModel.DataAnnotations;


namespace NiscoutFBL2019.Controllers
{
    [Authorize]
    public class JuvenilsController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Juvenils
        public ActionResult Index(string buscar)
        {
            var juvenil = db.Juveniles.Include(j => j.Departamento).Include(j => j.Tutoria);

            if (!string.IsNullOrEmpty(buscar))
            {
                juvenil = juvenil.Where(j => j.Nombres.Contains(buscar));
            }
            return View(juvenil.ToList());
        }
        // GET: Juvenil tutorias
        public ActionResult JuvenilTutorias(string buscar)
        {
           
            int IdTutor = db.Personas.Where(x => x.E_Mail == User.Identity.Name).FirstOrDefault().Id; 
            var juvenil = db.Juveniles.Where(x=>x.Tutoria.PersonaId==IdTutor) .Include(j => j.Departamento).Include(j => j.Tutoria);

            if (!string.IsNullOrEmpty(buscar))
            {
                juvenil = juvenil.Where(j => j.Nombres.Contains(buscar));
            }
            ViewBag.IdTutor = IdTutor;
            return View(juvenil.ToList());
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
        public ActionResult Create(int idtutor)
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
            //ViewBag.TutoriaId = new SelectList(db.Tutorias, "Id", "Parentezco");
            ViewBag.TutoriaId = db.Tutorias.Find(idtutor);
            return View();
        }

        // POST: Juvenils/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,Profesion,Centro_Laboral,Tipo_Sangre,TutoriaId")] Juvenil juvenil)
        {
            juvenil.Cod_Persona = "ASN" + juvenil.Fecha_Nac.ToShortDateString() + DateTime.Now.Year.ToString();
            if (ModelState.IsValid)
            {
                db.Personas.Add(juvenil);
                db.SaveChanges();

                ////accedemos al modelo de la seguridad integrada
                //ApplicationDbContext context = new ApplicationDbContext();
                ////definimos las variables manejadoras de roles y usuarios
                //var ManejadorRol = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                //var ManejadorUsuario = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                //var user = new ApplicationUser();
                //user.Nombre = juvenil.Nombres;
                //user.Apellido = juvenil.Apellidos;
                //user.UserName = juvenil.E_Mail;
                //user.Email = juvenil.E_Mail;
                //string PWD = txtpass;
                //var chkUser = ManejadorUsuario.Create(user, PWD);
                ////si se creo con exito
                //if (chkUser.Succeeded)
                //{
                //    ManejadorUsuario.AddToRole(user.Id, "Usuario");
                //}
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", juvenil.DepartamentoId);
            ViewBag.TutoriaId = new SelectList(db.Tutorias, "Id", "Parentezco", juvenil.TutoriaId);
            return View(juvenil);
        }

        // GET: Juvenils/Create  Nuevo
        [AllowAnonymous]
        public ActionResult SolicitudJuvenil(int idtutoria)
        {
            ViewBag.IdTutoria = idtutoria;
            // Codigo para sexo
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
            //ViewBag.TutoriaId = new SelectList(db.Tutorias, "Id", "Parentezco");

            ViewBag.TutoriaId = db.Tutorias.Find(idtutoria);
            return View();
        }
        //Nuevo ...
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SolicitudJuvenil([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,Profesion,Centro_Laboral,Tipo_Sangre,TutoriaId")] Juvenil juvenil, int idtutoria)
        {
            juvenil.Cod_Persona = "ASN" + juvenil.Fecha_Nac.ToShortDateString() + DateTime.Now.Year.ToString();
            if (ModelState.IsValid)
            {
                db.Personas.Add(juvenil);
                db.SaveChanges();

                ////accedemos al modelo de la seguridad integrada
                //ApplicationDbContext context = new ApplicationDbContext();
                ////definimos las variables manejadoras de roles y usuarios
                //var ManejadorRol = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                //var ManejadorUsuario = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                //var user = new ApplicationUser();
                //user.Nombre = juvenil.Nombres;
                //user.Apellido = juvenil.Apellidos;
                //user.UserName = juvenil.E_Mail;
                //user.Email = juvenil.E_Mail;
                //string PWD = txtpass;
                //var chkUser = ManejadorUsuario.Create(user, PWD);
                ////si se creo con exito
                //if (chkUser.Succeeded)
                //{
                //    ManejadorUsuario.AddToRole(user.Id, "Usuario");
                //}
                return RedirectToAction("MembreJuvenil", "Membresia_Juvenil", new { idjuvenil = juvenil.Id });
            }

            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", juvenil.DepartamentoId);
            //////ViewBag.TutoriaId = new SelectList(db.Tutorias, "Id", "Parentezco", juvenil.TutoriaId);
            ViewBag.TutoriaId = db.Tutorias.Find(idtutoria);
            return View(juvenil);
        }

        // GET: Juvenils/Edit/5
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
                new SelectListItem { Value = "Ajuntados", Text = "Ajuntados" }
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
            Juvenil juvenil = db.Juveniles.Find(id);
            if (juvenil == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", juvenil.DepartamentoId);
            ViewBag.TutoriaId = new SelectList(db.Tutorias, "Id", "Parentezco", juvenil.TutoriaId);
            return View(juvenil);
        }

        // POST: Juvenils/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,Profesion,Centro_Laboral,Tipo_Sangre,TutoriaId")] Juvenil juvenil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(juvenil).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", juvenil.DepartamentoId);
            ViewBag.TutoriaId = new SelectList(db.Tutorias, "Id", "Parentezco", juvenil.TutoriaId);
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
            db.Personas.Remove(juvenil);
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
