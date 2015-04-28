using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Mapping;

namespace SinapsisGEO.Control
{
    public partial class PanelEntrante : System.Web.UI.UserControl
    {
        private SinapsisEntities db = new SinapsisEntities();
     
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblHora.Text = DateTime.Now.ToString("HH:mm");
            this.Notificar.Value = "N";

        }

        public IQueryable<DAL.tel_Carrito> GetCarrito()
        {
            var query = this.db.tel_Carrito.Include("tel_Clientes").Include("tel_Direcciones").Include("tel_Carrito_Item").Where(p => p.IdEmpresa == Global.IdEmpresa && p.UserName == "web" && p.Estado==null);
            return query;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var cr = db.tel_Carrito.Find(Convert.ToInt32(btn.CommandArgument));
            if (cr != null)
            {
                db.tel_Carrito.Remove(cr);
                db.SaveChanges();
      
            }

            Response.Redirect("~/");
            
        }
       
    }
}