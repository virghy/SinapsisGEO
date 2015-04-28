using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisGEO.Admin
{
    public partial class CargarArchivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdCargar_Click(object sender, EventArgs e)
        {
            if (this.FileUpload1.HasFile)
            {
                this.FileUpload1.SaveAs(MapPath("~/Upload/" + FileUpload1.FileName));
                
            }
        }
    }
}