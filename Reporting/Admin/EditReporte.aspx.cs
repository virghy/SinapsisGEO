using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Reporting.Admin
{
    public partial class EditReporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdAgregar_Click(object sender, EventArgs e)
        {
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                try
                {
                    this.lblError.Text = "";
                    DAL.sys_ReporteEmpresa r = new DAL.sys_ReporteEmpresa();
                    r.IdEmpresa = Convert.ToInt32(this.txtEmpresa.Text);
                    r.IdReporte = Convert.ToInt32(Request.QueryString["IdReporte"]);
                    r.Activo = true;
                    db.sys_ReporteEmpresa.Add(r);
                    db.SaveChanges();
                    this.GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    this.lblError.Text = Utility.GetMessageError(ex);
                    
                }
            }
        }
    }
}