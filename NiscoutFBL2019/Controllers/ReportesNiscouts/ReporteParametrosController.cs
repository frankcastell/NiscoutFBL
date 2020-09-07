using Microsoft.Reporting.WebForms;
using NiscoutFBL2019.Models;
using System.Web.Mvc;
using System.Net;
using NiscoutFBL2019.BDNiscoutDataSetTableAdapters;
using System.Data.Entity;
using System.Linq;

namespace NiscoutFBL2019.Controllers.ReportesNiscouts
{
    public class ReporteParametrosController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();
        // GET: ReporteParametros
        public ActionResult Index()
        {
           
            return View();
        }
        //public ActionResult VistaPrevia(int? id)
        //{
        //    //Comprobamos que se haya realizado el envio del parametro correcto.

        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    Persona doc = db.Personas.Find(id);
        //    if (doc == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    //Instancia de reporte.

        //    ReportViewer report = new ReportViewer();

        //    //Modo de procesamiento del reporte local, porque estara en el mismo servidor, no en una instancia de SQL reporting services.

        //    report.ProcessingMode = ProcessingMode.Local;

        //    //Se establece la ruta del documento en el servidor de la aplicacion.

        //    report.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reporting/Estrategicos/Direccion/Imparcialidad/ccReport.rdlc";

        //    //Ajustamos el reporte al tamaño de la vista..

        //    report.SizeToReportContent = true;

        //    //Enviar parametros del reporte
        //    string Sexo =
        //        doc.Sexo;
        //    report.LocalReport.SetParameters(

        //        new ReportParameter[]
        //        {
        //            new ReportParameter ("cuerpoDocumento", doc.Sexo)
                    
        //                          }
        //        );

        //    //Mostrar el boton imprimir
        //    report.ShowPrintButton = true;
        //    //Mostrar boton refrescar
        //    report.ShowRefreshButton = true;
        //    //Mostrar boton map
        //    report.ShowDocumentMapButton = true;
        //    ViewBag.Sex = report;
        //    return View();
        //}
        public ActionResult Informe(string Sexo= "")
        {
            var sexo = db.Personas.Where(x => x.Sexo == Sexo);
            
            Total_SexoTableAdapter V = new Total_SexoTableAdapter();
            ReportViewer rpt = new ReportViewer();
            rpt.ProcessingMode = ProcessingMode.Local;
            rpt.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes/RepSexoParametro.rdlc";
            rpt.LocalReport.DataSources.Add(new ReportDataSource("BDNiscoutDataSet", V.GetData(Sexo).ToList()));
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("Sexo",sexo.ToString());
            rpt.LocalReport.SetParameters(parameters);
            rpt.SizeToReportContent = true;
            rpt.ShowPrintButton = true;
            rpt.ShowZoomControl = true;
            ViewBag.rpt = rpt;
            return View();
        }
        public ActionResult ReptDepart(string Departamento = "")
        {

            Total_DepartamentoTableAdapter d = new Total_DepartamentoTableAdapter();
            ReportViewer rpt = new ReportViewer();
            rpt.ProcessingMode = ProcessingMode.Local;
            rpt.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes/RepTotalDepart.rdlc";
            rpt.LocalReport.DataSources.Add(new ReportDataSource("BDNiscoutDataSet", d.GetData(Departamento).ToList()));
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("Departamento");
            rpt.LocalReport.SetParameters(parameters);
            rpt.SizeToReportContent = true;
            rpt.ShowPrintButton = true;
            rpt.ShowZoomControl = true;
            ViewBag.rpt = rpt;
            return View();
        }

        public ActionResult ReptAño(string Año = "")
        {

            Total_añosTableAdapter a = new Total_añosTableAdapter();
           
            ReportViewer rpt = new ReportViewer();
            rpt.ProcessingMode = ProcessingMode.Local;
            rpt.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes/ReportTotalAño.rdlc";
            rpt.LocalReport.DataSources.Add(new ReportDataSource("BDNiscoutDataSet", a.GetData(Año).ToList()));
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("Año");
            rpt.LocalReport.SetParameters(parameters);
            rpt.SizeToReportContent = true;
            rpt.ShowPrintButton = true;
            rpt.ShowZoomControl = true;
            ViewBag.rpt = rpt;
            return View();
        }
        public ActionResult ReptMembresiaTotal(string Depar = "")
        {

            Membresia_TotalTableAdapter m = new Membresia_TotalTableAdapter();
            ReportViewer rpt = new ReportViewer();
            rpt.ProcessingMode = ProcessingMode.Local;
            rpt.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes/ReptMembresia_total.rdlc";
            rpt.LocalReport.DataSources.Add(new ReportDataSource("BDNiscoutDataSet", m.GetData(Depar).ToList()));
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("Depar");
            rpt.LocalReport.SetParameters(parameters);
            rpt.SizeToReportContent = true;
            rpt.ShowPrintButton = true;
            rpt.ShowZoomControl = true;
            ViewBag.rpt = rpt;
            return View();
        }
    }
}
