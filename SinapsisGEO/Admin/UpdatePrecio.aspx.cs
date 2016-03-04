using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisGEO.Admin
{
    public partial class UpdatePrecio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdBuscar_Click(object sender, EventArgs e)
        {
            PH.Operaciones op = new PH.Operaciones();
            this.GridView1.DataSource= op.SP_CALL_PRECIO(this.txtProducto.Value);
            this.GridView1.DataBind();
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                
              var pr = db.tel_Precios.Where( p=> p.IdEmpresa==Global.IdEmpresa && p.IdProducto==this.txtProducto.Value);
              this.GridView2.DataSource = pr.ToList();
              this.GridView2.DataBind();
            }
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblError.Text = "";
           
            PH.Operaciones op = new PH.Operaciones();
            var lista = op.SP_CALL_PRECIO(this.txtProducto.Value);
            using (DAL.SinapsisEntities db= new DAL.SinapsisEntities())
            {
                foreach (var item in lista)
                {
                    
                    db.ph_ActualizarPrecio(Global.IdEmpresa, item.IDARTICULO, item.PRECIO, item.IDLISTA.ToString(), item.LISTA,null);
                }
                db.SaveChanges();
            }
            }
            catch (Exception ex)
            {

                this.lblError.Text = Utility.GetMessageError(ex);
            }
        }
    }
}