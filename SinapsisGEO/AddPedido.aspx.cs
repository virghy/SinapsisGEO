using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisGEO
{
    public partial class AddPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int IdCliente=0;
            int IdDireccion=0;
            string Tipo = null;
            
            if (!string.IsNullOrEmpty(Request.QueryString["IdCliente"]))
            {
                IdCliente = Convert.ToInt32(Request.QueryString["IdCliente"]);
            }

            if (!string.IsNullOrEmpty(Request.QueryString["IdDireccion"]))
            {
                IdDireccion = Convert.ToInt32(Request.QueryString["IdDireccion"]);
            }

            if (!string.IsNullOrEmpty(Request.QueryString["Tipo"]))
            {
                Tipo = Request.QueryString["Tipo"];
            }

            DAL.SinapsisEntities db = new DAL.SinapsisEntities();

            DAL.tel_Carrito car = new DAL.tel_Carrito();


            DAL.tel_Clientes cl = db.tel_Clientes.Find(IdCliente);
            DAL.Tel_Direcciones dir = db.Tel_Direcciones.Find(IdDireccion);

            //Asignamos los valores
            car.IdCliente = cl.IdCliente;
            car.IdEmpresa = Global.IdEmpresa;
            car.IdTipoPedido = Tipo;

            car.Audit_Fecha = DateTime.Now;
            car.UserName = this.User.Identity.Name;
            car.Fecha = DateTime.Today;
            
            car.Nombre = cl.Nombre;
            car.Apellido = cl.Apellido;

            car.IdDireccion = dir.Id;
            car.Direccion = dir.Direccion;
            db.tel_Carrito.Add(car);
            db.SaveChanges();

            Response.Redirect(string.Format("~/Pedido.aspx?Id={0}",car.IdCarrito));

        }
    }
}