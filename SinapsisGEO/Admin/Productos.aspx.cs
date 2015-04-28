using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;

namespace SinapsisGEO.Admin
{
    public partial class Productos : System.Web.UI.Page
    {
        DAL.SinapsisEntities db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new DAL.SinapsisEntities();
        }

        // El tipo devuelto puede ser modificado a IEnumerable, sin embargo, para ser compatible con paginación y ordenación 
        // , se deben agregar los siguientes parametros:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<DAL.tel_Productos> GridView1_GetData([Control("cboFamilia")] string IdFamilia,
            [Control("cboLinea")] string IdLinea, [Control("cboGrupo")] string IdGrupo,
            int startRowIndex,
                int maximumRows, out int totalRowCount, string sortByExpression)
        {
            // First we define the parameter that we are going to use
            // in our OrderBy clause. This is the same as "(person =>"
            // in the example above.

            //if (sortByExpression ==null)
            //{
            //    sortByExpression = "Descripcion";
            //}
            //var param = Expression.Parameter(typeof(DAL.tel_Productos), "c");

            //// Now we'll make our lambda function that returns the
            //// "DateOfBirth" property by it's name.
            //var mySortExpression = Expression.Lambda<Func<DAL.tel_Productos, object>>(Expression.Property(param, sortByExpression), param);


            var data = (from c in db.tel_Productos
                        where c.IdEmpresa == Global.IdEmpresa
                        && c.IdFamilia == IdFamilia
                        && c.IdLinea == IdLinea
//                        && c.IdGrupo == IdGrupo
                        orderby c.IdProducto
                        select c).Skip(startRowIndex).Take(maximumRows);

            totalRowCount = db.tel_Productos.Where(p=>p.IdEmpresa==Global.IdEmpresa && p.IdFamilia==IdFamilia 
                && p.IdLinea==IdLinea ).Count();
            return data;
                
           
        }

        // El nombre de parámetro del id. debe coincidir con el valor DataKeyNames establecido en el control
        public void GridView1_UpdateItem(string IdProducto)
        {
            DAL.tel_Productos item = db.tel_Productos.Where(p=> p.IdEmpresa==Global.IdEmpresa && p.IdProducto==IdProducto).FirstOrDefault() ;
            // Cargar el elemento aquí, por ejemplo item = MyDataLayer.Find(id);
            if (item == null)
            {
                // No se encontró el elemento
                ModelState.AddModelError("", String.Format("No se encontró el elemento con id. {0}", IdProducto));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Guarde los cambios aquí, por ejemplo MyDataLayer.SaveChanges();
                db.SaveChanges();

            }
        }
    }
}