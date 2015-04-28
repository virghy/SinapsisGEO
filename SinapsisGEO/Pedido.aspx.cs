using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisGEO
{
    public partial class Pedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Tab1.CssClass = "Clicked";
                MainView.ActiveViewIndex = 0;
                this.PanelProducto.ActualizarAvisos();
            }

        }

        protected void Tab1_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Clicked";
            Tab2.CssClass = "Initial";
            Tab3.CssClass = "Initial";
            MainView.ActiveViewIndex = 0;
             this.PanelProducto.ActualizarAvisos();
        }

        protected void Tab2_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Initial";
            Tab2.CssClass = "Clicked";
            Tab3.CssClass = "Initial";
            MainView.ActiveViewIndex = 1;
            this.PanelAddProducto.ActualizarControles();

        }

        protected void Tab3_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Initial";
            Tab2.CssClass = "Initial";
            Tab3.CssClass = "Clicked";
            MainView.ActiveViewIndex = 2;
            this.PanelPedido.CargarDatos();
        }

        public void CargarProducto(string IdProducto)
        {
            this.PanelAddProducto.CargarProducto(IdProducto);
            this.Tab2_Click(null, null);
        }

        public void ProductoCargado() 
        {
            this.Tab1_Click(null, null);
            this.PanelProducto.ActualizarCarrito();
        }
        void ActualizarDatos()
        { 
        
        }

        public void AddAgregados(string Valor, String Nombre)
        {
            this.PanelAddProducto.AddAgregados(Valor,Nombre);
        }


    }
}