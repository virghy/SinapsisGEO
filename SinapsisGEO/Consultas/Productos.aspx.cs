using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisGEO.Consultas
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void CargarProducto(string IdProducto)
        {
            this.PanelProducto.Visible = false;
            this.PanelAddProducto.Visible = true;
            this.PanelAddProducto.CargarProducto(IdProducto);
           
        }
        public void Cancelar()
        {
            this.PanelProducto.Visible = true;
            this.PanelAddProducto.Visible = false;

        }
    }
}