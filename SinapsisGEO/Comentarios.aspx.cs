using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Web.ModelBinding;
namespace SinapsisGEO
{
    public partial class Comentarios : System.Web.UI.Page
    {
        private SinapsisEntities db = new SinapsisEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                this.IdCliente.Value=Request.QueryString["IdCliente"];

                this.txtNroPedido.Text = Request.QueryString["NroPedido"];

                this.txtNombre.Text = Request.QueryString["Nombre"];
                int NroPedido =Convert.ToInt32(this.txtNroPedido.Text) ;
                var pd = db.tel_Pedidos.Where(p => p.NroPedido == NroPedido && p.IdEmpresa == Global.IdEmpresa).FirstOrDefault();
                if (pd !=null)
                {
                    this.txtTelefono.Text = pd.Telefono.Value.ToString();
                    this.txtTelefono.ReadOnly = true; 
                }
            }

        }
        public IQueryable<DAL.tel_TipoReclamo> GetTipoReclamo([QueryString("Anula")] bool? Anula )
        {
            string Filtro = "Anulacion";

            if (Anula == null)
            {
                Anula = false;
                Filtro = "Reclamos";

            }

            var query = this.db.tel_TipoReclamo.Where(p => p.IdEmpresa == Global.IdEmpresa & p.Grupo==Filtro);
            return query;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var item = new DAL.tel_Comentarios();
            item.IdEmpresa = Global.IdEmpresa;
            item.IdCliente = Convert.ToInt32( this.IdCliente.Value);
            item.IdPedido = Convert.ToInt32(this.txtNroPedido.Text);
            item.IdTipoReclamo = this.cboTipoReclamo.SelectedValue;

            Int64 nroTel ;
            if (Int64.TryParse(this.txtTelefono.Text,out nroTel))
            {
                item.Telefono = nroTel;
            }
            

            item.Comentario = this.txtObs.Text;
            item.Audit_Fecha = DateTime.Now;
            item.audit_Usuario = this.User.Identity.Name;

            db.tel_Comentarios.Add(item);
            db.SaveChanges();
            Response.Redirect("~/");
            //TryUpdateModel(item);
            //if (ModelState.IsValid)
            //{
            //    // Save changes here
            //    db.tel_Clientes.Add(item);
            //    db.SaveChanges();

            //}
        }
    }
}