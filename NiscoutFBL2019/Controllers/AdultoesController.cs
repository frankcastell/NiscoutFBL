using System;
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
    public class AdultoesController : Controller
    {
 
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        public static int Contador = 0;
        // GET: Adultoes
        public ActionResult Index(string buscar)
        {
            var adulto = db.Adultos.Include(a => a.Departamento);

            if (!string.IsNullOrEmpty(buscar))
            {
                adulto = adulto.Where(s => s.Nombres.Contains(buscar));
            }
            return View(adulto.ToList());
        }

        // GET: Adultoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adulto adulto = db.Adultos.Find(id);
            if (adulto == null)
            {
                return HttpNotFound();
            }
            return View(adulto);
        }

        // GET: Adultoes/Create
        public ActionResult Create()
        {
            ViewBag.sexo = new SelectList(new[] {
                new SelectListItem { Value = "Masculino", Text = "Masculino" },
                new SelectListItem { Value = "Femenino", Text = "Femenino" }
                                               }, "Value", "Text");

            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento");
            ViewBag.Contador = db.Adultos.Count();
            return View();
        }

        // clases similar al dataset
        public class adultosR
        {
            public string Column1 { get; set; }
            public string Column2 { get; set; }
            public string Column3 { get; set; }
            public string Column4 { get; set; }
            public string Column5 { get; set; }
            public string Column6 { get; set; }
            public string Column7 { get; set; }
            public string Column8 { get; set; }
            public string Column9 { get; set; }
            public string Column10 { get; set; }
            public string Column11 { get; set; }
            //agregar otra columan x los campos nuevos

        }

        // Listando 
        public List<adultosR> GetAdulto()
        {
            return (from item in db.Adultos.ToList()

                    select new adultosR
                    {
                        Column1 = item.Nombres,
                        Column2 = item.Apellidos,
                        Column3 = item.Cedula,
                        Column4 = item.E_Mail,
                        Column5 = item.Fecha_Nac.ToString("yyyy-MM-dd"),
                        Column6 = item.Sexo,
                        Column7 = item.Telefono.ToString(),
                        Column8 = item.Direccion,
                        Column9 = item.Departamento.Nombre_Departamento.ToString(),
                        Column10 = item.Num_Pasaporte,
                        Column11 = item.Estado_Civil


                    }).ToList();
        }

        // Listando ala vista
        public ActionResult RepAdulto()
        {
            //var fecha = DateTime;
            DataSetScout.DataTable1DataTable p = new DataSetScout.DataTable1DataTable();
            ReportViewer rpt = new ReportViewer();
            rpt.ProcessingMode = ProcessingMode.Local;
            rpt.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath + @"Reportes/RepAdultos.rdlc");
            rpt.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", GetAdulto()));
            rpt.LocalReport.Refresh();

            rpt.AsyncRendering = false;
            rpt.SizeToReportContent = true;
            rpt.ShowPrintButton = true;
            rpt.ShowZoomControl = true;
            ViewBag.rpt = rpt;
            return View();
        }

        // POST: Adultoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,Profesion,Centro_Laboral,Tipo_Sangre")] Adulto adulto, string txtpass)
        {
            if (ModelState.IsValid)
            {
                
                    db.Personas.Add(adulto);
                db.SaveChanges();
                //accedemos al modelo de la seguridad integrada
                ApplicationDbContext context = new ApplicationDbContext();
                //definimos las variables manejadoras de roles y usuarios
                var ManejadorRol = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var ManejadorUsuario = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var user = new ApplicationUser();
                user.Nombre = adulto.Nombres;
                user.Apellido = adulto.Apellidos;
                user.UserName = adulto.E_Mail;
                user.Email = adulto.E_Mail;
                string PWD = txtpass;
                var chkUser = ManejadorUsuario.Create(user, PWD);
                //si se creo con exito
                if (chkUser.Succeeded)
                {
                    ManejadorUsuario.AddToRole(user.Id, "Usuario");
                }
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", adulto.DepartamentoId);
            return View(adulto);
        }
        [AllowAnonymous]
        public ActionResult Solicitud()
        {
            ViewBag.sexo = new SelectList(new[] {
                new SelectListItem { Value = "Masculino", Text = "Masculino" },
                new SelectListItem { Value = "Femenino", Text = "Femenino" }
                                               }, "Value", "Text");
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento");
            return View();
        }
        //solicitud
        // POST: Adultoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Solicitud([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,Profesion,Centro_Laboral,Tipo_Sangre")] Adulto adulto)
        {

            if (ModelState.IsValid)
            {
                db.Personas.Add(adulto);
                db.SaveChanges();
                return RedirectToAction("MembreAdulto", "Membresia_Adulto", new { idAdulto = adulto.Id });
            }

            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", adulto.DepartamentoId);
            return View(adulto);
        }
        // GET: Adultoes/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.sexo = new SelectList(new[] {
                new SelectListItem { Value = "Masculino", Text = "Masculino" },
                new SelectListItem { Value = "Femenino", Text = "Femenino" }
                                               }, "Value", "Text");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adulto adulto = db.Adultos.Find(id);
            if (adulto == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Cod_Departamento", adulto.DepartamentoId);
            return View(adulto);
        }
        public ActionResult Renovar([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,Profesion,Centro_Laboral,Tipo_Sangre")] Adulto adulto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adulto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Cod_Departamento", adulto.DepartamentoId);
            return View(adulto);
        }
        // POST: Adultoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,Profesion,Centro_Laboral,Tipo_Sangre")] Adulto adulto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adulto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Cod_Departamento", adulto.DepartamentoId);
            return View(adulto);
        }

        // GET: Adultoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adulto adulto = db.Adultos.Find(id);
            if (adulto == null)
            {
                return HttpNotFound();
            }
            return View(adulto);
        }

        // POST: Adultoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adulto adulto = db.Adultos.Find(id);
            db.Personas.Remove(adulto);
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
