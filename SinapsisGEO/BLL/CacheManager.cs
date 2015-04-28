using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace SinapsisGEO.BLL
{
    public static class CacheManager
    {
        public const string chkSucursal = "Sucursales";
        public const string chkFaltantes = "Faltantes";

        public static List<DAL.tel_Sucursal> GetSucursales()
        {
            List<DAL.tel_Sucursal> Suc = HttpRuntime.Cache[chkSucursal] as List<DAL.tel_Sucursal>;

            if (Suc == null)
            {
                Suc = GenerateAndCacheSucursales();
            }
            return Suc;

        }

        public static List<DAL.tel_Faltantes> GetFaltantes()
        {
            List<DAL.tel_Faltantes> Suc = HttpRuntime.Cache[chkFaltantes] as List<DAL.tel_Faltantes>;

            if (Suc == null)
            {
                Suc = GenerateAndCacheFaltantes();
            }
            return Suc;

        }

        private static List<DAL.tel_Sucursal> GenerateAndCacheSucursales()
        {
            List<DAL.tel_Sucursal> Suc;

            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                Suc = db.tel_Sucursal.Where(p => p.IdEmpresa == Global.IdEmpresa).ToList();
            }

            HttpRuntime.Cache.Insert(
                chkSucursal,
                Suc,
                null,
                Cache.NoAbsoluteExpiration,
                new TimeSpan(0, 15, 0));

            return Suc;

        }

        private static List<DAL.tel_Faltantes> GenerateAndCacheFaltantes()
        {
            List<DAL.tel_Faltantes> Suc;

            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                Suc = db.tel_Faltantes.Include("tel_Insumos").Where(p => p.IdEmpresa == Global.IdEmpresa && p.Falta==true).ToList();
            }

            HttpRuntime.Cache.Insert(
                chkFaltantes,
                Suc,
                null,
                Cache.NoAbsoluteExpiration,
                new TimeSpan(0, 15, 0));

            return Suc;
        }

        public static void RemoverCache(string NombreElemento)
        {
            HttpRuntime.Cache.Remove(NombreElemento);
        }
    }
}