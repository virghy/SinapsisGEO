using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
namespace SinapsisGEO.MailTemplate
{
    public partial class VerPedido : System.Web.UI.Page
    {
        private DAL.SinapsisEntities db = new DAL.SinapsisEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<DAL.tel_Pedidos> GetPedidos([QueryString] int? IdPedido)
        {
            //int? NroPedido=null;

            //if (this.txtNroPedido.Text != string.Empty)
            //{
            //    NroPedido = Convert.ToInt32(this.txtNroPedido.Text);

            //}

            var query = this.db.tel_Pedidos.Include("tel_PedidosDet").Include("tel_PedidosDet.tel_Productos").Include("tel_TipoPedido").Include("tel_FormaPago").Where(p => p.IdEmpresa == Global.IdEmpresa & (p.IdPedido == IdPedido));

            //this.ASPxDataView1.DataSource = query.ToList();
            //this.ASPxDataView1.DataBind();
            return query;
        }

        public IQueryable<DAL.tel_Comentarios> GetComentarios([Control("DetailsView1")] int? NroPedido)
        {
            //int? NroPedido=null;

            //if (this.txtNroPedido.Text != string.Empty)
            //{
            //    NroPedido = Convert.ToInt32(this.txtNroPedido.Text);

            //}

            var query = this.db.tel_Comentarios.Include("tel_TipoReclamo").Where(p => p.IdEmpresa == Global.IdEmpresa & p.IdPedido == NroPedido);

            //this.ASPxDataView1.DataSource = query.ToList();
            //this.ASPxDataView1.DataBind();
            return query;
        }
       
    }
}