using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace SinapsisGEO.Consultas
{
    public partial class Tablero : System.Web.UI.Page
    {
        private DAL.SinapsisEntities db = new SinapsisEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
            //setSucursal();
            //ScriptManager.RegisterStartupScript(
            //            UpdatePanel1,
            //            this.GetType(),
            //            "MyAction",
            //            "DoFiltrar();",
            //            true);

        }
        public IQueryable<DAL.tel_Carrito> GetCarrito()
        {

            var query = this.db.tel_Carrito.Include("tel_Clientes").Include("tel_Direcciones").Include("tel_Carrito_Item").Where(p => p.IdEmpresa == Global.IdEmpresa && p.UserName == "web" && p.Estado == null);
            return query;

        }

        void GetData()
        {
            //this.Repeater1.DataBind();
            this.grvPedidos.DataBind();
            if (this.grvPedidos.Rows.Count > 0)
            {
                this.Notificar.Value = "S";
            }
            this.lblHora.Text = DateTime.Now.ToString("HH:mm");
            //int IdSucursal = 0;
            
            //if (Request.QueryString["Id"]!=null)
            //{
            //    IdSucursal=Convert.ToInt32(Request.QueryString["Id"]);
            //}

            //List<Tel_TableroPedidos_Result> l = db.Tel_TableroPedidos(IdSucursal, Global.IdEmpresa).ToList();
            //grvPedidos.DataSource = l;
            //grvPedidos.DataBind();
            
            //this.Notificar.Value = "N";
            //foreach (var item in l)
            //{

            //    if (item.Estado.StartsWith("P") && item.tCola.Value>=5)
            //    {
            //        if (item.Estado.Contains("L"))
            //        {
            //            continue;
            //        }
            //        this.Notificar.Value = "S";
            //        break; 
            //    }
            //}


        }

        //void setSucursal()
        //{
        //    int IdSucursal = 0;

        //    if (Request.QueryString["Id"] != null)
        //    {
        //        IdSucursal = Convert.ToInt32(Request.QueryString["Id"]);
        //    }

        //    DAL.tel_Sucursal Suc = BLL.CacheManager.GetSucursales().Where(p => p.IdSucursal == IdSucursal).FirstOrDefault();

        //    if (Suc != null)
        //    {
        //        this.lblSucursal.Text = string.Format("{0} - {1}", Suc.IdSucursal, Suc.Sucursal);
        //        if (Suc.TiempoServicio.HasValue)
        //        {
        //            this.lblTiempo.Text = Suc.TiempoServicio.Value.ToString();
        //        }

        //    }

        //}

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            GetData();
         //   setSucursal();
            
        }
    }
}