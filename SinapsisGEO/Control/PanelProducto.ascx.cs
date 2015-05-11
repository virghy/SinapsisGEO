using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Web.ModelBinding;
using log4net;
using System.Data.Entity;
namespace SinapsisGEO.Control
{
    public partial class PanelProducto : System.Web.UI.UserControl
    {
        private SinapsisEntities db; 
        private BLL.Tablas tb;
        private int IdEmpresa = Global.IdEmpresa;
        private string IdProducto="";
        private int IdMenu = 0;
        private static readonly ILog log = LogManager.GetLogger(typeof(PanelProducto).Name);

       // private string IdProductoAnt;

        public PanelProducto()
        {
            db= new SinapsisEntities();
            tb = new BLL.Tablas(db);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) {
             //   CargarFamilia();
                CargarMenu();
            }

        }

        private void CargarMenu()
        {
            var menu = db.sys_Menu.Where(p=> p.Activo==true && p.IdEmpresa==Global.IdEmpresa).ToList();
            
            foreach (var item in menu)
            {
                if (item.IdPadre == null)
                {
                    MenuItem mnu = new MenuItem(item.Nombre, item.IdMenu.ToString(), "", item.Ubicacion);
                    Menu1.Items.Add(mnu);
                    cargarSubMenu(item.IdMenu, menu,mnu);
                }
            }


        }
        private void cargarSubMenu(int IdPadre, List<DAL.sys_Menu> menu, MenuItem padre)
        {
            var lista = menu.Where(p => p.IdPadre == IdPadre);
            foreach (var item in lista)
            {
                MenuItem mnu = new MenuItem(item.Nombre, item.IdMenu.ToString(), "", item.Ubicacion);
                padre.ChildItems.Add(mnu);
                cargarSubMenu(item.IdMenu, menu,mnu);

            }


        }




        void CargarProductos()
        {
            this.dlProducto.Visible = true;

            this.dlProducto.DataSource = GetProductos().ToList();
            this.dlProducto.DataBind();

            this.dlGrupo.Visible = false;
        }

        void CargarLinea()
        {
            this.dlLinea.Visible = true;
            this.dlLinea.DataSource = GetLineas().ToList();
            this.dlLinea.DataBind();

            this.dlGrupo.Visible = false;
            this.dlProducto.Visible = false;

        }

        void CargarGrupo()
        {
            this.dlGrupo.Visible = true;
            this.dlGrupo.DataSource = GetGrupos().ToList();
            this.dlGrupo.DataBind();
            this.dlProducto.Visible = false;


            //Si no tiene grupos, buscamos directamente los productos
            if (this.dlGrupo.Items.Count == 0)
            {
                this.txtIdGrupo.Value = "-1";
                this.CargarProductos();

            }

            ////Si un solo grupo, buscamos directamente los productos
            //if (this.dlGrupo.Items.Count == 1)
            //{
            //    this.txtIdGrupo.Value = "-1";
            //    this.CargarProductos();

            //}




        }

        void CargarFamilia()
        {
            this.dlFamilia.Visible = true;
            this.dlFamilia.DataSource = tb.GetFamilias().ToList();
            this.dlFamilia.DataBind();

            this.dlLinea.Visible = false;
            this.dlGrupo.Visible = false;
            this.dlProducto.Visible = false;


        }

        public IQueryable<DAL.tel_Familia> GetFamilias()
        {
                var query = this.db.tel_Familia.Where(p => p.IdEmpresa == this.IdEmpresa);
                return query.OrderBy(p=> p.Familia);
          
        }

        public IQueryable<DAL.tel_Linea> GetLineas()
        {
            var query = this.db.tel_Linea.Where(p => p.IdEmpresa == this.IdEmpresa && p.IdFamilia == this.txtIdFamilia.Value & p.Activo==true);
            return query.OrderBy(p=> p.Linea);

        }

        public IQueryable<DAL.tel_Grupo> GetGrupos()
        {
            var query = this.db.tel_Grupo.Where(p => p.IdEmpresa == this.IdEmpresa && p.IdFamilia == this.txtIdFamilia.Value && p.IdLinea==this.txtIdLinea.Value & p.Activo==true);
            return query.OrderBy(p=> p.Grupo);

        }


        //public IQueryable<DAL.tel_Productos> GetProductos()
        //{
        //    if (IdProducto != "")
        //    {
        //        var query = this.db.tel_Productos.Where(p => p.IdEmpresa == this.IdEmpresa && (p.IdGrupo == this.IdProducto));
        //        return query;
        //    }
        //    else
        //    {

