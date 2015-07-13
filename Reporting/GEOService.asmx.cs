using Reporting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace Reporting
{
    public class GeoData{
        public int Id { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public string Data3 { get; set; }
    }

    public class Cliente {
        public int IdCliente { get; set; }
        public long Telefono { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Empresa { get; set; }
        public string RUC { get; set; }
        public string Obs { get; set; }
        public string Direccion { get; set; }
        public short? Nro { get; set; }
        public string Direccion1 { get; set; }
        public string Referencia { get; set; }
        public int? IdCiudad { get; set; }
        public string Cuadrante { get; set; }
        public int? IdSucursal { get; set; }
        public int IdDireccion { get; set; }
        public bool EditandoDireccion { get; set; }
    }

    public class Sucursal
    {
        public int IdSucursal { get; set; }
        public string Nombre { get; set; }
        public int CantidadMoviles { get; set; }
        public int TiempoCola { get; set; }
        public int Pedidos { get; set; }
        public int TPC { get; set; }
        public int TPP { get; set; }
        public int TPV { get; set; }
        public int TPT { get; set; }
        public double HitRate { get; set; }
    }

    public class Pedidos
    {
        public int IdPedido { get; set; }
        public int? NroPedido { get; set; }
        public DateTime? Fecha { get; set; }
        public long? Telefono { get; set; }
        public string NombreCliente { get; set; }
        public string Estado { get; set; }
        public int? IdSucursal { get; set; }
        public string Direccion { get; set; }
        public string Cuadrante { get; set; }
        public decimal? Total { get; set; }
        public string Usuario { get; set; }
        public string Empresa { get; set; }
        public string RUC { get; set; }
        public string Referencia { get; set; }
        public string Obs { get; set; }
        public string HoraCola { get; set; }
        public string HoraPrep { get; set; }
        public string HoraViaje { get; set; }
        public string HoraEntrega { get; set; }
        public string TipoPedido { get; set; }
        public string EstadoLocal { get; set; }
        public string Css { get; set; }
        public List<DetallePedido> Detalle{ get; set; }

    }
    public class DetallePedido
    {
        public string IdProducto { get; set; }
        public string Producto { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public string Obs { get; set; }
    }

    /// <summary>
    /// Descripción breve de GEOService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class GEOService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public List<GeoData> ListaConsumo(int Sucursal, String dFecha, String hFecha, int IdReporte, int Empresa)
        {
            List<GeoData> lista = new List<GeoData>();
            List<GeoData> listaGEO = new List<GeoData>(); 

            try
            {


            DateTime? startDT = null;
            if (!String.IsNullOrWhiteSpace(dFecha))
            {
                startDT = DateTime.ParseExact(dFecha, "dd/MM/yyyy", null);
            }

            DateTime? endDT = null;
            if (!String.IsNullOrWhiteSpace(hFecha))
            {
                endDT = DateTime.ParseExact(hFecha, "dd/MM/yyyy", null);
            }


            //lista.Add(new GeoData { Data1 = "1", Lat = -25.284573746213134, Lng=  -57.63796601977447 });
            //lista.Add(new GeoData { Data1 = "2", Lat = -25.283473746213134, Lng = -57.63786601977447 });
            //lista.Add(new GeoData { Data1 = "3", Lat = -25.282373746213134, Lng = -57.63776601977447 });
            //lista.Add(new GeoData { Data1 = "1", Lat = -25.281273746213134, Lng = -57.63766601977447 });
            //lista.Add(new GeoData { Data1 = "1", Lat = -25.280173746213134, Lng = -57.63756601977447 });

            using (DAL.SinapsisEntities dm = new DAL.SinapsisEntities())
            {
                //List<DAL.tel_Clientes> lc = (from s in dm.tel_Clientes where (s.IdSucursal == Sucursal && s.IdEmpresa == 1 && s.GeoLat != null) select s).ToList();
                //foreach (DAL.tel_Clientes l in lc)
                //{
                //    //lista.Add(new GeoData { Data1 = "1", Lat = Convert.ToDouble(l.GeoLat), Lng = Convert.ToDouble(l.GeoLng) });
                //    lista.Add(new GeoData { Data1 = "1", Lat = l.GeoLat.Value, Lng = l.GeoLng.Value });
                //}

                var rpt = dm.sys_Reportes.Find(IdReporte);
                
              var IdEmpresa = new SqlParameter
              {
                  ParameterName = "IdEmpresa",
                  Value = Empresa
              };

                var IdSucursal = new SqlParameter
              {
                  ParameterName = "IdSucursal",
                  Value = Sucursal
              };

                var desdeFecha = new SqlParameter
                {
                    ParameterName = "DesdeFecha",
                    Value = startDT
                };

                var hastaFecha = new SqlParameter
                {
                    ParameterName = "HastaFecha",
                    Value = endDT
                };

              //Get student name of string type
                //listaGEO = dm.Database.SqlQuery<GeoData>("exec dbo.GEO1 @IdEmpresa, @IdSucursal ", IdEmpresa, IdSucursal).ToList<GeoData>();

               // listaGEO = dm.Database.SqlQuery<GeoData>("exec dbo.GEO1 @IdEmpresa, @IdSucursal,@DesdeFecha, @HastaFecha ", IdEmpresa, IdSucursal, desdeFecha, hastaFecha).ToList<GeoData>();
                listaGEO = dm.Database.SqlQuery<GeoData>(rpt.Script, IdEmpresa, IdSucursal, desdeFecha, hastaFecha).ToList<GeoData>();

              //  var listaGEO1 = dm.tel_Clientes.SqlQuery("exec dbo.GEO1 @IdEmpresa, @IdSucursal ", IdEmpresa, IdSucursal).ToList<GeoData>();

                //Or can call SP by following way
                //var courseList = ctx.Courses.SqlQuery("exec GetCoursesByStudentId @StudentId ", idParam).ToList<Course>();
                //return courseList;


            }

            }
            catch (Exception ex)
            {

                listaGEO.Add(new GeoData { Data3 = ex.Message });
            }


            return listaGEO;
        }

        [WebMethod]
        public Cliente GetCliente(int IdCliente)
        {
            Cliente cliente = new Cliente();
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                var cl = db.tel_Clientes.Find(IdCliente);
                if (cl !=null)
                {
                    cliente.IdCliente = cl.IdCliente;
                    cliente.Nombre = cl.Nombre;
                    cliente.Apellido = cl.Apellido;
                    cliente.Empresa = cl.Empresa ;
                    cliente.RUC = cl.RUC ;
                    cliente.Obs = cl.obs ;
//                    cliente.Empresa = cl.Empresa != null ? "" : cl.Empresa;
//                    cliente.RUC = cl.RUC != null ? "" : cl.RUC;
  //                  cliente.Obs = cl.obs != null ? "" : cl.obs;

                }
            }
            return cliente;
        }
        [WebMethod]
        public String GetLimiteSucursal(int IdSucursal)
        {
            string Limite = "";
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                var cl = db.tel_Sucursal.Where(p => p.IdEmpresa == Global.IdEmpresa && p.IdSucursal == IdSucursal).FirstOrDefault();
                if (cl != null)
                {
                    Limite = cl.Geo;
                }
            }
            return Limite;
        }

        [WebMethod]
        public Cliente GetDireccion(int IdDireccion)
        {
            Cliente cliente = new Cliente();
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                var cl = db.Tel_Direcciones.Find(IdDireccion);
                if (cl != null)
                {
                    cliente.IdCliente = cl.IdCliente.Value;
                    cliente.Direccion = cl.Direccion;
                    cliente.Nro = cl.NroCasa;
                    cliente.Direccion1 = cl.Direccion1;
                    cliente.Referencia= cl.referencia;
                    cliente.Cuadrante = cl.cuadrante;
                    cliente.IdSucursal= cl.IdSucursal;
                    cliente.IdDireccion = cl.Id;
                    cliente.IdCiudad = cl.IdCiudad;
                    //                    cliente.Empresa = cl.Empresa != null ? "" : cl.Empresa;
                    //                    cliente.RUC = cl.RUC != null ? "" : cl.RUC;
                    //                  cliente.Obs = cl.obs != null ? "" : cl.obs;

                }
            }
            return cliente;
        }
        [WebMethod]
        public int PedidoUpdate(int IdPedido)
        {
            int r = 0;
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                DAL.tel_Pedidos cl = db.tel_Pedidos.Find(IdPedido);
                if (cl!=null)
                {
                    cl.EstadoLocal = "L";
                    db.SaveChanges();
                    r=cl.IdPedido;
                }
            }
            return r;
        }

        [WebMethod]
        public int ClienteUpdate(Cliente cliente)
        {
//            Cliente cliente = new Cliente();
            if (cliente.EditandoDireccion)
            {
                return DireccionUpdate(cliente);
            }
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                DAL.tel_Clientes cl;
                if (cliente.IdCliente==0)
                {
                    cl = new DAL.tel_Clientes();
                    cl.IdEmpresa = Global.IdEmpresa;
                    cl.Telefono = cliente.Telefono;
                    cl.FechaAlta = DateTime.Today;


                    DAL.Tel_Direcciones dr = new DAL.Tel_Direcciones();
                    dr.Direccion1 = cliente.Direccion1;
                    dr.Direccion = cliente.Direccion;
                    dr.NroCasa = cliente.Nro;
                    dr.referencia = cliente.Referencia;
                    dr.cuadrante = cliente.Cuadrante;
                    dr.IdCiudad = cliente.IdCiudad;
                    dr.IdSucursal = cliente.IdSucursal;

                    
                    dr.Audit_Fecha = DateTime.Now;
                    dr.Audit_Usuario = User.Identity.Name;

                    cl.Tel_Direcciones.Add(dr);

                }
                else
                {
                    cl = db.tel_Clientes.Find(cliente.IdCliente);
                }   
             
                if (cl != null)
                {
                    cl.IdCliente = cliente.IdCliente ;
                    cl.Nombre = cliente.Nombre.Trim();
                    cl.Apellido = cliente.Apellido.Trim();
                    cl.Empresa = cliente.Empresa.Trim();
                    cl.RUC = cliente.RUC.Trim();
                    cl.obs = cliente.Obs.Trim();

                    cl.Audit_Fecha = DateTime.Now;
                    cl.audit_Usuario = User.Identity.Name;

                    if (cliente.IdCliente ==0)
	                {
		                    db.tel_Clientes.Add(cl);
	                }
                    
                    db.SaveChanges();
                }

            }
            return 0;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Sucursal> GetSucursales()
        {
            List<Sucursal> lista = new List<Sucursal>();
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                List<DAL.tel_Sucursal> lc = db.tel_Sucursal.Where(p => p.IdEmpresa == Global.IdEmpresa).ToList();
                foreach (DAL.tel_Sucursal l in lc)
                {
                    lista.Add(new Sucursal { IdSucursal = l.IdSucursal, Nombre = l.Sucursal});
                }
            }
            // Return JSON data
            JavaScriptSerializer js = new JavaScriptSerializer();

            //return js.Serialize(lista);
            //return lista.ToArray();
            return lista;
        }


        [WebMethod]
        int DireccionUpdate(Cliente cliente)
        {
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                DAL.Tel_Direcciones dr;
                if (cliente.IdDireccion == 0)
                {
                    dr = new DAL.Tel_Direcciones();
                    dr.Direccion1 = cliente.Direccion1;
                    dr.Direccion = cliente.Direccion;
                    dr.NroCasa = cliente.Nro;
                    dr.referencia = cliente.Referencia;
                    dr.cuadrante = cliente.Cuadrante;
                    dr.IdCiudad = cliente.IdCiudad;
                    dr.IdSucursal = cliente.IdSucursal;
                    dr.IdCliente = cliente.IdCliente;

                    dr.Audit_Fecha = DateTime.Now;
                    dr.Audit_Usuario = User.Identity.Name;

                    db.Tel_Direcciones.Add(dr);

                }
                else
                {
                    dr= db.Tel_Direcciones.Find(cliente.IdDireccion);
                }

                if (dr != null)
                {
                    dr.Direccion1 = cliente.Direccion1;
                    dr.Direccion = cliente.Direccion;
                    dr.NroCasa = cliente.Nro;
                    dr.referencia = cliente.Referencia;
                    dr.cuadrante = cliente.Cuadrante;
                    dr.IdCiudad = cliente.IdCiudad;
                    dr.IdSucursal = cliente.IdSucursal;

                    dr.Audit_Fecha = DateTime.Now;
                    dr.Audit_Usuario = User.Identity.Name;


                    db.SaveChanges();
                }

                return dr.Id;
            }
            

        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Pedidos GetPedidobyId(int IdPedido)
        {
            Pedidos pd = null;
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                // List<DAL.tel_Pedidos> lc = db.tel_Pedidos.Where(p => p.IdEmpresa == Global.IdEmpresa & p.Fecha >= dFecha & p.Fecha <= hFecha & (p.UserName==Operador | Operador=="-") & (p.IdSucursal == IdSucursal | IdSucursal==0) ).ToList();
               
                var lc = (from p in db.tel_Pedidos.Include("tel_pedidosDet").Include("tel_TipoPedido").Include("tel_pedidosDet.tel_Productos")
                         where p.IdEmpresa == Global.IdEmpresa && p.IdPedido==IdPedido
                              select p).FirstOrDefault();
                         if (lc !=null)
	                        {
		                       pd= new Pedidos();
                             pd.IdPedido = lc.IdPedido;
                             pd.NroPedido = lc.NroPedido;
                             pd.Fecha = lc.Audit_Fecha;
                             pd.Telefono = lc.Telefono;
                             pd.Empresa = lc.Empresa;
                             pd.RUC = lc.RUC;
                             pd.Referencia = lc.referencia;
                             pd.Obs = lc.obs;
                             pd.NombreCliente = lc.Nombre + " " + lc.Apellido;
                             pd.Estado = lc.Estado + lc.EstadoLocal;
                             pd.IdSucursal = lc.IdSucursal;
                             pd.Direccion = lc.Direccion;
                             pd.Cuadrante = lc.cuadrante;
                             pd.Total = lc.TotalGeneral;
                             pd.Usuario = lc.UserName;
                             pd.TipoPedido = lc.tel_TipoPedido.TipoPedido;
                             pd.EstadoLocal = lc.EstadoLocal;
                             pd.Detalle= new List<DetallePedido>();
                             foreach (var item in lc.tel_PedidosDet)
                             {
                                 DetallePedido det = new DetallePedido();
                                 det.IdProducto = item.IdProducto;
                                 det.Producto = item.tel_Productos.Descripcion;
                                 det.Cantidad = item.Cantidad;
                                 det.Precio = item.Precio;
                                 det.Obs = item.Obs;
                                 pd.Detalle.Add(det);
                             }

	                        }
                         //                        select new Pedidos()
                         //{
                         //    IdPedido = p.IdPedido,
                         //    NroPedido = p.NroPedido,
                         //    Fecha = p.Audit_Fecha,
                         //    Telefono = p.Telefono,
                         //    Empresa = p.Empresa,
                         //    RUC = p.RUC,
                         //    Referencia = p.referencia,
                         //    Obs = p.obs,
                         //    NombreCliente = p.Nombre + " " + p.Apellido,
                         //    Estado = p.Estado,
                         //    IdSucursal = p.IdSucursal,
                         //    Direccion = p.Direccion,
                         //    Cuadrante = p.cuadrante,
                         //    Total = p.TotalGeneral,
                         //    Usuario = p.UserName,
                         //    Detalle =  p.tel_PedidosDet
                         //}).FirstOrDefault();

                
            }
            return pd;

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet=true)]

        public List<Pedidos> GetPedidos(DateTime dFecha, DateTime hFecha, string Operador, int IdSucursal)
        {
            hFecha = hFecha.AddDays(1);
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                // List<DAL.tel_Pedidos> lc = db.tel_Pedidos.Where(p => p.IdEmpresa == Global.IdEmpresa & p.Fecha >= dFecha & p.Fecha <= hFecha & (p.UserName==Operador | Operador=="-") & (p.IdSucursal == IdSucursal | IdSucursal==0) ).ToList();

                var lc = from p in db.tel_Pedidos
                         where p.IdEmpresa == Global.IdEmpresa & p.Fecha >= dFecha & p.Fecha <= hFecha & (p.UserName == Operador | Operador == "-") & (p.IdSucursal == IdSucursal | IdSucursal == 0)
                         select new Pedidos()
                         {
                             IdPedido = p.IdPedido,
                             NroPedido = p.NroPedido,
                             Fecha = p.Fecha,
                             Telefono = p.Telefono,
                             NombreCliente = p.Nombre + " " + p.Apellido,
                             Estado = p.Estado,
                             IdSucursal = p.IdSucursal,
                             Direccion = p.Direccion,
                             Cuadrante = p.cuadrante,
                             Total = p.TotalGeneral,
                             Usuario = p.UserName
                         };
                return lc.ToList();
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public List<Sucursal> TiempoCola(int IdEmpresa)
        {
            List<Sucursal> lista = new List<Sucursal>();
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                //var result = db.tel_Moviles
                //.Where(p => p.IdEmpresa == IdEmpresa && p.Activo ==true)
                //.GroupBy(x => new {x.IdSucursal, x.tel_Sucursal.Sucursal})
                //.Select(x => new
                //{
                //    Sucursal = x.Key,
                //    Cantidad = x.Count()
                //});
                var result = db.tel_TableroKPI(IdEmpresa, DateTime.Today);

                foreach (var item in result)
                {
                    Sucursal s = new Sucursal();
                    s.IdSucursal=item.IdSucursal;
                    s.Nombre = item.Sucursal;
                    s.CantidadMoviles = item.Moviles.HasValue ? item.Moviles.Value : 0;
                    s.Pedidos = item.Cantidad.HasValue ? item.Cantidad.Value :0;
                    s.TPC = item.TPC.HasValue ? item.TPC.Value : 0;
                    s.TPP = item.TPP.HasValue ? item.TPP.Value : 0;
                    s.TPV = item.TPV.HasValue ? item.TPV.Value : 0;
                    s.TPT = item.TPT.HasValue ? item.TPT.Value : 0;
                    if (s.Pedidos>0)
                    {
                        s.HitRate = Convert.ToDouble((item.HitRate.HasValue ? item.HitRate.Value : 0))/Convert.ToDouble(s.Pedidos);                        
                    }

                    lista.Add(s);
                }

                var ListaPedidos = db.tel_Pedidos
                    .Where(p => p.IdEmpresa == IdEmpresa && (p.Estado != "F" && p.Anulado == null))
                    .OrderBy(p => new { p.IdSucursal, p.Audit_Fecha })
                    .Select(p=> new {p.IdSucursal,p.Audit_Fecha,p.horaCola,p.horaPreparacion,p.HoraEnvio,p.TotalPedido,p.Estado})
                    .ToList();
                int IdaVuelta = 30;
                int Ida = 15;
                int TiempoProduccion = 5;
                int TiempoCola = TiempoProduccion + Ida;
                int Viajando = 0;

                foreach (var suc in lista)
                {
                    var PedidosSucursal = ListaPedidos
                    .Where(p => p.IdSucursal == suc.IdSucursal)
                    .ToList();

                    int[] aMovil;
                    if (suc.CantidadMoviles>0)
                    {
                        aMovil = new Int32[suc.CantidadMoviles];
                    }
                    else
	                {
                        aMovil = new Int32[1];
	                }


                    int i = 0;
                    foreach (var ped in PedidosSucursal)
                    {

                        if (i>aMovil.Length-1)
                        {
                            i = 0;
                        }
                        if (ped.Estado=="P" | ped.Estado =="E")
                        {
                            aMovil[i] = aMovil[i] + TiempoProduccion + IdaVuelta;
                        }
                        if (ped.Estado == "V" )
                        {

                            Viajando = (int)Utility.MinutosTrans(ped.HoraEnvio);
                                if (Viajando<=IdaVuelta)
                                {
                                    aMovil[i] = aMovil[i] + (IdaVuelta -Viajando);    
                                }
                            
                        }
                        TiempoCola = aMovil[i];
                        i++;
                    }

                    if (i>aMovil.Length-1)
                    {
                        i = 0;
                    }

                    suc.TiempoCola = aMovil[i] + TiempoProduccion + Ida ;
                    
                }
                


            }

            return lista;
        }

        private int CalcularTiempoCola()
        {
            return 0;
        }
    }

   
}
