using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisGEO.Control
{
    public partial class PanelFaltante : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.rptSucursales.DataSource = BLL.CacheManager.GetFaltantes();
                this.rptSucursales.DataBind();
            }
        }
    }
}