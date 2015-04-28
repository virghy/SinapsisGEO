using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;

namespace Reporting
{
    public partial class Mapa : System.Web.UI.Page
    {
        private DAL.SinapsisEntities db = new DAL.SinapsisEntities();
        private int IdEmpresa = 2;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtdFecha.Text = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).ToShortDateString();
            this.txthFecha.Text = DateTime.Today.ToShortDateString();
            if (Request.QueryString["titulo"] !=null)
            {
                this.lblTitulo.Text = Request.QueryString["titulo"];
            }

            if (Request.QueryString["Id"] != null)
            {
                this.IdReporte.Value = Request.QueryString["Id"];
            }


        }

        //public IEnumerable<SinapsisGEO.DAL.tel_Sucursal> GetSucursal([Control("cboSucursal")]int? IdEmpresa)
        public IEnumerable<DAL.tel_Sucursal> GetSucursal()
        {
            return this.db.tel_Sucursal.Where(p => p.IdEmpresa== IdEmpresa);
        }

        public IEnumerable<DAL.sys_ReportesGEO> GetReportes()
        {
            return this.db.sys_ReportesGEO.Where(p => p.IdEmpresa == IdEmpresa);
        }


        protected void btnCargar_Click(object sender, EventArgs e)
        {

        }

    }
}