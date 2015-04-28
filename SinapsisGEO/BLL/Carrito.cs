using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
using System.Data.Entity.Core.Objects;

namespace SinapsisGEO.BLL
{
    public class CarritoBLL
    {
       public DAL.tel_Carrito cr;
       DAL.SinapsisEntities db;

       public Boolean Completo
       {
           get;
           set;
       }
       public String MensajeError;


       public CarritoBLL(DAL.tel_Carrito carrito, SinapsisEntities db)
        {
            this.db = db;
            cr = carrito;
            this.Calcular();
        }
       public CarritoBLL(SinapsisEntities db)
       {
           this.db = db;
       }


        public CarritoBLL(DAL.tel_Carrito carrito, SinapsisEntities db,bool calcular)
       {
           this.db = db;
           cr = carrito;
           this.Calcular(calcular);
       }



       public CarritoBLL(int IdCliente, int IdDireccion, String UserName, String IdTipo, SinapsisEntities db)
        {

        //    DAL.SinapsisEntities db = new DAL.SinapsisEntities();

            this.db = db;
            DAL.tel_Carrito car = new DAL.tel_Carrito();


            DAL.tel_Clientes cl = db.tel_Clientes.Find(IdCliente);
            DAL.Tel_Direcciones dir = db.Tel_Direcciones.Find(IdDireccion);

            //Asignamos los valores
            car.IdCliente = cl.IdCliente;
            car.IdEmpresa = cl.IdEmpresa;
            car.IdTipoPedido = IdTipo;
            car.Empresa = cl.Empresa;
            car.IdFormaPago = 1;
            car.TransferTemporal = false;

            car.Audit_Fecha = DateTime.Now;
            car.UserName = UserName;
            car.Fecha = DateTime.Today;

            car.Nombre = cl.Nombre;
            car.Apellido = cl.Apellido;
            car.Telefono = cl.Telefono;
            car.obs = cl.obs;

            car.IdDireccion = dir.Id;
            car.Direccion = ArmarDireccion(dir);
            car.cuadrante = dir.cuadrante;
            car.referencia = dir.referencia;
            car.IdSucursal = dir.IdSucursal;

            db.tel_Carrito.Add(car);
            db.SaveChanges();
            
            this.cr = car;

        }

       String ArmarDireccion(DAL.Tel_Direcciones dir)
       {
           StringBuilder str = new StringBuilder();
           if (dir.Direccion.Length > 0)
           {
               str.Append(dir.Direccion);
           }
           if (dir.NroCasa.HasValue)
           { 
                str.Append(String.Format(" {0} ",dir.NroCasa.Value));
           }
           if (dir.Direccion1 != null)
           {
               str.Append(String.Format( " y {0}", dir.Direccion1));
           }


           return str.ToString();

       }

       public int AgregarCliente(int IdEmpresa, int IdCliente, string Nombre, string Apellido, string Telefono, string RUC)
       {
           var cl = db.tel_Clientes.Where(p => p.IdClienteWeb1 == IdCliente && p.IdEmpresa==IdEmpresa).FirstOrDefault();
           if (cl ==null)
           {    
               cl = new tel_Clientes();
               cl.IdEmpresa = IdEmpresa;
               cl.Nombre = Nombre;
               cl.Apellido = Apellido;
               cl.Telefonoweb = Telefono;
               cl.Diplomatico = false;

               try
               {
                   cl.Telefono = Convert.ToInt64(Telefono);
               }
               catch (Exception)
               {
                   
                //   throw;
                   cl.Telefono = 1;
               }

               

               cl.RUC = RUC;
               cl.IdClienteWeb1 = IdCliente;
               db.tel_Clientes.Add(cl);
           }
           else
           {
               cl.Nombre = Nombre;
               cl.Apellido = Apellido;
               cl.Telefonoweb = Telefono;
               cl.RUC = RUC;
               if (!cl.Diplomatico.HasValue)
               {
                   cl.Diplomatico = false;
               }

               try
               {
                   cl.Telefono = Convert.ToInt64(Telefono);
               }
               catch (Exception)
               {

                   //   throw;
                   cl.Telefono = 1;
               }
           }

           db.SaveChanges();
           return cl.IdCliente;

       }

