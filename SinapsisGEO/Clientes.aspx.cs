using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisGEO
{
    public partial class Clientes : System.Web.UI.Page
    {
        private SinapsisEntities db = new SinapsisEntities();
        private int IdEmpresa = Global.IdEmpresa ;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IdCliente"]==null)
            {
                this.FormView1.ChangeMode(FormViewMode.Insert);
                TextBox txtTest = FormView1.FindControl("txtTelefono") as TextBox;  
            if (txtTest != null)  
            {
                txtTest.Text = Request.QueryString["Telefono"];  
            }  
                /*
                 * TODO Validacion de Clientes
                 * 
                 */
 
                //Todo validando direcciones


            }
        }

     public IQueryable<DAL.tel_Clientes> GetCliente([QueryString("IdCliente")] int? IdCliente)
        {
            var query = this.db.tel_Clientes.Where(p => p.IdEmpresa == this.IdEmpresa && p.IdCliente == IdCliente);
            return query;
        }

     public void dvClientes_InsertItem()
     {
         var item = new DAL.tel_Clientes();
         item.IdEmpresa = this.IdEmpresa;
         TryUpdateModel(item);
         if (ModelState.IsValid)
         {
             // Save changes here
             db.tel_Clientes.Add(item);
             db.SaveChanges();

         }
     }

     // El nombre de parámetro del id. debe coincidir con el valor DataKeyNames establecido en el control
     public void dvClientes_UpdateItem(int IdCliente)
     {
         DAL.tel_Clientes item = null;
         // Cargar el elemento aquí, por ejemplo item = MyDataLayer.Find(id);
         item = db.tel_Clientes.Find(IdCliente);
         if (item == null)
         {
             // No se encontró el elemento
             ModelState.AddModelError("", String.Format("No se encontró el elemento con id. {0}", IdCliente));
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