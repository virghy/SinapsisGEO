using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;

namespace SinapsisGEO.Consultas
{
    public partial class QPedidos : System.Web.UI.Page
    {
        DAL.SinapsisEntities db = new DAL.SinapsisEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                this.txtdFecha.Text = DateTime.Today.ToShortDateString();
                this.txthFecha.Text = DateTime.Today.ToShortDateString();

                BLL.Tablas tb = new BLL.Tablas(db);

                var datasource = from x in db.UsersInfoes
                                 orderby x.Nombre,x.Apellido,x.UserName
                                 select new
                                 {
                                     x.UserName,
                                     FullName = x.Nombre + " " + x.Apellido + " (" + x.UserName + ")"
                                 };

                this.cboOperador.DataSource = datasource.ToList();
                this.cboOperador.DataBind();

                this.cboSucursal.DataSource = tb.GetSucursales().ToList();
                this.cboSucursal.DataBind();



            }

        }

        protected void cmdBuscar_Click(object sender, EventArgs e)
        {
            this.grdPedidos.DataBind();
        }

        // El tipo devuelto puede ser modificado a IEnumerable, sin embargo, para ser compatible con paginación y ordenación ,
//     se deben agregar los siguientes parametros:
//     int maximumRows
//     int startRowIndex
//     out int totalRowCount
//     string sortByExpression
        public IQueryable<DAL.tel_Pedidos> grdPedidos_GetData([Control("txtdFecha")] DateTime? dFecha, [Control("txthFecha")] DateTime? hFecha, [Control("cboOperador")] string Operador, [Control("cboSucursal")] int? IdSucursal)
{
    if (this.IsPostBack)
    {
        var query = from p in db.tel_Pedidos
                    where p.IdEmpresa == Global.IdEmpresa & p.Fecha >= dFecha & p.Fecha <= hFecha & (p.UserName == Operador | Operador == "-") & (p.IdSucursal == IdSucursal | IdSucursal == 0)
                    orderby p.IdPedido
                    select p;
        return query;
        
    }
    return null;

}
    }
}