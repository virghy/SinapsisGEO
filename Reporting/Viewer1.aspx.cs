using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reporting
{
    public partial class Viewer1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Request.Params["value"] != null))
                {
                    string nombrereporte = Request.Params["value"];
                    string titulo = Request.Params["titulo"];
                    this.lbltitulo.Text = titulo.Trim();
                    this.ReportViewer1.ServerReport.ReportPath = "/DELIVERY/" + nombrereporte.Trim();
                    //Dim cr As Microsoft.Reporting.WebForms.IReportServerCredentials

                    //Me.ReportViewer1.ServerReport.ReportServerCredentials

                    //Dim parametro As New Microsoft.Reporting.WebForms.ReportParameter("Empresa", Profile.Empresa)



                    string IdEmpresa;

                    if (Session["IdEmpresa"] != null)
                    {
                        IdEmpresa = Session["IdEmpresa"].ToString();
                    }
                    else
                    {
                        IdEmpresa = "1";
                    }

                    Microsoft.Reporting.WebForms.ReportParameter[] pa = new Microsoft.Reporting.WebForms.ReportParameter[1];

                    pa[0] = new Microsoft.Reporting.WebForms.ReportParameter("Empresa", IdEmpresa);
                    this.ReportViewer1.ServerReport.SetParameters(pa);

                    //Me.SimpleReportViewer.ServerReport.ReportServerUrl = ""
                }
            }

        }
    }
}