        //        var query = this.db.tel_Productos.Where(p => p.IdEmpresa == this.IdEmpresa && p.IdGrupo==null).OrderBy(p=> p.Orden);
        //        return query;
        //    }
        //}
        public IQueryable<DAL.tel_Productos> GetProductos()
        {
            var query = from s in this.db.tel_Productos
                        join m in this.db.sys_MenuDet
                        on s.IdFamilia equals m.IdFamilia 
                        where s.IdLinea==m.IdLinea
                        && s.IdGrupo == m.IdGrupo
                        && m.IdMenu == IdMenu
                        && s.Activo==true
                        && s.IdEmpresa==Global.IdEmpresa
                        orderby s.Orden
                        select s;
                                                        

                //var query = this.db.tel_Productos.Where(p => p.IdEmpresa == this.IdEmpresa && p.IdFamilia == this.txtIdFamilia.Value 
                //                                        && p.IdLinea== this.txtIdLinea.Value 
                //                                        && p.IdGrupo== this.txtIdGrupo.Value & p.Activo==true).OrderBy(p => p.Orden);
                return query;
           
        }

        public IQueryable<DAL.tel_Productos> GetProducto()
        {
            if (IdProducto != "")
            {
                var query = this.db.tel_Productos.Where(p => p.IdEmpresa == this.IdEmpresa && p.IdGrupo == this.IdProducto);
                return query;
            }
            else
            {

                var query = this.db.tel_Productos.Where(p => p.IdEmpresa == this.IdEmpresa && p.IdGrupo == null);
                return query;
            }
        }

