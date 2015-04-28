using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisWS
{
    public partial class TestWS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Pedidos ws = new Pedidos();
            WSPedido p = new WSPedido();
            List<WSPedidoDet> dt = new List<WSPedidoDet>();
            p.IdPersona = 1;
            p.IdDireccion = 1;
            p.Apellido = "Gonzalez w";
            p.CantidadItems = 2;
            p.Ciudad = "Asuncion w";
            p.Comentario = "Comentario w";
            p.Direccion = "Direccion w";
            p.Fecha_pedido = DateTime.Now;
            p.IdModulo = 1;
            p.Nombre = "Nombre w";
            p.NroPedido = 1;
            p.NroSucursal = 1;
            p.Referencia = "Referencia w";
            p.Ruc = "RUC w";
            p.Telefono = "Telefono w";

            WSPedidoDet pd = new WSPedidoDet();
            pd.NroItem = 1;
            pd.IdArticulo = "10597";
            pd.Precio = 15000;
            pd.Cantidad = 1;
            pd.Comentario = "Comentario 1";

            dt.Add(pd);

            WSPedidoDet pd2 = new WSPedidoDet();
            pd2.NroItem = 2;
            pd2.IdArticulo = "9726";
            pd2.Precio = 15000;
            pd2.Cantidad = 1;
            pd2.Comentario = "Comentario 2";
            pd2.NroItemPadre = 1;
            
            dt.Add(pd2);

            pd2 = new WSPedidoDet();
            pd2.NroItem = 2;
            pd2.IdArticulo = "9726";
            pd2.Precio = 15000;
            pd2.Cantidad = 1;
            pd2.Comentario = "Comentario 3";
           // pd2.NroItemPadre = 1;

            dt.Add(pd2);


           int r= ws.EnviarPedido(p, dt);
           this.lblResultado.Text = r.ToString();

        }
    }
}