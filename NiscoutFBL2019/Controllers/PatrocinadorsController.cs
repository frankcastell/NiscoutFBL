using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NiscoutFBL2019.Models;
using NiscoutFBL2019.Models.ReporteScouts;
using Microsoft.Reporting.WebForms;

namespace NiscoutFBL2019.Controllers
{
    [Authorize]
    public class PatrocinadorsController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Patrocinadors
        public ActionResult Index(string buscar)
        {
            var patrocinadores = db.Patrocinadores.Include(p => p.Departamento);

            if (!string.IsNullOrEmpty(buscar))
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
            Patrocinador patrocinador = db.Patrocinadores.Find(id);
            if (patrocinador == null)
            {
                return HttpNotFound();
            }
            return View(patrocinador);
        }

        // GET: Patrocinadors/Create
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
            return View();
        }
        //Reporte de patrocinador Clase similares aldataset
        public class PatroRep
        {
            public string Column1 { get; set; }
            public string Column2 { get; set; }
            public string Column3 { get; set; }
            public string Column4 { get; set; }
            public string Column5 { get; set; }
            //agregar nuevas columnas x los campos

        }
        // Listando 
        public List<PatroRep> GetPatron()
        {
            return (from item in db.Patrocinadores.ToList()

                    select new PatroRep
                    {
                        Column1 = item.Nombre_Insti,
                        Column2 = item.Nombre_Representante,
                        Column3 = item.Telefono.ToString(),
                        Column4 = item.Trabajo,
                        Column5 = item.Direccion
                    }).ToList();
        }
        // Listando ala vista
        public ActionResult RepPatro()
        {
            //var fecha = DateTime;
            DataSetScout.DataTable2DataTable p = new DataSetScout.DataTable2DataTable();
            ReportViewer rpt = new ReportViewer();
            rpt.ProcessingMode = ProcessingMode.Local;
            rpt.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath + @"Reportes/RepPatro.rdlc");
            rpt.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", GetPatron()));
            rpt.LocalReport.Refresh();

            rpt.AsyncRendering = false;
            rpt.SizeToReportContent = true;
            rpt.ShowPrintButton = true;
            rpt.ShowZoomControl = true;
            ViewBag.rpt = rpt;
            return View();
        }


        // POST: Patrocinadors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,Profesion,Centro_Laboral,Tipo_Sangre,Nombre_Insti,Nombre_Representante,Trabajo")] Patrocinador patrocinador)
        {
            patrocinador.Cod_Persona = "ASN" + patrocinador.Fecha_Nac.ToShortDateString() + DateTime.Now.Year.ToString();
            if (ModelState.IsValid)
            {
                db.Personas.Add(patrocinador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", patrocinador.DepartamentoId);
            return View(patrocinador);
        }

        // GET: Patrocinadors/Edit/5
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
            Patrocinador patrocinador = db.Patrocinadores.Find(id);
            if (patrocinador == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", patrocinador.DepartamentoId);
            return View(patrocinador);
        }

        // POST: Patrocinadors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId,Profesion,Centro_Laboral,Tipo_Sangre,Nombre_Insti,Nombre_Representante,Trabajo")] Patrocinador patrocinador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patrocinador).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", patrocinador.DepartamentoId);
            return View(patrocinador);
        }

        // GET: Patrocinadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patrocinador patrocinador = db.Patrocinadores.Find(id);
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
            Patrocinador patrocinador = db.Patrocinadores.Find(id);
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
