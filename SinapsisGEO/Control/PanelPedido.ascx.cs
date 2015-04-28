using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data.Entity.Core.Mapping;
using System.Web.ModelBinding;
using System.Threading;
using System.Globalization;

namespace SinapsisGEO.Control
{
    public partial class PanelPedido : System.Web.UI.UserControl
    {
        private SinapsisEntities db = new SinapsisEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void CargarDatos()
        {
            //int IdCarrito;
            //IdCarrito =  Convert.ToInt32(this.Page.Request.QueryString["IdPedido"]);
          //  this.fvCarrito.DataSource = GetPedido(IdCarrito).ToList();
            this.fvCarrito.DataBind();
            
        }

        public IQueryable<DAL.tel_Carrito> GetPedido([QueryString("Id")] int? IdCarrito)
        {
            var query = this.db.tel_Carrito.Include("tel_Clientes").Include("tel_Direcciones").Where(p => p.IdEmpresa == Global.IdEmpresa && p.IdCarrito == IdCarrito);

            //this.ASPxDataView1.DataSource = query.ToList();
            //this.ASPxDataView1.DataBind();
            return query;
        }

        public IQueryable<DAL.tel_Sucursal> GetSucursal()
        {
            var query = this.db.tel_Sucursal.Where(p => p.IdEmpresa == Global.IdEmpresa);
            query = query.OrderBy(p => p.Sucursal);
            return query;
        }
        public IQueryable<DAL.tel_FormaPago> GetFormaPago()
        {
            var query = this.db.tel_FormaPago.Where(p => p.IdEmpresa == Global.IdEmpresa);
            
            return query;
        }

        // El nombre de parámetro del id. debe coincidir con el valor DataKeyNames establecido en el control
        public void fvCarrito_UpdateItem(int IdCarrito)
        {
           
            //Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ",";
            //Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ".";
            //Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ",";
            //Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";

           
            DAL.tel_Carrito item = null;
            // Cargar el elemento aquí, por ejemplo item = MyDataLayer.Find(id);
            item = GetPedido(IdCarrito).FirstOrDefault();

            


            if (item == null)
            {
                // No se encontró el elemento
                this.Page.ModelState.AddModelError("", String.Format("No se encontró el elemento con id. {0}", IdCarrito));
                return;
                
            }
           

            TryUpdateModel(item);

            //VG 14/02/2014
            //En caso de que sea una sucursal temporal
            if (item.TransferTemporal.Value != true)
            {
                item.Tel_Direcciones.IdSucursal = item.IdSucursal;
            }

            if (this.Page.ModelState.IsValid)
            {
                BLL.CarritoBLL cr = new BLL.CarritoBLL(item, db,true);
                
                this.db.SaveChanges();
                //GetDirecciones(Convert.ToInt32(this.grvClientes.SelectedDataKey.Value));
                // Guarde los cambios aquí, por ejemplo MyDataLayer.SaveChanges();
                ((Pedido)this.Page).ProductoCargado();

            }

        }

        protected void fvCarrito_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {

            e.NewValues["Vuelto"] = e.NewValues["Vuelto"].ToString().Replace(".", "");
            
            
        }   
    }
}