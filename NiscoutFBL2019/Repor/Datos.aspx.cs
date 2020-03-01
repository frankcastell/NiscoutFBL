using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NiscoutFBL2019.Repor
{
    public partial class Datos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //// Vamos Aconectar con nuestra base datos
            //SqlConnection cn = new SqlConnection("Data Source=.;initial catalog=BDNiscout;integrated security=True");
            //SqlDataAdapter da = new SqlDataAdapter("Total_Sexo", cn);
            //DataTable dt = new DataTable();
            //da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //da.SelectCommand.Parameters.Add("@Sexo", SqlDbType.Text).Value = (TextBox1.Text);
            //da.Fill(dt);
            //ReportViewer1.LocalReport.DataSources.Clear();
            //ReportDataSource rpt = new ReportDataSource("BDNiscoutDataSet", dt);
            //ReportViewer1.LocalReport.DataSources.Add(rpt);
            //ReportViewer1.LocalReport.Refresh();
        }
    }
}