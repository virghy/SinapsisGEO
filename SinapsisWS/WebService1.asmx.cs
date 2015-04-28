using System;
using System.Collections.Generic;
using System.Linq;
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
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public int ActualizarMovil(int IdMovil, DateTime Hora, string Operacion)
        {
            int result = -1;
            
            switch (Operacion)
            {
                case "4":
                    ActivarMovil(IdMovil, Hora, Operacion);
                    result = 4;
                    break;
                case "5":
                    ActivarMovil(IdMovil, Hora, Operacion);
                    result = 5;
                    break;
                    default:
                    result=FinalizarPedido(IdMovil, Hora);
                    break;
            }
            return result;
        }

     //   [WebMethod]
        public void ActivarMovil(int IdMovil, DateTime Hora, string Operacion)
        {
            
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                DAL.tel_Moviles mv = db.tel_Moviles.Where(p => p.IdEmpresa == Global.IdEmpresa && p.IdMovil == IdMovil).FirstOrDefault();
                if (mv !=null)
                {
                    if (Operacion=="4")//Entrada
                    {
                        if (mv.Activo!=true)
                        {
                            mv.Activo = true;
                            mv.Ocupado = false;
                            
                        }

                    }
                    else if (Operacion == "5") //Salida
                    {
                        mv.Activo = false;
                        mv.Ocupado = false;

                    }

                    DAL.tel_MovilTracker mt = new DAL.tel_MovilTracker();
                    mt.AuditFecha=DateTime.Now;
                    mt.IdEmpresa=mv.IdEmpresa;
                    mt.IdMovil=mv.IdMovil;
                    mt.Operacion=Operacion;
                    mt.Fecha = Hora;
                    db.tel_MovilTracker.Add(mt);
                    db.SaveChanges();
                }
            }
        }

       // [WebMethod]
        public int FinalizarPedido(int IdMovil, DateTime Fecha)
        {
            int result = 0;
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                DAL.tel_Pedidos pd = db.tel_Pedidos.Where(p => p.IdEmpresa == Global.IdEmpresa
                    && p.IdMovil == IdMovil && p.Estado == "V").FirstOrDefault();

                if (pd !=null)
                {
                    db.tel_AppAsignarMovil(pd.NroPedido, Global.IdEmpresa, IdMovil, "F");
                    result = pd.NroPedido.Value;
                }
                
                DAL.tel_MovilTracker mt = new DAL.tel_MovilTracker();
                    mt.AuditFecha = DateTime.Now;
                    mt.IdEmpresa = Global.IdEmpresa;
                    mt.IdMovil = IdMovil;
                    mt.Operacion = "F";
                    mt.Fecha = Fecha;
                    

                    db.tel_MovilTracker.Add(mt);
                    db.SaveChanges();
                }
            return result;
            }
        }

    }

