using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisGEO.Remote
{
    public partial class TiempoServicio : System.Web.UI.Page
    {
        DAL.SinapsisEntities db;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int IdSucursal = Convert.ToInt32(Request.QueryString["Id"]);
                using (db = new DAL.SinapsisEntities())
                {
                    DAL.tel_Sucursal Suc = db.tel_Sucursal.Where(p => p.IdEmpresa == Global.IdEmpresa && p.IdSucursal == IdSucursal).FirstOrDefault();
                    if (Suc != null)
                    {
                        this.lblSucursal.Text = string.Format("{0} - {1}", Suc.IdSucursal, Suc.Sucursal);
                        if (Suc.TiempoServicio.HasValue)
                        {
                            this.cboTiempo.SelectedValue= Suc.TiempoServicio.Value.ToString();
                        }
                        else
                        {
                            this.cboTiempo.SelectedValue = "30";
                        }

                    }


                }
            }
        }

        protected void cmdActualizar_Click(object sender, EventArgs e)
        {
            using (db = new DAL.SinapsisEntities())
            {
                int IdSucursal = Convert.ToInt32(Request.QueryString["Id"]);
                DAL.tel_Sucursal Suc = db.tel_Sucursal.Where(p => p.IdEmpresa == Global.IdEmpresa && p.IdSucursal == IdSucursal).FirstOrDefault();
                if (Suc != null)
                {

                    Suc.TiempoServicio = Convert.ToInt32(this.cboTiempo.SelectedValue);
                    db.SaveChanges();
                    BLL.CacheManager.RemoverCache(BLL.CacheManager.chkSucursal);
                    Response.Redirect( string.Format("~/Remote/Tablero.aspx?Id={0}",Convert.ToInt32(Request.QueryString["Id"])));
                }


            }

        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/Remote/Tablero.aspx?Id={0}", Convert.ToInt32(Request.QueryString["Id"])));
        }
    }
}