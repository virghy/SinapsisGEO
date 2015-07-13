using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisGEO.Admin
{
    public partial class UpdateProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdBuscar_Click(object sender, EventArgs e)
        {
            PH.Operaciones op = new PH.Operaciones();
            this.GridView1.DataSource= op.SP_CALL_PRODUCTO(this.txtProducto.Value);
            this.GridView1.DataBind();
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                
              var pr = db.tel_Productos.Where( p=> p.IdEmpresa==Global.IdEmpresa && p.IdProducto==this.txtProducto.Value);
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
            var prod = op.SP_CALL_PRODUCTO(this.txtProducto.Value);
                var precios = op.SP_CALL_PRECIO(this.txtProducto.Value);
             var combos =  op.SP_CALL_COMBO(this.txtProducto.Value);

            using (DAL.SinapsisEntities db= new DAL.SinapsisEntities())
            {
                foreach (var item in prod)
                {

                    db.ph_ActualizarProducto(Global.IdEmpresa, item.IDARTICULO, item.IDGRUPO, item.GRUPO, item.IDMEDIDA, item.IDLINEA,
                        item.LINEA, item.ARTICULO, item.ESTADO, item.DESCRIPCION_CORTA, item.IDIMPUESTO, item.IDFAMILIA,
                        item.FAMILIA, item.IDMARCA, item.IDCOLECCION, Convert.ToInt16( item.COMBO), Convert.ToInt16(item.PRODUCCION), item.IDFRANQUICIA,
                        item.FRANQUICIA, item.DESCRIPCION_WEB);
                }

                foreach (var item in precios)
                {
                    
                    db.ph_ActualizarPrecio(Global.IdEmpresa, item.IDARTICULO, item.PRECIO, item.IDLISTA.ToString(), item.LISTA);
                }
                foreach (var item in combos)
                {

                    db.ph_ActualizarCombo(Global.IdEmpresa, item.IDPROMO, item.PROMO, item.IDDEFINICION_PROMO, item.DEFINICION_PROMO,
                        Convert.ToInt32(item.CANTIDAD), item.IDPRODUCTO_CMB, item.IDPRODUCTO, item.PRODUCTO, item.CANTIDAD, item.PREDETERMINADO,
                        item.ESTADO, item.COMBINACIONES, item.AGRANDADO, item.IDART_COSTO_AGRANDADO);
                      
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