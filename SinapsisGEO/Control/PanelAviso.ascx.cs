using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisGEO.Control
{
    public partial class PanelAviso : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                CargarDatos();
                //this.rptSucursales.DataSource = BLL.CacheManager.GetSucursales();
                //this.rptSucursales.DataBind();

            }
        }

        public void CargarDatos()
        {
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                if (Request.QueryString["Id"] != null)
                {
                    int IdPedido = Convert.ToInt32(Request.QueryString["Id"]);
                    DAL.tel_Carrito pd = db.tel_Carrito.Find(IdPedido);
                    if (pd != null)
                    {
                        
                        this.rptSucursales.DataSource = BLL.CacheManager.GetSucursales().Where(p=> p.IdSucursal==pd.IdSucursal.Value);
                        this.rptSucursales.DataBind();

                        this.rptFaltantes.DataSource = BLL.CacheManager.GetFaltantes().Where(p => p.IdSucursal == pd.IdSucursal.Value);
                        this.rptFaltantes.DataBind();
                    }

                }

            }
        
        }
    }
}