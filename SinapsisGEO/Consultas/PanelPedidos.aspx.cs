using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;

namespace SinapsisGEO.Consultas
{
    public partial class PanelPedidos : System.Web.UI.Page
    {
         private DAL.SinapsisEntities db = new SinapsisEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.dltSucursal.DataSource = this.GetSucursal().ToList();
            this.dltSucursal.DataBind();
            this.lblHora.Text = DateTime.Now.ToString("HH:mm");
        }

        public IQueryable<DAL.tel_Sucursal> GetSucursal()
        {
            var query = this.db.tel_Sucursal.Where(p => p.IdEmpresa == Global.IdEmpresa);

            //this.ASPxDataView1.DataSource = query.ToList();
            //this.ASPxDataView1.DataBind();
            return query;
        }

        public IQueryable<DAL.tel_Pedidos> GetPedidos([Control("txtTelefono")] int? IdSucursal)
        {
            var query = this.db.tel_Pedidos.Where(p => p.IdEmpresa == Global.IdEmpresa & p.IdSucursal==IdSucursal);

            //this.ASPxDataView1.DataSource = query.ToList();
            //this.ASPxDataView1.DataBind();
            return query;
        }

        protected void dltSucursal_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            GridView gv = (GridView)e.Item.FindControl("grvPedidos");
            int IdSucursal = ((tel_Sucursal)e.Item.DataItem).IdSucursal;

            gv.DataSource = db.Tel_TableroPedidos(IdSucursal, Global.IdEmpresa);
            gv.DataBind();


        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            this.dltSucursal.DataSource = this.GetSucursal().ToList();
            this.dltSucursal.DataBind();
            //this.grvCola.DataSource = rpt_GetData();
            this.grvCola.DataBind();
            this.lblHora.Text =  DateTime.Now.ToString("HH:mm");
        }

        public List<Sucursal> rpt_GetData()
        {
            var ws = new GEOService();
            return ws.TiempoCola(Global.IdEmpresa);
        }


    }
}