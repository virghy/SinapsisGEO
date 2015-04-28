using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;

namespace SinapsisGEO.Consultas
{
    public partial class VerCadena : System.Web.UI.Page
    {
        private DAL.SinapsisEntities db = new DAL.SinapsisEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdBuscar_Click(object sender, EventArgs e)
        {
            this.GridView1.DataBind();
        }

        public IQueryable<DAL.tel_Ph_Interfase> GetInterfase([Control("txtFecha")] DateTime? Fecha)
        {
            //int? NroPedido=null;

            //if (this.txtNroPedido.Text != string.Empty)
            //{
            //    NroPedido = Convert.ToInt32(this.txtNroPedido.Text);

            //}

            DateTime? dFecha = Fecha;

            DateTime? hFecha = Fecha.HasValue ? Fecha.Value.AddDays(1) : Fecha;
            var query = this.db.tel_Ph_Interfase.Where(p => p.Audit_Fecha >=dFecha   & p.Audit_Fecha <= hFecha);

            //this.ASPxDataView1.DataSource = query.ToList();
            //this.ASPxDataView1.DataBind();
            return query;
        }
    }
}