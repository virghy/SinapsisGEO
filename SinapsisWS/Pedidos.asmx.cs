using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

namespace SinapsisWS
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Pedidos : System.Web.Services.WebService
    {
        [WebMethod]
        public int EnviarPedido(WSPedido pedido, List<WSPedidoDet> detalle)
        {
            int result = -1002;
            DAL.SinapsisEntities db = new DAL.SinapsisEntities();
            SinapsisGEO.BLL.CarritoBLL cr = new SinapsisGEO.BLL.CarritoBLL(db);
            

            try
            {

            AddToLog(pedido, detalle);

      //      db.tel_Sucursal.Where
       
            int IdCliente = cr.AgregarCliente(Global.IdEmpresa, pedido.IdPersona, pedido.Nombre, pedido.Apellido, pedido.Telefono, pedido.Ruc);
            int IdDir = cr.AgregarDireccion(IdCliente, pedido.IdDireccion, pedido.Direccion, pedido.Referencia, pedido.Ciudad,pedido.NroSucursal);
            string TipoPedido ="01";
            if (pedido.IdModulo==2)
            {
                TipoPedido = "02";
            }

            cr = new SinapsisGEO.BLL.CarritoBLL(IdCliente, IdDir, "WEB", TipoPedido, db);

            

            List<WSPedidoDet> detalle1 = detalle;
            bool existe = true;

            foreach (var d in detalle)
            {
                
                if (d.NroItemPadre==0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var i in detalle1)
                    {
   
                        if ( i.NroItemPadre== d.NroItem)
                        {
                            sb.Append(i.IdArticulo);
                            sb.Append(":");
                            sb.Append(";");
                        }

                    }
                    if (sb.Length>0)
	                {
                        sb.Remove(sb.Length - 1, 1);
		                cr.AgregarItem(d.IdArticulo, d.Cantidad, d.Comentario,sb.ToString().Split(new Char[] { ';' }));    
	                }
                    else
	                {
                        cr.AgregarItem(d.IdArticulo, d.Cantidad, d.Comentario);    
	                }
                
                }
            }

            //cr.ConfirmaCarrito();
            db.SaveChanges();
            result = cr.cr.IdCarrito;
//            return cr.cr.IdCarrito;

            }
            catch (Exception)
            {
                result = -1003;
                db.tel_Carrito.Remove(cr.cr);
                db.SaveChanges();
               
            }

            return result;
        }

        private void AddToLog(WSPedido pedido, List<WSPedidoDet> detalle)
        { 
            
            using (Log.LogEntities db = new Log.LogEntities()){
                Log.wsAudit wsLog = new Log.wsAudit();
                wsLog.Fecha=DateTime.Now;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(pedido.ToString());

                foreach (var item in detalle)
                {
                    sb.AppendLine(item.ToString());
                }

                wsLog.Info = sb.ToString();
                db.wsAudit.Add(wsLog);
                db.SaveChanges();
            }
        }


        [WebMethod]
        public string GetEstado(int IdPedido)
        {

            String Estado = "";
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                var pd = db.tel_Pedidos.Where(p => p.IdCarrito == IdPedido).FirstOrDefault();
                if (pd!=null)
                {
                    Estado = pd.Estado;
                }
            }
            return Estado;
        }
       
        }

    }

