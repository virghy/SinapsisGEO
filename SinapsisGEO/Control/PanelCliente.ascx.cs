using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Web.ModelBinding;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Mapping;


namespace SinapsisGEO.Control
{
    public partial class PanelCliente : System.Web.UI.UserControl
    {
        private SinapsisEntities db = new SinapsisEntities();
        private int IdEmpresa = Global.IdEmpresa;
        private int? IdDireccion = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<DAL.tel_Clientes> GetCliente([Control("txtTelefono")] int? Telefono)

        {
                var query = this.db.tel_Clientes.Where(p => p.IdEmpresa == this.IdEmpresa && p.Telefono == Telefono);
                
                //this.ASPxDataView1.DataSource = query.ToList();
                //this.ASPxDataView1.DataBind();
                return query;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //fvCliente.DataBind();
            grvClientes.DataSource = GetCliente(Convert.ToInt32(this.txtTelefono.Text)).ToList();
            grvClientes.DataBind();

            if (grvClientes.Rows.Count>0)
            {
                grvClientes.SelectedIndex = 0;
          //      this.btnAddDir.Visible = true;
                GetDirecciones(Convert.ToInt32(this.grvClientes.SelectedDataKey.Value));
                this.PedidosTop5.CargarDatos(Convert.ToInt32(this.grvClientes.SelectedDataKey.Value));
            }
            else
            {
            //    this.btnAddDir.Visible = false;
                GetDirecciones(-1);
            }
            

        }

        public IQueryable<DAL.Tel_Direcciones> GetDirecciones([Control("grvClientes")] int? IdCliente)
        {
            var query = this.db.Tel_Direcciones.Where(p => p.IdCliente == IdCliente);
            this.ASPxDataView1.DataSource = query.ToList();
            this.ASPxDataView1.DataBind();
            ASPxDataView1.Visible = true;
            return query;
        }


        public IQueryable<DAL.tel_Sucursal> GetSucursal()
        {
            var query = this.db.tel_Sucursal.Where(p => p.IdEmpresa == IdEmpresa);
            query = query.OrderBy(p => p.Sucursal);
            return query;
        }


        public IQueryable<DAL.Tel_Direcciones> GetDireccion()
        {
            var query = this.db.Tel_Direcciones.Where(p => p.Id == IdDireccion);
            return query;
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            IdDireccion = Convert.ToInt32(btn.CommandArgument);
          //  this.fvDireccion.DataSource = GetDireccion(IdDireccion).ToList();
            this.fvDireccion.ChangeMode(FormViewMode.Edit);
            this.fvDireccion.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        // El nombre de parámetro del id. debe coincidir con el valor DataKeyNames establecido en el control
        public void fvDireccion_UpdateItem(DAL.Tel_Direcciones dir)
        {
            DAL.Tel_Direcciones item = null;
            // Cargar el elemento aquí, por ejemplo item = MyDataLayer.Find(id);
            item = db.Tel_Direcciones.Find(dir.Id);
            if (item == null)
            {
                // No se encontró el elemento
                this.Page.ModelState.AddModelError("", String.Format("No se encontró el elemento con id. {0}", dir.Id));
                return;

            }
            
            
            TryUpdateModel(item);
            if (this.Page.ModelState.IsValid)
            {
                this.db.SaveChanges();
                GetDirecciones(Convert.ToInt32(this.grvClientes.SelectedDataKey.Value));
                // Guarde los cambios aquí, por ejemplo MyDataLayer.SaveChanges();

            }
        }

        protected void btnAddDir_Click(object sender, EventArgs e)
        {
            this.fvDireccion.ChangeMode(FormViewMode.Insert);
            TextBox txtTest = fvDireccion.FindControl("txtDireccion") as TextBox;
            txtTest.Text = "1";
            ASPxDataView1.Visible = false;
            
        }

        public void fvDireccion_InsertItem()
        {
            var item = new DAL.Tel_Direcciones();
            item.Id = 1;
            TryUpdateModel(item);
            item.IdCliente = Convert.ToInt32(this.grvClientes.SelectedDataKey.Value);
  
            item.Audit_Fecha = DateTime.Now;
            if (this.Page.ModelState.IsValid)
            {
                db.Tel_Direcciones.Add(item);
                db.SaveChanges();
                GetDirecciones(Convert.ToInt32(this.grvClientes.SelectedDataKey.Value));

            }
        }

        protected void grvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDirecciones(Convert.ToInt32(this.grvClientes.SelectedDataKey.Value));
            this.PedidosTop5.CargarDatos(Convert.ToInt32(this.grvClientes.SelectedDataKey.Value));
            
        }

        protected void cmdAgregar_Click(object sender, EventArgs e)
        {
           // Response.Redirect(string.Format("~/Clientes.aspx?Telefono={0}",this.txtTelefono.Text));

            this.fvCliente.ChangeMode(FormViewMode.Insert);
            TextBox txtTest = fvCliente.FindControl("txtTelefono") as TextBox;
            if (txtTest != null)
            {
                txtTest.Text = txtTelefono.Text;
            } 
            this.fvCliente.Visible = true;


        }

        protected void btnAddPedido_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);

            var car = new BLL.CarritoBLL(Convert.ToInt32(grvClientes.SelectedDataKey.Value), Convert.ToInt32(btn.CommandArgument), this.Page.User.Identity.Name,cboTipoPedido.SelectedValue,db);
            if (car != null)
            {
                Response.Redirect(string.Format("~/Pedido.aspx?Id={0}", car.cr.IdCarrito));

            }
        }

        public IQueryable<DAL.tel_Clientes> GetClienteById([Control("grvClientes")] int? IdCliente)
        {
            var query = this.db.tel_Clientes.Where(p => p.IdEmpresa == this.IdEmpresa && p.IdCliente == IdCliente);
            return query;
        }

        public void dvClientes_InsertItem()
        {
            var item = new DAL.tel_Clientes();
            item.IdEmpresa = this.IdEmpresa;
           // 
            TryUpdateModel(item);
            item.Telefono = Convert.ToInt64(this.txtTelefono.Text);
            if (this.Page.ModelState.IsValid)
            {
                // Save changes here
                db.tel_Clientes.Add(item);
                db.SaveChanges();
                this.fvCliente.Visible = false;
              //  this.txtTelefono.Text = item.Telefono.Value.ToString();
                this.btnBuscar_Click(null, null);
                
                //this.grvClientes.DataBind();

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
                this.fvCliente.Visible = false;
                this.grvClientes.DataBind();
                this.ASPxDataView1.Visible = true;
            }
        }

        protected void cmdEditCliente_Click(object sender, EventArgs e)
        {
            this.fvCliente.Visible = true;
            this.fvCliente.DataBind();
            this.fvCliente.ChangeMode(FormViewMode.Edit);
            this.ASPxDataView1.Visible = false;
        }

                     
    }
}