       public int AgregarDireccion(int IdCliente, int IdDireccion, string Direccion, string Referencia, string Ciudad,int IdSucursal)
       {
           var dr = db.Tel_Direcciones.Where(p => p.IdCliente == IdCliente && p.IdDir2 == IdDireccion).FirstOrDefault();
           if (dr==null)
           {
               dr = new Tel_Direcciones();
               dr.IdCliente = IdCliente;
               dr.IdDir2 = IdDireccion;
               dr.Direccion = Direccion;
               dr.referencia = Referencia + "-" + Ciudad;
               dr.IdSucursal = IdSucursal;
               db.Tel_Direcciones.Add(dr);


           }
           else
           {
               dr.Direccion = Direccion;
               dr.IdSucursal = IdSucursal;
               dr.referencia = Referencia + "-" + Ciudad;
           }
           db.SaveChanges();

           return dr.Id;
       }

        public void AgregarItem(String IdProducto, Decimal Cantidad, String Obs)
        {
            AgregarItem(IdProducto,Cantidad, Obs, new String[0]);
            
            //var item = new DAL.tel_Carrito_Item();
            //item.IdProducto = IdProducto;
            
            ////var p = db.tel_Productos.Find(IdProducto);

            ////if (Cantidad < 1 && p.PermiteMitad.Value)
            ////{

            //    item.Cantidad = Cantidad;

            ////}
            ////else
            ////{
            ////    this.MensajeError = "El producto no permite Mitad/Mitad";
            ////    return;
            ////}

            //item.Precio = this.TraerPrecio(IdProducto);
            //item.IdEmpresa = cr.IdEmpresa;

            //this.cr.tel_Carrito_Item.Add(item);
            //this.Calcular();

        }

    
        public void AgregarItem(String IdProducto, Decimal Cantidad, String Obs, String[] Combos)
        {
            var item = new DAL.tel_Carrito_Item();
            item.IdProducto = IdProducto;
            
            item.Precio = this.TraerPrecio(IdProducto);
            item.IdEmpresa = cr.IdEmpresa;
            item.Cantidad = Cantidad;
            item.Obs = Obs;
            this.cr.tel_Carrito_Item.Add(item);

            for (int i = 0; i < Combos.Length; i++)
            {
                String[] prod;
                prod= Combos[i].Split(new Char[] { ':' });

                Decimal cantidad = Convert.ToDecimal(prod[2]); 

                if (prod[1] != string.Empty )
                {
                    var item1 = new DAL.tel_Carrito_Item();
                    item1.IdProducto = prod[0];
                    item1.IdEmpresa = item.IdEmpresa;
                    item1.Cantidad = Math.Ceiling(cantidad / 2);
                    item1.IdCIPadre = item.IdCarritoItem;
                    item1.IdCarrito = cr.IdCarrito;
                    //item.tel_Carrito_Item1.Add(item1);
                    item.tel_Carrito_Item1.Add(item1);
                
                    var item2 = new DAL.tel_Carrito_Item();
                    item2.IdProducto = prod[1];
                    item2.IdEmpresa = item.IdEmpresa;
                    item2.Cantidad = Math.Floor(cantidad / 2);
                    item2.IdCIPadre = item.IdCarritoItem;
                    item2.IdCarrito = cr.IdCarrito;
                    //item.tel_Carrito_Item1.Add(item1);
                    item.tel_Carrito_Item1.Add(item2);

                }
                    else

	            {
                    var item1 = new DAL.tel_Carrito_Item();
                    item1.IdProducto = prod[0];
                    item1.IdEmpresa = item.IdEmpresa;
                    item1.Cantidad = cantidad;
                    item1.IdCIPadre = item.IdCarritoItem;
                    item1.IdCarrito = cr.IdCarrito;
                    //item.tel_Carrito_Item1.Add(item1);
                    item.tel_Carrito_Item1.Add(item1);
	            }

            }

            //var p = db.tel_Productos.Find(IdProducto);

            //if (Cantidad < 1 && p.PermiteMitad.Value)
            //{

            

            //}
            //else
            //{
            //    this.MensajeError = "El producto no permite Mitad/Mitad";
            //    return;
            //}


            
            this.Calcular();
        }

        public void BorrarItem(DAL.tel_Carrito_Item item )
        {
            var ItemHijos = item.tel_Carrito_Item1.ToList();

            //Borramos los items del combo
            foreach (var item1 in ItemHijos)
            {
                item.tel_Carrito_Item1.Remove(item1);
                db.Entry(item1).State = EntityState.Deleted;


            }


            this.cr.tel_Carrito_Item.Remove(item);
            db.Entry(item).State = EntityState.Deleted;

            this.Calcular();
        }

