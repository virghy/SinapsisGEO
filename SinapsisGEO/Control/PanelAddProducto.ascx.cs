﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace SinapsisGEO.Control
{
    public partial class PanelAddProducto : System.Web.UI.UserControl
    {
        private SinapsisEntities db = new SinapsisEntities(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    string idproducto = Request.QueryString["IdProducto"];
            //    if (idproducto != null)
            //    {
            //        CargarProducto(idproducto);
            //    }
            //}

        }

        public void ActualizarControles()
        {
            this.chkMitad.Checked = false;
        }


        public void CargarProducto(string IdProducto)
        {
            var p = BLL.Tablas.GetProductoById(IdProducto);
            if (p != null)
            {
                //this.imgProducto.ImageUrl = Page.ResolveUrl("~/images/productos/" + p.Imagen);

                chkMitad.Visible = p.PermiteMitad.HasValue ? p.PermiteMitad.Value : false;

                //24-03/2014
                //Verificamos si tiene querystring, si tiene, levantamos el carrito, si no tiene, es una consulta de productos

                if (Request.QueryString["Id"]!=null)
                {
                    int Id = Convert.ToInt32(Request.QueryString["Id"]);

                    var c = db.tel_Carrito.Find(Id);

                    var car = new BLL.CarritoBLL(c, db);
                    
                    this.lblPrecio.Text = car.TraerPrecio(IdProducto).ToString("N2");
                    this.cmdCancel.Visible = false;

                    
                }
                else
                {
                    this.cmdAgregar.Visible = false;
                    var pr = db.tel_Precios.Include("tel_ListaPrecio").Where(s => s.IdEmpresa == Global.IdEmpresa && s.IdProducto == IdProducto).ToList();
                    if (pr !=null)
                    {
                        StringBuilder str = new StringBuilder();
                        foreach (var item in pr)
                        {
                            str.AppendFormat("<br>{0}: {1:N2}", item.tel_ListaPrecio.Lista, item.Precio);
                        }
                        this.lblPrecio.Text = str.ToString();
                    }
                }


                this.lblProducto.Text = p.Descripcion;

                this.lblImporte.Text = this.lblPrecio.Text;
                this.IdProducto.Text = p.IdProducto.ToString();
                this.EsCombo.Text = p.EsCombo.HasValue && p.EsCombo.Value ? "S" : "N";   

                //foreach (DAL.tel_ProductoOpcion item in p.tel_ProductoOpcion)
                //{
                //    var op = (Control.Opciones)LoadControl("~\\Control\\Opciones.ascx");
                //    op.IdOpcion = item.IdOpcion.Value;
                //    this.PlaceHolder1.Controls.Add(op);
                //}

                var opciones = BLL.Tablas.GetOpciones(p.IdProducto, p.IdGrupo, p.IdFamilia, p.IdLinea);

                //foreach (DAL.tel_ProductoOpcion item in opciones)
                //{
                //    var op = (Control.Opciones)LoadControl("~\\Control\\Opciones.ascx");
                //    op.ID = item.IdOPProd.ToString();
                //    op.IdOpcion = item.IdOpcion.Value;
                //    this.PlaceHolder1.Controls.Add(op);
                //}

                this.rptOpciones.DataSource = opciones;
                this.rptOpciones.DataBind();

                this.cboMitad.DataSource = BLL.Tablas.GetOpcionesbyProducto(-1, p.IdGrupo, p.IdFamilia, p.IdLinea);
                this.cboMitad.DataBind();


            }
        }

        public void AddAgregados(string Valor, String Nombre  )
        {
            ListItem item = new ListItem(Nombre, Valor);
            this.lstAgregados.Items.Add(item);
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
           
            this.lblError.Text = "";

            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            Decimal Cantidad = Convert.ToInt16(cboCantidad.SelectedValue);
            var p = db.tel_Carrito.Find(Id);
            if (p != null)
            {


                var car = new BLL.CarritoBLL(p, db);

                if (chkMitad.Checked)
                {
                    var prod = db.tel_Productos.Find(this.IdProducto.Text);

                    if (prod.PermiteMitad.HasValue && prod.PermiteMitad.Value)
                    {
                        //car.AgregarItem(btn.CommandArgument, (decimal).5);
                        Cantidad = (decimal).5;
                    }
                    else
                    {
                        this.lblError.Text = "Este producto no permite Mitad/Mitad";
                        return;
                    }

                }

                TextBox txt = txtIndicaciones;
                String obs = null;
                if (txt.Text != "Indicaciones")
                {
                    obs = txt.Text;
                }

                if ( this.EsCombo.Text=="S" )
                {
                    car.AgregarItem(this.IdProducto.Text, Cantidad, obs, this.TraerContenido());
                }
                else
                {
                    car.AgregarItem(this.IdProducto.Text, Cantidad, obs);
                    if (chkMitad.Checked)
                    {
                        car.AgregarItem(this.cboMitad.SelectedValue, Cantidad, obs);
                    }
                }

                //Agregamos los Toppings

                foreach (ListItem  item in lstAgregados.Items)
                {
                    car.AgregarItem(item.Value, 1, "");
                }


                db.SaveChanges();

                txt.Text = "Indicaciones";

                if (car.Completo)
                {
                    this.chkMitad.Checked = false;
                }

                this.lstAgregados.Items.Clear();
                this.cboCantidad.SelectedValue = "1";
                ((Pedido)this.Page).ProductoCargado();

                //this.Pedido.DataBind();

            }
        }

        protected void cmdBorrarItem_Click(object sender, EventArgs e)
        {
            if (this.lstAgregados.SelectedItem != null)
            {
                this.lstAgregados.Items.Remove(this.lstAgregados.SelectedItem);
            }
        }

        String[] TraerContenido()
        {
            StringBuilder sb = new StringBuilder();
            foreach (RepeaterItem ri in rptOpciones.Items)
            {

                if (ri.ItemType == ListItemType.Item | ri.ItemType == ListItemType.AlternatingItem)
                {

                    var op = (Opciones)ri.FindControl("Opciones");
                    
                    ListBox lst = (ListBox)op.FindControl("lstOpciones");

                    var OpcionEsCombo = (HiddenField)op.FindControl("txtEsCombo");

                    if (OpcionEsCombo.Value == "SI")
                    {
                        
                    
                    foreach (ListItem lstItem in lst.Items)
                    {
                        if (lstItem.Selected )
                        {
                            sb.Append(lstItem.Value);
                            sb.Append(":");
                            CheckBox chk =(CheckBox)op.FindControl("chkMitad");
                            if (chk.Checked)
                            {
                                ListBox lstMitad = (ListBox)op.FindControl("lstOtraMitad");
                                if (lstMitad.SelectedValue!= null)
                                {
                                    
                                    sb.Append(lstMitad.SelectedValue);                                    
                                }
                            }
                            sb.Append(":");
                            sb.Append(((HiddenField)op.FindControl("txtCantidad")).Value);

                            sb.Append(";");
                           
                        }
                    }
                    }


                }
            }
            sb.Remove(sb.Length - 1, 1);

            return sb.ToString().Split(new Char[] { ';' });
        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            ((Consultas.Productos)this.Page).Cancelar();
        }

    }
}