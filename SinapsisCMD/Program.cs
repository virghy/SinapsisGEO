using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using log4net;
namespace SinapsisCMD
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program).Name);

        static int Main(string[] args)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo("log4net.config"));

            // Test if input arguments were supplied:

            log.Info("Iniciando Sincronizacion");

            if (args.Length == 0)
            {
                System.Console.WriteLine("Ingrese el Codigo de Empresa");
                System.Console.WriteLine("Usage: SinapsisCMD <num>");
                return 1;
            }

            // Try to convert the input arguments to numbers. This will throw
            // an exception if the argument is not a number.
            // num = int.Parse(args[0]);
            int num;
            bool test = int.TryParse(args[0], out num);
            if (test == false)
            {
                System.Console.WriteLine("Por favor, ingrese un valor numerico.");
                System.Console.WriteLine("Usage: SinapsisCMD <num>");
                return 1;
            }

            // Calculate factorial.
            long result = ActualizarEstados(num);
            EnviarPedidos(num); 

            // Print result.
            if (result == -1)
                System.Console.WriteLine("Input must be > 0 and < 256.");
            else
                System.Console.WriteLine("El proceso finalizo con el codigo {0}", result);

            return 0; 
        }

        static int ActualizarEstados(int IdEmpresa)
        {
            try
            {

            PH.PHEntities dbPH = new PH.PHEntities();
            using (SinapsisEntities db = new SinapsisEntities())
            {
                DateTime f = DateTime.Today.AddDays(-1);

                var listaPedido = db.tel_Pedidos.Where(p => p.IdEmpresa == IdEmpresa && p.Estado != "F" && p.Fecha>=f).ToList();
                foreach (DAL.tel_Pedidos item in listaPedido)
                {
                    try
                    {

                    Console.WriteLine("Actualizando {0}", item.IdPedido);
                    log.Info(string.Format("Actualizando Estado {0}", item.IdPedido));

                    var ph = dbPH.SP_XGG_ESTADO(item.IdPedido).FirstOrDefault();
                        if (ph != null)
                        {
                            db.tel_ActualizarEstado(item.IdPedido, ph.ESTADO.ToString(), ph.FECHA, ph.DRIVER);   		 
	                    }
                    }
                    catch (Exception ex)
                    {

                        log.Error(ex.Message, ex);
                    }

                }
            }
            return 0;
            }
            catch (Exception ex)
            {

                System.Console.WriteLine(ex.Message);
                log.Error(ex.Message, ex);
                return 1;
            }

                

        }

        static void EnviarPedidos(int IdEmpresa)
        {
            try
            {

            System.Console.WriteLine("Enviando pedidos");
            log.Info("Enviando pedidos");
            using (SinapsisEntities db = new SinapsisEntities())
            {
                var listaPedido = db.tel_Pedidos.Where(p => p.IdEmpresa == IdEmpresa & p.IdPedidoWeb ==null ).ToList();

                foreach (DAL.tel_Pedidos item in listaPedido)
                {
                    
                        EnviarComanda(item.IdPedido, db);
                        db.SaveChanges();
                    
                }

            }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                log.Error(ex.Message, ex);
                               
            }

        }

        static void EnviarComanda(int? IdPedido, DAL.SinapsisEntities db )
        {
            try
            {
                // result = db.ph_Interfase(c
                using (PH.PHEntities ph = new PH.PHEntities())
                {
                    log.Info(string.Format("Enviando Pedido {0}", IdPedido));

                    var comanda = db.ph_Interfase_V1(IdPedido).FirstOrDefault();
                    PH.Operaciones op = new PH.Operaciones();
                    var result = op.SP_GG_COMANDA_ADD(ph, comanda.IdSucursal, comanda.Header, comanda.Details, comanda.Cliente, IdPedido);

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
                log.Error(ex.Message, ex);
              //  throw ex;
               
            }
        }
    }
}