        public void ConfirmaCarrito() {

            //using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            //{
            //if (!cr.CostoEnvio.HasValue)
            //{

            this.Calcular();
            CalcularEnvio(true);
            if (!this.cr.tel_Clientes.Verificado.HasValue)
            {
                this.cr.tel_Clientes.Verificado = true;                
            }

            
            db.SaveChanges();    
            //}
                var IdPedido =db.tel_ConfirmaCarrito(this.cr.IdCarrito).FirstOrDefault();
                if (Global.NotificarPedido)

                {
                    this.EnviarMail(IdPedido.Value, this.cr.Tel_Direcciones.IdSucursal.Value);
                }
                
                EnviarComanda(IdPedido);
                db.SaveChanges();
            //}
        }

        void CalcularEnvio(bool Insertar)
        {
            var tipo = db.tel_TipoPedido.Find(cr.IdEmpresa, cr.IdTipoPedido);
                if (tipo.IdProductoCosto != null)
                {
                    var SinCosto = (from i in db.tel_Carrito_Item join p in db.tel_Productos on i.IdProducto equals p.IdProducto where p.IncluyeEnvio==true select i).FirstOrDefault();
                    String Obs = String.Empty;

                    if (SinCosto != null)
                    {
                        Obs = "SIN COSTO";
                        cr.CostoEnvio = 0;
                    }
                    else
                    {

                        cr.CostoEnvio = this.TraerPrecio(tipo.IdProductoCosto);   
                        
                    }

                    if (Insertar)
                    { 
                        //VG 28/11/2013
                        //Verificamos que no exista todavia el costo de delivery en el detalle
                        bool existe = false;
                        foreach (var item in cr.tel_Carrito_Item)
                        {
                            if (item.IdProducto==tipo.IdProductoCosto)
                            {
                                existe = true;
                                break;
                            }
                        }

                        if (!existe)
                        {
                            this.AgregarItem(tipo.IdProductoCosto, 1, Obs);
                           
                           
                        }
                        cr.CostoEnvio = 0;
                    }
                }
                else
	            {
                    cr.CostoEnvio = 0;
	            } 
                

        }
        void EnviarComanda(int? IdPedido)
        { 
         try
                {
                   // result = db.ph_Interfase(c
                    using (PH.PHEntities ph = new PH.PHEntities())
                    {
                        var comanda = db.ph_Interfase_V1(IdPedido).FirstOrDefault();
                        
                        //var result=ph.SP_COMANDA.SqlQuery(ConfigurationManager.AppSettings["SP_NAME_COMANDA"], comanda.IdSucursal, comanda.Header, comanda.Details, comanda.Cliente, IdPedido).FirstOrDefault();
                        PH.Operaciones op = new PH.Operaciones();
                        //var result = op.SP_GG_COMANDA_ADD(ph, comanda.IdSucursal, comanda.Header, comanda.Details, comanda.Cliente, IdPedido);
                        var result = op.SP_GG_COMANDA_ADD(comanda.IdSucursal, comanda.Header, comanda.Details, comanda.Cliente, IdPedido);

                        //var result = ph.SP_GG_COMANDA_ADD(comanda.IdSucursal, comanda.Header, comanda.Details, comanda.Cliente, IdPedido).FirstOrDefault();
                        DAL.tel_Ph_Interfase pint = new tel_Ph_Interfase();
                        pint.IdPedido = IdPedido.Value;

                        pint.Header = comanda.Header;
                        pint.Cliente = comanda.Cliente;
                        pint.IdSucursal = comanda.IdSucursal;
                        pint.Details = comanda.Details;

                        pint.IdCliente = result.IDCLIENTE;
                        pint.IdComanda = result.IDCOMANDA;
                        pint.IdDireccion = result.IDDIRECCION;
                        pint.Estado = result.ESTADO;
                        pint.Audit_Fecha = DateTime.Now;
                        db.tel_Ph_Interfase.Add(pint);                        
                    }
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
        }

        void Calcular()
        {
            this.Calcular(false);
        }
        void Calcular(bool ActualizaPrecio)
        {
            double cantidad = 0.00;
            cr.TotalPedido = 0;
            this.CalcularEnvio(false);
            foreach(DAL.tel_Carrito_Item it in cr.tel_Carrito_Item)
            {
                if (ActualizaPrecio && it.IdCIPadre ==null)
                {
                    it.Precio = this.TraerPrecio(it.IdProducto);
                }
                if (it.Precio.HasValue)
                {
                    cr.TotalPedido += it.Cantidad * it.Precio.Value;
                }
                cantidad = cantidad + Convert.ToDouble(it.Cantidad.Value);
            }

            //Decimal CostoEnvio = 0;
            //if (cr.CostoEnvio.HasValue)
            //{
            //    CostoEnvio = cr.CostoEnvio.Value;

            //}

            cr.TotalGeneral = cr.TotalPedido + (cr.CostoEnvio==null ? 0 :cr.CostoEnvio);


            if (cantidad == Math.Floor(cantidad) )
            {
                this.Completo = true;
            }
            else
            {
                this.Completo = false;
            }


        }

        public Decimal TraerPrecio(string IdProducto)
        {
            Decimal precio = 0;
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                var lista = db.App_GetPrecio(cr.IdEmpresa, IdProducto, cr.IdTipoPedido, cr.IdSucursal, cr.IdCliente).FirstOrDefault();
                if (lista != null)
                {
                    precio= lista.Precio.Value;
                }
            }
            if (cr.tel_Clientes==null)
            {
                
            }
            return VerificarDiplomatico(precio);
        }

