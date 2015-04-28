using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisGEO.Admin
{
    public partial class Sucursal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                this.DetailsView1.DataSource = db.tel_Sucursal.Where(p => p.IdEmpresa == Global.IdEmpresa);
            }

        }

        // El parámetro del id. debe coincidir con el valor DataKeyNames establecido en el control
        // o ser representado con un atributo proveedor de valor, por ejemplo [QueryString]int id
        public DAL.tel_Sucursal DetailsView1_GetItem(int id)
        {
            return null;
        }
    }
}