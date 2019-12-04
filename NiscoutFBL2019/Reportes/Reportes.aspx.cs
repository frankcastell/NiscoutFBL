using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGCLAFRAM.Reporting.Operacionales
{
    public partial class ReportesApoyo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                String Reporte = "/Reportes/" + Request.QueryString["ReportesApoyo"];
                RVCatalogo.ServerReport.ReportPath = Reporte;
                RVCatalogo.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["ReportServerUrl"]);
                EstablecerParametros();
            }
        }

        protected void RVCatalogo_PreRender(object sender, EventArgs e)
        {
            List<string> ExportacionPermitida = new List<string>();
            switch (Request.QueryString["ReportesApoyo"])
            {
                case "ReporteActaCompleta(ADDP)":
                case "ReporteActaSimple":
                case "ReporteActaEnBlanco(ADDP)":
                case "ReporteActaEnBlanco(ASFE)":
                case "ReporteActaEnBlanco(ANF)":
                case "ReporteActaNotaFinal":
                    ExportacionPermitida.Add("PDF");
                    break;
            }
        }

        public void EstablecerParametros()
        {
            try
            {
                List<ReportParameter> Parametros = new List<ReportParameter>();                switch (Request.QueryString["ReportesApoyo"])
                {

                    case "ADFG01":
                        //Parametros.Add(new ReportParameter("id", Request.QueryString["IdPersona"]));
                        //Parametros.Add(new ReportParameter("usuario", WebMatrix.WebData.WebSecurity.CurrentUserName.Trim().ToUpper()));
                        break;

                





                }                this.RVCatalogo.ServerReport.SetParameters(Parametros);
            }

            catch (Exception ex)
            {

                throw;
            }
        }
    }
}