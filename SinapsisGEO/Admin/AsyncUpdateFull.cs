using System;
using System.Collections.Generic;
using System.Linq;

namespace SinapsisGEO.Admin
{
    public class AsyncUpdateFull
    {
        private String _taskprogress;
        private AsyncTaskDelegate _dlgt;

        // Create delegate. 

        public string Tipo="P";
        protected delegate void AsyncTaskDelegate();

        public String GetAsyncTaskProgress()
        {
            return _taskprogress;
        }
        public void DoTheAsyncTask()
        {
            // Introduce an artificial delay to simulate a delayed  
            // asynchronous task. Make this greater than the  
            // AsyncTimeout property.
            string IdProductoActual = "";
            try
            {
                

                PH.Operaciones op = new PH.Operaciones();
                var prod = op.SP_CALL_PRODUCTO_FULL(Tipo);




                using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
                {
                    var t = new BLL.Tablas(db);
                    int IdVersion = t.sys_VersionAdd(Global.IdEmpresa, "");

                    foreach (var item in prod)
                    {
                        IdProductoActual = item.IDARTICULO;
                        db.ph_ActualizarProducto(Global.IdEmpresa, item.IDARTICULO, item.IDGRUPO, item.GRUPO, item.IDMEDIDA, item.IDLINEA,
                            item.LINEA, item.ARTICULO, item.ESTADO, item.DESCRIPCION_CORTA, item.IDIMPUESTO, item.IDFAMILIA,
                            item.FAMILIA, item.IDMARCA, item.IDCOLECCION, Convert.ToInt16(item.COMBO), Convert.ToInt16(item.PRODUCCION), item.IDFRANQUICIA,
                            item.FRANQUICIA, item.DESCRIPCION_WEB, IdVersion);

                        if (Tipo=="P")
                        { 
                            var precios = op.SP_CALL_PRECIO(item.IDARTICULO);
                            var combos = op.SP_CALL_COMBO(item.IDARTICULO);

                            foreach (var prc in precios)
                            {

                                db.ph_ActualizarPrecio(Global.IdEmpresa, item.IDARTICULO, prc.PRECIO, prc.IDLISTA.ToString(), prc.LISTA, IdVersion);
                            }
                            foreach (var cmb in combos)
                            {

                                db.ph_ActualizarCombo(Global.IdEmpresa, cmb.IDPROMO, cmb.PROMO, cmb.IDDEFINICION_PROMO, cmb.DEFINICION_PROMO,
                                    Convert.ToInt32(cmb.CANTIDAD), cmb.IDPRODUCTO_CMB, cmb.IDPRODUCTO, cmb.PRODUCTO, cmb.CANTIDAD, cmb.PREDETERMINADO,
                                    cmb.ESTADO, cmb.COMBINACIONES, cmb.AGRANDADO, cmb.IDART_COSTO_AGRANDADO, IdVersion);

                            }
                        }
                        db.SaveChanges();
                        _taskprogress = string.Format("Procesado: {0}", IdProductoActual);
                       
                    }

                }
            }
            catch (Exception ex)
            {

                _taskprogress = string.Format("{0} Producto con error: {1}", Utility.GetMessageError(ex), IdProductoActual);


            }
        }

        // Define the method that will get called to 
        // start the asynchronous task. 
        public IAsyncResult OnBegin(object sender, EventArgs e,
            AsyncCallback cb, object extraData)
        {
            _taskprogress = "Beginning async task.";

            _dlgt = new AsyncTaskDelegate(DoTheAsyncTask);
            IAsyncResult result = _dlgt.BeginInvoke(cb, extraData);

            return result;
        }

        // Define the method that will get called when 
        // the asynchronous task is ended. 
        public void OnEnd(IAsyncResult ar)
        {
            _taskprogress = "Asynchronous task completed.";
            _dlgt.EndInvoke(ar);
        }

        // Define the method that will get called if the task 
        // is not completed within the asynchronous timeout interval. 
        public void OnTimeout(IAsyncResult ar)
        {
            _taskprogress = "Ansynchronous task failed to complete " +
                "because it exceeded the AsyncTimeout parameter.";
        }

        

    }
}
