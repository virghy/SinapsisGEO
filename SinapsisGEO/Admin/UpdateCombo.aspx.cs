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
                    var listaInsumo = op.SP_CALL_INSUMO(i.IDPRODUCTO);

                    foreach (var item in listaInsumo)
                    {
                        db.ph_ActualizarProducto(Global.IdEmpresa, item.IDARTICULO, item.IDGRUPO, item.GRUPO, item.IDMEDIDA, item.IDLINEA,
                        item.LINEA, item.ARTICULO, item.ESTADO, item.DESCRIPCION_CORTA, item.IDIMPUESTO, item.IDFAMILIA,
                        item.FAMILIA, item.IDMARCA, item.IDCOLECCION, Convert.ToInt16(item.COMBO), Convert.ToInt16(item.PRODUCCION), item.IDFRANQUICIA,
                        item.FRANQUICIA, item.DESCRIPCION_WEB, null);
                    }

                   
                   // db.ph_ActualizarCombo(Global.IdEmpresa);
                   // db.ph_ActualizarPrecio(Global.IdEmpresa, item.IDARTICULO, item.PRECIO, item.IDLISTA.ToString(), item.LISTA);
                    db.ph_ActualizarCombo(Global.IdEmpresa, i.IDPROMO, i.PROMO, i.IDDEFINICION_PROMO, i.DEFINICION_PROMO,
                        i.CANTIDAD_DEFINICION, i.IDPRODUCTO_CMB, i.IDPRODUCTO, i.PRODUCTO, i.CANTIDAD,
                        i.PREDETERMINADO, i.ESTADO, i.COMBINACIONES, i.AGRANDADO, i.IDART_COSTO_AGRANDADO,null);

                   


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