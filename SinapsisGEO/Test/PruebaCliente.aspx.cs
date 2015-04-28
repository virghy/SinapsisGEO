using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisGEO.Test
{
    public partial class PruebaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           // this.ClienteEdit.CargarDatos(Convert.ToDouble(this.TextBox1.Text), 0);
        }

        protected void cmdEditar_Click(object sender, EventArgs e)
        {
            //this.ClienteEdit.CargarDatos(0, Convert.ToInt32( this.TextBox2.Text)); 
        }
    }
}