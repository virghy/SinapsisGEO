using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisGEO
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String msg = String.Empty;
            Exception ex = Global.LastError;

            if (ex == null)
            {
                msg = "<br />&bull; Error Inesperado<br />";
            }
            else
            {
                if (this.Request["aspxerrorpath"] != null)
                {
                    msg = "<br /> Origen:" + Request["aspxerrorpath"] + "<br />";
                    this.HyperLink1.NavigateUrl = Request["aspxerrorpath"];
                }
                while (ex != null)
                {
                    msg += "<br />&bull; " + ex.Message + "<br />";
                    ex = ex.InnerException;
                }

                this.litErrorText.Text = msg;
                Page.Server.ClearError();
            }
        }
    }
}