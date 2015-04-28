using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisGEO.Remote
{
    public partial class Faltantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (! IsPostBack)
            {
                CargarDatos();
                this.HyperLink1.NavigateUrl = string.Format("~/Remote/Tablero.aspx?Id={0}", Request.QueryString["Id"]);
            }
        }

        protected void cmdActualizar_Click(object sender, EventArgs e)
        {
            this.lblError.Text = "";
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                foreach (DataListItem item in DataList1.Items)
                {

                    int IdFaltante = Convert.ToInt32(((HiddenField)item.FindControl("IdFaltante")).Value);
                    bool Falta = ((CheckBox)item.FindControl("chkFalta")).Checked;
                    var Faltante = db.tel_Faltantes.Find(IdFaltante);
                    if (Faltante != null)
                    {
                        Faltante.Falta = Falta;
                        db.SaveChanges();
                    }
                }
                BLL.CacheManager.RemoverCache(BLL.CacheManager.chkFaltantes);
            }
        }

        protected void cmdAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblError.Text = "";
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                DAL.tel_Insumos insumo = new DAL.tel_Insumos();
                insumo.IdEmpresa = Global.IdEmpresa;
                insumo.Descripcion = this.txtInsumo.Text;
                insumo.Activo = true;
                db.tel_Insumos.Add(insumo);
                db.SaveChanges();
                this.txtInsumo.Text = "";
                BLL.CacheManager.RemoverCache(BLL.CacheManager.chkFaltantes);
                CargarDatos();
            }
            }
            catch (Exception ex)
            {
                this.lblError.Text = Utility.GetMessageError(ex);
                
            }

        }
        void CargarDatos()
        {
            if (Request.QueryString["Id"] != null)
            {
                int IdSucursal = Convert.ToInt32(Request.QueryString["Id"]);

                using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
                {
                    var Suc = db.tel_Faltantes.Include("tel_Insumos").Where(p => p.IdEmpresa == Global.IdEmpresa && p.IdSucursal == IdSucursal).OrderBy(p => p.tel_Insumos.Descripcion).ToList();
                    this.DataList1.DataSource = Suc;
                    this.DataList1.DataBind();
                }
            }
        }
    }
}