        protected void btnProducto_Click(object sender, EventArgs e)
        {
            //this.IdProductoAnt = this.IdProducto;
            Button btn = ((Button)sender);

            this.IdProducto = btn.CommandArgument;
           // this.btnAnterior.CommandArgument = btn.CommandName;
          //  this.Repeater1.DataBind();
           // this.btnAnterior.Enabled=true;




            switch (btn.CommandName)
            {
                case "F":
                    this.txtIdFamilia.Value = btn.CommandArgument;
                    this.CargarLinea();
                    this.dlFamilia.Visible = false;
                    break;
                case "L":
                    this.txtIdLinea.Value = btn.CommandArgument;
                    this.CargarGrupo();
                    this.dlLinea.Visible = false;
                    break;
                case "G":
                    this.txtIdGrupo.Value = btn.CommandArgument;
                    this.CargarProductos();
                    this.dlGrupo.Visible = false;
                    break;


            }
//            CargarProductos();



        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {

            //Button btn = ((Button)sender);

            //this.IdProducto = btn.CommandArgument;
            //this.IdProductoAnt = this.IdProducto;
           // this.Repeater1.DataBind();

            if (!String.IsNullOrEmpty(this.txtIdGrupo.Value))
            {
                //CargarLinea();
                this.dlGrupo.Visible = true;
                this.dlProducto.Visible = false;

                this.txtIdGrupo.Value = "";
                return;
               
            }

            if (!String.IsNullOrEmpty(this.txtIdLinea.Value))
            {
                //CargarFamilia();
                this.dlLinea.Visible = true;
                this.dlGrupo.Visible = false;

                this.txtIdLinea.Value = "";
                return;
            }

            if (!String.IsNullOrEmpty(this.txtIdFamilia.Value))
            {
                //CargarFamilia();
                this.dlFamilia.Visible = true;
                this.dlLinea.Visible = false;

                this.txtIdFamilia.Value = "";
                return;
            }
       

            //CargarProductos();

            //if (this.IdProducto != "")
            //{
            //    var query = this.db.tel_Productos.Where(p => p.IdEmpresa == this.IdEmpresa && p.IdProducto == this.IdProducto).FirstOrDefault();

            //    btn.CommandArgument = query.IdPadre;
            //}

           //this.btnAnterior.Enabled = (this.IdProductoAnt != null);
        }

        public IQueryable<DAL.tel_Carrito> GetCarritoActual([QueryString("Id")] int? Id)
        {
            var query = this.db.tel_Carrito.Include("tel_Clientes").Include("tel_Direcciones").Include("tel_Carrito_Item").Include("tel_Carrito_Item.tel_Productos").Where(p => p.IdEmpresa == this.IdEmpresa && p.IdCarrito == Id && p.Estado==null);
            var q = from p in this.db.tel_Carrito
                    .Include(p=> p.tel_Clientes)
                    select p;

            //TODO: Cambiar orden de ItemDetalle

            return query;

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            LinkButton btn = ((LinkButton)sender);
            if (Request.QueryString["Id"]==null)
            {
               

                ((Consultas.Productos)this.Page).CargarProducto(btn.CommandArgument);
                return;
            }

            

            ((Pedido)this.Page).CargarProducto(btn.CommandArgument);
            return;



            this.lblError.Text = "";

            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            Decimal Cantidad = 1;
            var p = db.tel_Carrito.Find(Id);
            if (p !=null)
            {
                
       
                var car = new BLL.CarritoBLL(p,db);
                
                 if (chkMitad.Checked)
                 {
                     var prod = db.tel_Productos.Find(btn.CommandArgument);

                     if (prod.PermiteMitad.HasValue && prod.PermiteMitad.Value)
                     {
                         //car.AgregarItem(btn.CommandArgument, (decimal).5);
                         Cantidad = (decimal).5;
                     }
                     else
                     {
                         this.lblError.Text="Este producto no permite Mitad/Mitad";
                         return;
                     }

                 }
                 //else
                 //{
                 //    car.AgregarItem(btn.CommandArgument, 1);
                 //}

                TextBox txt = (TextBox)btn.Parent.FindControl("txtObs");
                String obs = null;
                if (txt.Text != "Indicaciones")
                {
                    obs = txt.Text;
                }

                 if (btn.CommandName == "C")
                 {
                     car.AgregarItem(btn.CommandArgument, Cantidad, obs, this.PanelCombo.TraerContenido(),false);
                 }
                 else
                 {
                     car.AgregarItem(btn.CommandArgument, Cantidad,obs);
                 }
                
                db.SaveChanges();

               // txt.Text = "Indicaciones";

                if (car.Completo)
                {
                    this.chkMitad.Checked = false;
                }

                this.Pedido.DataBind();

            }
        }


        BLL.CarritoBLL GetCarrito()
        {
            BLL.CarritoBLL car=null;
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            var c = db.tel_Carrito.Where(p => p.IdCarrito == Id && p.IdEmpresa == Global.IdEmpresa && p.Estado == null).FirstOrDefault();
            if (c != null)
            {
                car = new BLL.CarritoBLL(c,db);
            }
            return car;

        }


        protected void btnBorraItem_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            var car = GetCarrito();
            if (car != null)
            {
                Int32 Id = Convert.ToInt32(btn.CommandArgument);
                var item = db.tel_Carrito_Item.Include("tel_Carrito_Item1").Where(p => p.IdCarritoItem==Id).FirstOrDefault() ;
                //DAL.tel_Carrito_Item item = db.tel_Carrito_Item.Find(Convert.ToInt32(btn.CommandArgument));
                car.BorrarItem(item);
                db.SaveChanges();
                this.Pedido.DataBind();
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {

            var cr = GetCarrito();
            if (cr != null)
                {

                if (cr.Completo)
                {   
                    cr.ConfirmaCarrito();
                    Response.Redirect("~/");
                }
                    else
                {
                    this.lblError.Text = "El pedido esta incompleto.";
                }
            }else
	        {
                this.lblError.Text = "El pedido no existe o ya ha sido confirmado.";
	        }

                }
            catch (Exception ex)
            {
                this.lblError.Text = MensajeError(ex);
                log.Error(this.lblError.Text, ex);
                //throw ex;
            }
        }

        string MensajeError(Exception ex)
        {
            System.Text.StringBuilder Mensaje =  new System.Text.StringBuilder();
            while (ex !=null)
            {
                Mensaje.AppendLine(ex.Message);
                Mensaje.AppendLine("<br />");
                ex = ex.InnerException;
            }
            return Mensaje.ToString();
        }

        protected void btnAgregarCombo_Click(object sender, EventArgs e)
        {
            this.programmaticModalPopup.Show();

            Button btn = ((Button)sender);
            this.PanelCombo.CargarDatos(btn.CommandArgument);
            this.cmdAgregar.CommandArgument = btn.CommandArgument;
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            IdMenu = Convert.ToInt32(e.Item.Value);
            this.CargarProductos();

            //var MenuDet = db.sys_MenuDet.Where(p => p.IdMenu == IdMenu).FirstOrDefault();
            //if (MenuDet != null)
            //{
            //    this.txtIdFamilia.Value = MenuDet.IdFamilia;
            //    this.txtIdLinea.Value = MenuDet.IdLinea;
            //    this.txtIdGrupo.Value = MenuDet.IdGrupo;
            //    this.CargarProductos();
            //}
        }

        public void ActualizarCarrito()
        {
            this.Pedido.DataBind();
        }
        public void ActualizarAvisos()
        {
            this.PanelAviso1.CargarDatos();
        }

    }
}