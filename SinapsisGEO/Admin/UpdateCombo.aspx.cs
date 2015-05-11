using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisGEO.Admin
{
    public partial class UpdateCombo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblError.Text = "";
           
            PH.Operaciones op = new PH.Operaciones();
            this.GridView1.DataSource= op.SP_CALL_COMBO(this.txtProducto.Value);
            this.GridView1.DataBind();
            }
            catch (Exception ex)
            {

                this.lblError.Text = Utility.GetMessageError(ex);
            }
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblError.Text = "";
           
            PH.Operaciones op = new PH.Operaciones();
            var lista = op.SP_CALL_COMBO(this.txtProducto.Value);
            using (DAL.SinapsisEntities db= new DAL.SinapsisEntities())
            {

                foreach (var i in lista)
                {
                   
                   // db.ph_ActualizarCombo(Global.IdEmpresa);
                   // db.ph_ActualizarPrecio(Global.IdEmpresa, item.IDARTICULO, item.PRECIO, item.IDLISTA.ToString(), item.LISTA);
                    db.ph_ActualizarCombo(Global.IdEmpresa, i.IDPROMO, i.PROMO, i.IDDEFINICION_PROMO, i.DEFINICION_PROMO,
                        i.CANTIDAD_DEFINICION, i.IDPRODUCTO_CMB, i.IDPRODUCTO, i.PRODUCTO, i.CANTIDAD,
                        i.PREDETERMINADO, i.ESTADO, i.COMBINACIONES, i.AGRANDADO, i.IDART_COSTO_AGRANDADO);
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