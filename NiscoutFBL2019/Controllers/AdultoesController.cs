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
namespace NiscoutFBL2019.Controllers
{
    [Authorize]
    public class AdultoesController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Adultoes
        public ActionResult Index(string buscar)
        {

            var adulto = from s in db.Adultos
                         select s; db.Adultos.Include(a => a.Departamento);
            
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
            Adulto adulto = (Adulto)db.Personas.Find(id);
            if (adulto == null)
            {
                return HttpNotFound();
            }
            return View(adulto);
        }

        // GET: Adultoes/Create
        public ActionResult Create()
        {
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento");
            return View();
        }

        // clases similar al dataset
        public class adultosR
        {
           public string Column1 { get; set; }
           public  string Column2 { get; set; }
        }

        // Listando 
        public List<adultosR> GetAdulto()
        {
            return (from item in db.Adultos.ToList()
                    
                    select new adultosR
                    {
                        Column1 = item.Nombres,
                        Column2 = item.Apellidos
                       
                    }).ToList();
        }

        // Listando ala vista
        public ActionResult RepAdulto()
        {
            //var fecha = DateTime;
            DataSetScout.DataTable1DataTable p = new DataSetScout.DataTable1DataTable();
            ReportViewer rpt = new ReportViewer();
            rpt.ProcessingMode = ProcessingMode.Local;
            rpt.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath + @"Reportes/ReporteAdulto.rdlc");
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
        public ActionResult Create([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId")] Adulto adulto)
        {
            if (ModelState.IsValid)
            {
                db.Personas.Add(adulto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", adulto.DepartamentoId);
            return View(adulto);
        }
        [AllowAnonymous]
        public ActionResult Solicitud()
        {
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento");
            return View();
        }
        // POST: Adultoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Solicitud([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId")] Adulto adulto)
        {
             
            if (ModelState.IsValid)
            {
                db.Personas.Add(adulto);
                db.SaveChanges();
                return RedirectToAction("MembresiaAdulto","Membresia_Adulto", new { idAdulto=adulto.Id});
            }
           
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre_Departamento", adulto.DepartamentoId);
            return View(adulto);
        }
        // GET: Adultoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adulto adulto = (Adulto)db.Personas.Find(id);
            if (adulto == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Cod_Departamento", adulto.DepartamentoId);
            return View(adulto);
        }
        public ActionResult Renovar([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId")] Adulto adulto)
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
        public ActionResult Edit([Bind(Include = "Id,Cod_Persona,Nombres,Apellidos,Fecha_Nac,E_Mail,Cedula,Sexo,Estado_Civil,Num_Pasaporte,Telefono,Direccion,DepartamentoId")] Adulto adulto)
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
            Adulto adulto = (Adulto)db.Personas.Find(id);
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
            Adulto adulto = (Adulto)db.Personas.Find(id);
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
