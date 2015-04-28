using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Text;


namespace SinapsisGEO.Control
{
    public partial class PanelCombo : System.Web.UI.UserControl
    {


        private SinapsisEntities db = new SinapsisEntities();
        private String IdProducto;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public String[] TraerContenido()
        {
            StringBuilder sb = new StringBuilder();
            foreach (RepeaterItem ri in Repeater1.Items)
            {

                if (ri.ItemType == ListItemType.Item | ri.ItemType == ListItemType.AlternatingItem)
                {
                    ListBox lst = (ListBox)ri.FindControl("lstComboDet");

                    foreach (ListItem lstItem in lst.Items)
                    {
                        if (lstItem.Selected)
                        {
                            sb.Append(lstItem.Value);
                            sb.Append(";");
                        }
                    }
                }
            }
            sb.Remove(sb.Length - 1, 1);
            
            return sb.ToString().Split(new Char[] { ';' });
        }


        public void CargarDatos(String IdProducto)
        {
            this.IdProducto = IdProducto;
            this.Repeater1.DataBind();
        }

        public IQueryable<DAL.tel_Combos> GetCombos()
        {
            if (IdProducto != String.Empty)
            {
                var query = this.db.tel_Combos.Include("tel_CombosDet").Include("tel_CombosDet.tel_Productos").Where(p => p.IdEmpresa == Global.IdEmpresa && p.IdProducto == this.IdProducto);

                return query;
            }
            return null;
        }

        protected void lstComboDet_DataBound(object sender, EventArgs e)
        {
            ListBox lst = (ListBox)sender;
            foreach (ListItem lstItem in lst.Items)
            {
    //                lstItem.
    //                lstItem.Selected = blnFlag;

            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType== ListItemType.AlternatingItem)
            {
                RepeaterItem ri = e.Item;
                ListBox lst = (ListBox)ri.FindControl("lstComboDet");
           
                DAL.tel_Combos cb = (DAL.tel_Combos)e.Item.DataItem;
                foreach (tel_CombosDet cd in cb.tel_CombosDet)
                {
                    ListItem l = new ListItem(cd.tel_Productos.Descripcion, cd.IdProducto);
                    l.Selected = cd.Predet.Value;
                    lst.Items.Add(l);
                }
            }
           
            
        }
       
    }
}