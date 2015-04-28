using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reporting
{
    public partial class _Default : Page
    {
        DAL.SinapsisEntities db = new DAL.SinapsisEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.cboEmpresa.DataSource=db.sys_rptGetEmpresas(this.User.Identity.Name).ToList();
                this.cboEmpresa.DataBind();

                if ( Session["IdEmpresa"] !=null)
                {
                   this.cboEmpresa.SelectedValue = Session["IdEmpresa"].ToString();
                }

                if (this.cboEmpresa.SelectedValue != null)
                {
                    CargarReportes();         
                    
                }
            }

        }

        void CargarReportes()
        {

            this.DataList1.DataSource = db.sys_rptGetReportes(Convert.ToInt32(cboEmpresa.SelectedValue)).ToList();
            this.DataList1.DataBind();
            Session["IdEmpresa"] = this.cboEmpresa.SelectedValue;
        }
        protected void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarReportes();
   
        }
    }
}