using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisGEO.Admin
{
    public partial class UpdateFull : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdBuscar_Click(object sender, EventArgs e)
        {
            try
            {

           
            PH.Operaciones op = new PH.Operaciones();
            this.GridView1.DataSource= op.SP_CALL_PRODUCTO_FULL(this.rdOpcion.SelectedValue);
            this.GridView1.DataBind();
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                
              var pr = db.tel_Productos.Where( p=> p.IdEmpresa==Global.IdEmpresa);
              this.GridView2.DataSource = pr.ToList();
              this.GridView2.DataBind();
            }

            }
            catch (Exception ex)
            {

                this.lblError.Text = Utility.GetMessageError(ex);
            }
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            Admin.AsyncUpdateFull mytask = new Admin.AsyncUpdateFull();
            mytask.Tipo = this.rdOpcion.SelectedValue;
            PageAsyncTask asynctask = new PageAsyncTask(mytask.OnBegin, mytask.OnEnd, mytask.OnTimeout, null);

            // Register the asynchronous task.
            Page.RegisterAsyncTask(asynctask);

            // Execute the register asynchronous task.
            Page.ExecuteRegisteredAsyncTasks();

            TaskMessage.InnerHtml = mytask.GetAsyncTaskProgress();

            //string IdProductoActual = "";
            //try
            //{
            //    this.lblError.Text = "";
           
            //PH.Operaciones op = new PH.Operaciones();
            //var prod = op.SP_CALL_PRODUCTO();
           
               
             

            //using (DAL.SinapsisEntities db= new DAL.SinapsisEntities())
            //{
            //    var t = new BLL.Tablas(db);
            //    int IdVersion = t.sys_VersionAdd(Global.IdEmpresa,  "");
               
            //    foreach (var item in prod)
            //    {
            //        IdProductoActual = item.IDARTICULO;
            //        db.ph_ActualizarProducto(Global.IdEmpresa, item.IDARTICULO, item.IDGRUPO, item.GRUPO, item.IDMEDIDA, item.IDLINEA,
            //            item.LINEA, item.ARTICULO, item.ESTADO, item.DESCRIPCION_CORTA, item.IDIMPUESTO, item.IDFAMILIA,
            //            item.FAMILIA, item.IDMARCA, item.IDCOLECCION, Convert.ToInt16( item.COMBO), Convert.ToInt16(item.PRODUCCION), item.IDFRANQUICIA,
            //            item.FRANQUICIA, item.DESCRIPCION_WEB, IdVersion);


            //        var precios = op.SP_CALL_PRECIO(item.IDARTICULO);
            //        var combos = op.SP_CALL_COMBO(item.IDARTICULO);

            //    foreach (var prc in precios)
            //    {

            //        db.ph_ActualizarPrecio(Global.IdEmpresa, item.IDARTICULO, prc.PRECIO, prc.IDLISTA.ToString(), prc.LISTA, IdVersion);
            //    }
            //    foreach (var cmb in combos)
            //    {

            //        db.ph_ActualizarCombo(Global.IdEmpresa, cmb.IDPROMO, cmb.PROMO, cmb.IDDEFINICION_PROMO, cmb.DEFINICION_PROMO,
            //            Convert.ToInt32(cmb.CANTIDAD), cmb.IDPRODUCTO_CMB, cmb.IDPRODUCTO, cmb.PRODUCTO, cmb.CANTIDAD, cmb.PREDETERMINADO,
            //            cmb.ESTADO, cmb.COMBINACIONES, cmb.AGRANDADO, cmb.IDART_COSTO_AGRANDADO, IdVersion);
                      
            //    }

            //    db.SaveChanges();
            //    this.lblError.Text = "Proceso finalizado";
            //    }
              
            //}
            //}
            //catch (Exception ex)
            //{

            //    this.lblError.Text = string.Format("{0} Producto con error: {1}", Utility.GetMessageError(ex), IdProductoActual);

                
            //}
        }

      
    }
}