using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisGEO
{
    public partial class Producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string idproducto = Request.QueryString["IdProducto"];
                if (idproducto != null)
                {
                    CargarProducto(idproducto);
                }
            }

        }

        public void CargarProducto(string IdProducto)
        {
            var p = BLL.Tablas.GetProductoById(IdProducto);
            if (p != null)
            {
                //this.imgProducto.ImageUrl = Page.ResolveUrl("~/images/productos/" + p.Imagen);
                
                this.lblProducto.Text = p.Descripcion;
                this.lblPrecio.Text = "20000";
                this.lblImporte.Text = "20000";
                this.IdProducto.Text = p.IdProducto.ToString();

                foreach (DAL.tel_ProductoOpcion item in p.tel_ProductoOpcion)
                {
                    var op = (Control.Opciones)LoadControl("~\\Control\\Opciones.ascx");
                    op.IdOpcion = item.IdOpcion.Value;
                    this.PlaceHolder1.Controls.Add(op);
                }
                var opciones = BLL.Tablas.GetOpciones(p.IdProducto,p.IdGrupo,p.IdFamilia,p.IdLinea);

                foreach (DAL.tel_ProductoOpcion item in opciones)
                {
                    var op = (Control.Opciones)LoadControl("~\\Control\\Opciones.ascx");
                    op.IdOpcion = item.IdOpcion.Value;
                    this.PlaceHolder1.Controls.Add(op);
                }



            }
        }

    }
}