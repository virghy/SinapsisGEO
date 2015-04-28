using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
namespace SinapsisGEO.Control
{
    public partial class PedidosTop5 : System.Web.UI.UserControl
    {
        private SinapsisEntities db = new SinapsisEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<DAL.tel_Pedidos> GetPedidos(int IdCliente)
        {
            var query = this.db.tel_Pedidos.Where(p => p.IdEmpresa == Global.IdEmpresa & p.IdCliente==IdCliente);

            return query.OrderByDescending(p => p.Audit_Fecha).Take(5);

        }

        public void CargarDatos(int IdCliente)
        {
            this.Repeater1.DataSource = GetPedidos(IdCliente).ToList();
            this.Repeater1.DataBind();
        }

        protected void btnDuplicar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
           BLL.CarritoBLL cr = new BLL.CarritoBLL(db);
           cr.DuplicarPedido(Convert.ToInt32(btn.CommandArgument), this.Page.User.Identity.Name);
           db.SaveChanges();
           Response.Redirect(String.Format("~/Pedido.aspx?Id={0}", cr.cr.IdCarrito));
        }


    }
}