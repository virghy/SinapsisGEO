using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using DAL;
using System.Data.Entity.Validation;
using System.Text;

namespace SinapsisGEO.Control
{

    public delegate void EdicionEventHandler(object source, EdicionEventArgs e);
    public class EdicionEventArgs : EventArgs
    {
        private string EventInfo;
        private bool Cancel;
       
        public EdicionEventArgs(string Text, bool Cancel)
        {
            EventInfo = Text;
            this.Cancel = Cancel;
        }
        public string GetInfo()
        {
            return EventInfo;
        }
        public bool Cancelo()
        {
            return this.Cancel;
        }
    }

    public partial class ClienteEdit : System.Web.UI.UserControl
    {
        private SinapsisEntities db = new SinapsisEntities();

        public event EdicionEventHandler EdicionFinalizado;

        int IdCliente;
        String Telefono;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack !=true)
            {
             
            }
        }

        public IQueryable<DAL.tel_Clientes> GetCliente([Control("txtTelefono")] int? Telefono)
        {
            var query = this.db.tel_Clientes.Where(p => p.IdEmpresa == Global.IdEmpresa && p.Telefono == Telefono);

            //this.ASPxDataView1.DataSource = query.ToList();
            //this.ASPxDataView1.DataBind();
            return query;
        }

        public void CargarDatos(double Telefono, int IdCliente)
        {
            this.Visible = true;
            if (IdCliente==0)
            {
                this.fvCliente.ChangeMode(FormViewMode.Insert);
                this.Telefono = Telefono.ToString();

            }
            else
            {
                this.IdCliente = IdCliente;

                this.fvCliente.DataBind();
                this.fvCliente.ChangeMode(FormViewMode.Edit);
            }
        }


        public IQueryable<DAL.tel_Clientes> GetClienteById()
        {
            if (IdCliente != 0)
            {
                                
            var query = this.db.tel_Clientes.Where(p => p.IdEmpresa == Global.IdEmpresa && p.IdCliente == IdCliente);
            return query;

            }
            return null;
        }

        public void dvClientes_InsertItem()
        {
            try
            {

            var item = new DAL.tel_Clientes();
            item.IdEmpresa = Global.IdEmpresa;
            // 
            TryUpdateModel(item);

            if (this.Page.ModelState.IsValid)
            {
                // Save changes here
                db.tel_Clientes.Add(item);
                db.SaveChanges();

                if (EdicionFinalizado != null)
                { 
                EdicionFinalizado(this,new EdicionEventArgs(item.IdCliente.ToString(),false));
                }
            }
            }
            catch (DbEntityValidationException e)
            {
                 StringBuilder str = new StringBuilder();
                foreach (var eve in e.EntityValidationErrors)
                {
                   
                    str.AppendFormat("La Entidad \"{0}\" con el estado \"{1}\" ha encontrado los siguientes errores ",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        str.AppendFormat("- Propiedad: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                this.lblError.Text = str.ToString();
              //  throw;
            }
            catch (Exception)
            {

                throw;
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
                this.Page.ModelState.AddModelError("", String.Format("No se encontró el elemento con id. {0}", IdCliente));
                return;
            }
            TryUpdateModel(item);
            if (this.Page.ModelState.IsValid)
            {
                // Guarde los cambios aquí, por ejemplo MyDataLayer.SaveChanges();
                db.SaveChanges();

                if (EdicionFinalizado != null)
                {
                    EdicionFinalizado(this, new EdicionEventArgs(item.IdCliente.ToString(), false));
                }
            }
        }

        protected void fvCliente_DataBound(object sender, EventArgs e)
        {
            if (this.fvCliente.CurrentMode == FormViewMode.Insert)
            {
                TextBox txtTest = fvCliente.FindControl("txtTelefono") as TextBox;
                if (txtTest != null)
                {
                    txtTest.Text = Telefono;
                }

            }
        }
    }
}