using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace SinapsisGEO.Control
{
    public partial class Opciones : System.Web.UI.UserControl
    {

        myCheckBox chkList ;
        RadioButtonList RdList; 

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private int _IdOpcion;

        public int IdOpcion
        {
            get { return _IdOpcion; }
            set
            {
                _IdOpcion = value;
                CargarOpcion();
            }
        }

        public bool? PermiteMitad
        {
            get;
            set;
        }

        public bool? EsCombo { get; set; }

        public void CargarOpcion()
        {
            

            var o = BLL.Tablas.GetOpcionById(IdOpcion);
            if (o != null)
            {
                this.lblTitulo.Text = o.Titulo.ToUpper();
                this.lblIdOpcion.Text = IdOpcion.ToString() +'('+ o.Maximo.ToString() + ')';
                this.txtCantidad.Value = o.Maximo.ToString();

                this.txtEsCombo.Value = o.EsCombo.HasValue ? (o.EsCombo.Value == true ? "SI" : "NO") : "NO";

                AgregarCheck(o, o.TipoControl);

                //Dim chkList As New CheckBoxList

                //Dim item As New ListItem
                //item.Text = "Sprite"
                //item.Value = "3200"

                //item.Attributes.Add("onclick", "javascript:SumarAdicionales()")
                //chkList.Items.Add(item)
                //chkList.Items.Add(New ListItem("Fanta", "1500"))
                //chkList.Items.Add(New ListItem("Coca", "2000"))
                //Me.PlaceHolder1.Controls.Add(chkList)

            }
        }


        public void AgregarCheck(tel_Opciones Seleccion, string TipoControl)
        {
            //  Dim lista = Seleccion.Replace(vbLf, "").Split(vbCr)
            var lista = Seleccion.tel_OpcionesDet;
            string _Titulo = null;
            string _tag = null;


            if (TipoControl == "C")
            {
                chkList = new myCheckBox();

                chkList.RepeatDirection = RepeatDirection.Horizontal;
                chkList.RepeatColumns = 4;
                chkList.IdOpcion = IdOpcion.ToString();
                chkList.ClientIDMode = ClientIDMode.Predictable;

            }
            else
            {
                RdList = new RadioButtonList();
                RdList.RepeatDirection = RepeatDirection.Horizontal;
                RdList.RepeatColumns = 4;
            }

            this.EsCombo = Seleccion.EsCombo;
            this.PermiteMitad = Seleccion.PermiteMitad;
            
            this.chkMitad.Visible = Seleccion.PermiteMitad.HasValue ? Seleccion.PermiteMitad.Value : false;

            this.lstOpciones.SelectionMode = Seleccion.Maximo > 1 ? ListSelectionMode.Multiple : ListSelectionMode.Single;
            this.lstOtraMitad.SelectionMode = Seleccion.Maximo > 1 ? ListSelectionMode.Multiple : ListSelectionMode.Single;

            List<DAL.Opciones> listaProducto;

            if (Seleccion.IdFamilia==null && Seleccion.IdLinea == null && Seleccion.IdGrupo==null)
            {
                listaProducto = BLL.Tablas.GetOpcionesbyProducto(Seleccion.IdOpcion);    
            }
            else
            {

                listaProducto = BLL.Tablas.GetOpcionesbyProducto(Seleccion.IdOpcion, Seleccion.IdGrupo, Seleccion.IdFamilia, Seleccion.IdLinea);
            }



            //this.chkOpciones.DataSource = listaProducto;
            //this.chkOpciones.DataBind();

           // this.lstOpciones.DataSource = listaProducto;
           // this.lstOpciones.DataBind();
            foreach (var item in listaProducto)
            {
                ListItem i = new ListItem(item.Descripcion, item.IdProducto);
            //                i.Selected=item
            i.Selected = item.Predet.HasValue ? item.Predet.Value : false;
            this.lstOpciones.Items.Add(i);
            }

            

            

            if (this.PermiteMitad.HasValue && this.PermiteMitad.Value)
            {
                //this.lstOtraMitad.DataSource = listaProducto;
                //this.lstOtraMitad.DataBind();
                foreach (var item in listaProducto)
                {
                    ListItem i = new ListItem(item.Descripcion, item.IdProducto);
                    //                i.Selected=item
                    i.Selected = item.Predet.HasValue ? item.Predet.Value : false;
                    this.lstOtraMitad.Items.Add(i);
                }
            }
            else
            {
                this.lstOtraMitad.Visible = false;
                this.chkMitad.Checked = false;
            }

            this.cmdAddItems.Visible = !(this.EsCombo.HasValue ? this.EsCombo.Value : false);

            
            return;

            //    foreach (tel_Productos od in listaProducto)
            //{
                

            //    _Titulo = od.DescripcionCorta;
            //    _tag = "0";
            //    //   Dim chk As New CheckBox With {. = _Titulo, .Tag = _tag}
            //    //     AddHandler chk.Checked, AddressOf ProcesarCheck
            //    //    AddHandler chk.Unchecked, AddressOf ProcesarCheck
            //    //      Me.StkSeleccion.Children.Add(chk)
            //    ListItem item = new ListItem();
            //    item.Text = _Titulo;

            //    item.Value = string.Format("{0}:{1}", od.IdProducto, _tag);

            //    item.Attributes.Add("onclick", "javascript:SumarAdicionales()");
            //    if (TipoControl == "C")
            //    {
            //        chkList.Items.Add(item);
            //    }
            //    else
            //    {
            //        RdList.Items.Add(item);
            //    }

            //}

            //if (TipoControl == "C")
            //{
            //    this.PlaceHolder2.Controls.Add(chkList);
            //}
            //else
            //{
            //    this.PlaceHolder2.Controls.Add(RdList);
            //}



   





            //foreach (tel_OpcionesDet od in Seleccion.tel_OpcionesDet)
            //{
                

            //    _Titulo = od.Titulo;
            //    _tag = od.ValorAdicional.HasValue ? od.ValorAdicional.Value.ToString() : "0";
            //    //   Dim chk As New CheckBox With {. = _Titulo, .Tag = _tag}
            //    //     AddHandler chk.Checked, AddressOf ProcesarCheck
            //    //    AddHandler chk.Unchecked, AddressOf ProcesarCheck
            //    //      Me.StkSeleccion.Children.Add(chk)
            //    ListItem item = new ListItem();
            //    item.Text = _Titulo;
            //    item.Value = string.Format("{0}:{1}", od.IdOD, _tag);

            //    item.Attributes.Add("onclick", "javascript:SumarAdicionales()");
            //    if (TipoControl == "C")
            //    {
            //        chkList.Items.Add(item);
            //    }
            //    else
            //    {
            //        RdList.Items.Add(item);
            //    }

            //}
            //if (TipoControl == "C")
            //{
            //    this.PlaceHolder2.Controls.Add(chkList);
            //}
            //else
            //{
            //    this.PlaceHolder2.Controls.Add(RdList);
            //}



        }

        protected void cmdAddItems_Click(object sender, EventArgs e)
        {
            ((Pedido)this.Page).AddAgregados(lstOpciones.SelectedValue,lstOpciones.SelectedItem.Text );
        }

        protected void chkMitad_CheckedChanged(object sender, EventArgs e)
        {
            this.lstOtraMitad.Visible = chkMitad.Checked;
        }

       

        //public void AgregarCheck(string Seleccion, string TipoControl)
        //{
        //    dynamic lista = Seleccion.Replace(Constants.vbLf, "").Split(Constants.vbCr);
        //    string _Titulo = null;
        //    string _tag = null;


        //    if (TipoControl == "C")
        //    {
        //        chkList = new myCheckBox();
        //        chkList.RepeatDirection = RepeatDirection.Horizontal;
        //        chkList.RepeatColumns = 4;
        //        chkList.IdOpcion = IdOpcion;
        //        chkList.ClientIDMode = ClientIDMode.Predictable;
        //    }
        //    else
        //    {
        //        RdList = new RadioButtonList();
        //        RdList.RepeatDirection = RepeatDirection.Horizontal;
        //        RdList.RepeatColumns = 4;
        //    }











        //    for (i = 0; i <= lista.Length - 1; i++)
        //    {
        //        if (lista(i).LastIndexOf("=") > 0)
        //        {
        //            _Titulo = lista(i).Substring(0, lista(i).LastIndexOf("="));
        //            _tag = lista(i).Substring(lista(i).LastIndexOf("=") + 1);
        //        }
        //        else
        //        {
        //            _Titulo = lista(i);
        //            _tag = "0";
        //        }

        //        //   Dim chk As New CheckBox With {. = _Titulo, .Tag = _tag}
        //        //     AddHandler chk.Checked, AddressOf ProcesarCheck
        //        //    AddHandler chk.Unchecked, AddressOf ProcesarCheck
        //        //      Me.StkSeleccion.Children.Add(chk)
        //        ListItem item = new ListItem();
        //        item.Text = _Titulo;
        //        item.Value = _tag;

        //        item.Attributes.Add("onclick", "javascript:SumarAdicionales()");
        //        if (TipoControl == "C")
        //        {
        //            chkList.Items.Add(item);
        //        }
        //        else
        //        {
        //            RdList.Items.Add(item);
        //        }

        //    }
        //    if (TipoControl == "C")
        //    {
        //        this.PlaceHolder1.Controls.Add(chkList);
        //    }
        //    else
        //    {
        //        this.PlaceHolder1.Controls.Add(RdList);
        //    }



        //}


    }
}