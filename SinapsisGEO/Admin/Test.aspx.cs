using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinapsisGEO.Admin
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdEjecutar_Click(object sender, EventArgs e)
        {
         PH.Operaciones o = new PH.Operaciones();
         int id = Convert.ToInt32(this.inputEmail3.Text);
         o.SP_TEST(id, this.inputPassword3.Text);
           

        }

        protected void cmdWithTrans_Click(object sender, EventArgs e)
        {
            PH.Operaciones o = new PH.Operaciones();
            
            int id = Convert.ToInt32(this.inputEmail3.Text);
            o.SP_TEST_WITH_T(id, this.inputPassword3.Text);
 
        }
    }
}