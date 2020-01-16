using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using Microsoft.AspNet.Identity;
using NiscoutFBL2019.Models.ReporteScouts;
using NiscoutFBL2019.Models;
using NiscoutFBL2019.Models.ReporteScouts.DataSetScoutTableAdapters;

namespace NiscoutFBL2019.Controllers.ReportesNiscouts
{
    
    public class ReportesController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();
        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }
        //Clases del centro de estudio
        public class AdminR
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
            public string Column10 { get; set;}
            public string Column11 { get; set;}
            public string Column12 { get; set;}
            public string Column13 { get; set;}
        }
        // Listando 
        public List<AdminR> GetAdmin()
        {
            return (from item in db.Personal_Admon.ToList()

                    select new AdminR
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
                        Column11 = item.Estado_Civil,
                        Column12=item.Cargo.Nombre_Cargo,
                        Column13=item.Cod_Persona
                       
                      }).ToList();
        }
        // Listando ala vista
        public ActionResult RepAdmin()
        {
            //var fecha = DateTime;
            DataSetScout.DataTable3DataTable p = new DataSetScout.DataTable3DataTable();            
            ReportViewer rpt = new ReportViewer();
            rpt.ProcessingMode = ProcessingMode.Local;
            rpt.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath + @"Reportes/RepAdmin.rdlc");
            rpt.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", GetAdmin()));
            rpt.LocalReport.Refresh();

            rpt.AsyncRendering = false;
            rpt.SizeToReportContent = true;
            rpt.ShowPrintButton = true;
            rpt.ShowZoomControl = true;
            ViewBag.rpt = rpt;
            return View();
        }


        public ActionResult ReporCentro()
        {

            //var fecha = DateTime;
            Centro_EstudiosTableAdapter P = new Centro_EstudiosTableAdapter();           
            ReportViewer rpt = new ReportViewer();
            rpt.ProcessingMode = ProcessingMode.Local;
            rpt.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath + @"Reportes/RepCentro.rdlc");          
            rpt.LocalReport.DataSources.Add(new ReportDataSource("DataSet1",P.GetData().ToList()));
            rpt.LocalReport.Refresh();

            rpt.AsyncRendering = false;
            rpt.SizeToReportContent = true;
            rpt.ShowPrintButton = true;
            rpt.ShowZoomControl = true;
            ViewBag.rpt = rpt;
            return View();
        }
        public ActionResult ReporUbicaciones() // Inicio Reporte Ubicaciones
        {

            //var fecha = DateTime;
            
            DataTable5TableAdapter P = new DataTable5TableAdapter();
            ReportViewer rpt = new ReportViewer();
            rpt.ProcessingMode = ProcessingMode.Local;
            rpt.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath + @"Reportes/RepUbicaciones.rdlc");
            rpt.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", P.GetData().ToList()));
            rpt.LocalReport.Refresh();

            rpt.AsyncRendering = false;
            rpt.SizeToReportContent = true;
            rpt.ShowPrintButton = true;
            rpt.ShowZoomControl = true;
            ViewBag.rpt = rpt;
            return View();
        }
        // fin de el reporte Ubicaciones
        public ActionResult ReporJovenes() // Inicio Reporte Jovenes
        {

            //var fecha = DateTime;
            DataTable4TableAdapter P = new DataTable4TableAdapter();
            
            ReportViewer rpt = new ReportViewer();
            rpt.ProcessingMode = ProcessingMode.Local;
            rpt.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath + @"Reportes/RepJovenes.rdlc");

            rpt.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", P.GetData().ToList()));
            rpt.LocalReport.Refresh();

            rpt.AsyncRendering = false;
            rpt.SizeToReportContent = true;
            rpt.ShowPrintButton = true;
            rpt.ShowZoomControl = true;
            ViewBag.rpt = rpt;
            return View();
        }
        
    }
}