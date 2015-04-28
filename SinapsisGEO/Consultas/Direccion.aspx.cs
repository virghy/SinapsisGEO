using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisGEO.Consultas
{
    public partial class Direccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdBuscar_Click(object sender, EventArgs e)
        {
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                this.grvDireccion.DataSource = db.tel_AppBuscaDireccion(this.txtDir1.Text, this.txtDir2.Text.Length > 0 ? this.txtDir2.Text : "%", this.txtDir3.Text.Length > 0 ? this.txtDir3.Text : "%", this.txtDir4.Text.Length > 0 ? this.txtDir4.Text : "%").ToList();
                this.grvDireccion.DataBind();
            }
        }
    }
}