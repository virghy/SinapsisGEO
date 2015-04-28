using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
//using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebApplication1
{
    public class Cuadrantes
    {
        public string Cuadrante { get; set; }
        public int Sucursal { get; set; }
        public string Obs { get; set; }
        public bool Incluye { get; set; }
    }

    public class Calles
    {
        public int IdCalle { get; set; }
        public string Nombre { get; set; }
    }
    /// <summary>
    /// Descripción breve de GEOServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class GEOServices : System.Web.Services.WebService
    {

        [WebMethod]
        public Cuadrantes GetCuadrante(string Calle, string Calle1, string Calle2, int Nro, int IdEmpresa)
        {
            using (gisEntities   db = new gisEntities())
            {
                ObjectParameter pCuadrante = new ObjectParameter("Cuadrante", typeof(String));
                ObjectParameter pSucursal = new ObjectParameter("IdSucursal", typeof(int));
                ObjectParameter pObs = new ObjectParameter("Obs", typeof(String));
                ObjectParameter pIncluye = new ObjectParameter("Incluye", typeof(bool));

                db.BuscarCuadranteNombre(IdEmpresa, Calle, Nro, Calle1, Calle2,pCuadrante,
                    pSucursal,pObs,pIncluye);
                Cuadrantes c= new Cuadrantes();

                if (pCuadrante.Value != DBNull.Value)
                {
                    c.Cuadrante = (string)pCuadrante.Value;                    
                }

                if (pSucursal.Value != DBNull.Value)
                {
                    c.Sucursal = (int)pSucursal.Value;                    
                }

                if (pObs.Value != DBNull.Value)
                {
                    c.Obs = (string)pObs.Value;    
                }

                if (pIncluye.Value != DBNull.Value)
                {
                    c.Incluye = (bool)pIncluye.Value;                    
                }

                return c;
            }
          
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json,UseHttpGet=true)]
        public string[] GetCalles(string Nombre)
        {
            using (gisEntities db = new gisEntities())
            {
                List<string> customers = new List<string>();
               List<Calles> clist = new List<Calles>();
               var c=db.BuscarCalle(Nombre, 10).ToList();
               foreach (var item in c)
               {
                   Calles cl = new Calles();
                   cl.IdCalle=item.IdCalle;
                   cl.Nombre=item.NombreLargo;
                   clist.Add(cl);
                   customers.Add(String.Format("{0}-{1}",item.NombreLargo,item.IdCalle));

               }
               //return clist;
               return customers.ToArray();
            }
        }
    }
}
