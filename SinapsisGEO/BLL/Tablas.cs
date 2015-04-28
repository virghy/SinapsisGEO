using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SinapsisGEO.BLL
{
    public class Tablas
    {
        DAL.SinapsisEntities db;
        public Tablas(DAL.SinapsisEntities db)
        {
            this.db = db;
        }

        public IQueryable<DAL.tel_Familia> GetFamilias()
        {
            var query = this.db.tel_Familia.Where(p => p.IdEmpresa == Global.IdEmpresa & p.Activo==true);

            return query.OrderBy(p => p.Familia);

        }

        public IQueryable<DAL.tel_Sucursal> GetSucursales()
        {
            var query = this.db.tel_Sucursal.Where(p => p.IdEmpresa == Global.IdEmpresa);

            return query.OrderBy(p => p.Sucursal);

        }

        public static DAL.tel_Opciones GetOpcionById(int IdOpcion)
        {
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                var query = db.tel_Opciones.Include("tel_OpcionesDet").Where(p => p.IdEmpresa == Global.IdEmpresa & p.IdOpcion==IdOpcion);

                return query.OrderBy(p => p.Titulo).FirstOrDefault();
            
            }


        }

       
        public static DAL.tel_Productos GetProductoById(string IdProducto)
        {
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                var query = db.tel_Productos.Include("tel_ProductoOpcion").Where(p => p.IdEmpresa == Global.IdEmpresa & p.IdProducto==IdProducto);

                return query.FirstOrDefault();

            }


        }

        public static List<DAL.tel_ProductoOpcion> GetOpciones(String IdProducto, string IdGrupo, string IdFamilia,string IdLinea)
        {
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {

                var query = db.tel_ProductoOpcion.Where(p => p.IdEmpresa == Global.IdEmpresa 
                    & (p.IdProducto == IdProducto |  
                    (( p.IdGrupo==IdGrupo | p.IdGrupo==null) 
                    & (p.IdFamilia == IdFamilia | p.IdFamilia==null) 
                    & (p.IdLinea == IdLinea | p.IdLinea==null))));

                return query.OrderBy(p=> p.Orden).ToList();

            }


        }

        public static List<DAL.Opciones> GetOpcionesbyProducto(int IdOpcion)
        {
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {

                var query = from s in db.tel_Productos
                            join o in db.tel_OpcionesDet on s.IdProducto equals o.IdProducto
                            where o.IdOpcion == IdOpcion
                            orderby s.DescripcionCorta
                            select new DAL.Opciones { IdProducto = s.IdProducto, Descripcion = s.DescripcionCorta, Predet = o.Predet };

               return   query.OrderBy(p => p.Descripcion).ToList();
            }
        }
        public static List<DAL.Opciones> GetOpcionesbyProducto(int IdOpcion, string IdGrupo, string IdFamilia, string IdLinea)
        {
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                //List<DAL.tel_Productos> ListaProducto = new List<DAL.tel_Productos>();

//                var query = db.tel_Productos.Where(p => p.IdEmpresa == Global.IdEmpresa & p.Activo==true & (IdGrupo == null | p.IdGrupo == IdGrupo) & (IdFamilia == null | p.IdFamilia == IdFamilia) & ( IdLinea == null | p.IdLinea == IdLinea));

                //if (IdOpcion>0)
                //{
                //    var query1 = from s in db.tel_Productos
                //                 join o in db.tel_ProductoOpcion on s.IdProducto equals o.IdProducto
                //                 where o.IdOpcion==IdOpcion
                //                 orderby s.DescripcionCorta
                //                 select s;
                    
                //    query=query.Union(query1);
    
                //}


  //              return query.OrderBy(p=>p.DescripcionCorta).ToList();

                var query = from p in db.tel_Productos
                            where p.IdEmpresa == Global.IdEmpresa & p.Activo == true & (IdGrupo == null | p.IdGrupo == IdGrupo) & (IdFamilia == null | p.IdFamilia == IdFamilia) & (IdLinea == null | p.IdLinea == IdLinea)
                            orderby p.DescripcionCorta
                            select new DAL.Opciones { IdProducto = p.IdProducto, Descripcion = p.DescripcionCorta, Predet = false };

                return query.OrderBy(p => p.Descripcion).ToList();


            }

        

        }

    }
}