        private Decimal VerificarDiplomatico(Decimal precio)
        {
            if (cr.tel_Clientes == null)
            {
                cr.tel_Clientes = db.tel_Clientes.Find(cr.IdCliente);
            }
            if (cr.tel_Clientes.Diplomatico.HasValue)
            {
                if (cr.tel_Clientes.Diplomatico.Value == true)
                {
                    precio = Decimal.Round(precio - (precio / 11), 0);                    
                }

            }
            return precio;
        }

        static public Decimal TraerPrecio(int IdEmpresa, string IdProducto, string IdTipoPedido, int IdSucursal, int IdCliente)
        {
            Decimal precio = 0;
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                var lista = db.App_GetPrecio(IdEmpresa, IdProducto, IdTipoPedido, IdSucursal, IdCliente).FirstOrDefault();
                if (lista != null)
                {
                    precio = lista.Precio.Value;
                }
            }

            return precio;
        }
      
        void EnviarMail(int IdPedido, int Sucursal)
        {
            try
            {
                Tools.Mailer mailer = new Tools.Mailer();
                string Destino = string.Empty;
                var s = this.db.tel_Sucursal.Where(p => p.IdEmpresa == Global.IdEmpresa && p.IdSucursal == Sucursal).FirstOrDefault();
                mailer.EnviarMailAsync(s.Obs, string.Format("Nuevo Pedido {0}", IdPedido), mailer.AspTextMerge("MailTemplate/VerPedido.aspx?IdPedido=" + IdPedido.ToString()));

            }
            catch (Exception)
            {

            }
        }


        public void DuplicarPedido(int IdPedido, string UserName) {
            DAL.tel_Pedidos pd = db.tel_Pedidos.Include("tel_PedidosDet").Where(p=>p.IdPedido==IdPedido).FirstOrDefault();
                if (pd !=null)
                {
                    var cr = new CarritoBLL(pd.IdCliente.Value, pd.IdDireccion.Value, UserName, pd.IdTipoPedido, db);
                    cr.cr.IdPedidoOrigen = pd.IdPedido;
                    foreach (DAL.tel_PedidosDet item in pd.tel_PedidosDet)
                    {
                        if (item.IdPDPadre ==null)
	                        {
                            String[] Obs = TraerContenido(item.IdPedidoDet, pd.tel_PedidosDet.ToList());
                            if (Obs[0]!="")
                            {
                                cr.AgregarItem(item.IdProducto, item.Cantidad.Value, item.Obs,Obs);		     
                            }
                            else
                            {
                                cr.AgregarItem(item.IdProducto, item.Cantidad.Value, item.Obs);		     
                            }
                            
	                        }

                        
                    }
                    this.cr = cr.cr;


                }


        }

        String[] TraerContenido(int IdItem, List<DAL.tel_PedidosDet> items)
        {
            StringBuilder sb = new StringBuilder();
         
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].IdPDPadre==IdItem)
                {
                    sb.Append(items[i].IdProducto);
                    sb.Append(":");
                    if (items[i].Cantidad < 1)
                    {
                        sb.Append(items[i + 1].IdProducto);
                        i++;
                    }
                    sb.Append(";");   
                }
     
            }
            if (sb.Length>1)
            {
                sb.Remove(sb.Length - 1, 1);                
            }


            return sb.ToString().Split(new Char[] { ';' });
        }

    }


}