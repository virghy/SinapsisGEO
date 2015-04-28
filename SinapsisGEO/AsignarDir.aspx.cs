using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;


namespace SinapsisGEO
{
    public partial class AsignarDir : System.Web.UI.Page
    {
        private DAL.SinapsisEntities db = new DAL.SinapsisEntities();

        private int IdEmpresa = Global.IdEmpresa;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DateTime dt = DateTime.Today;
                dt=dt.AddMonths(-1);
                
                DateTime di = new DateTime(dt.Year, dt.Month, 1);
                DateTime df = di.AddDays(-1).AddMonths(1);
                
                this.txtdFecha.Text = di.ToString("dd/MM/yyyy");
                this.txthFecha.Text = df.ToString("dd/MM/yyyy");

            using (var db = new DAL.SinapsisEntities())
            {

                this.dboSucursal.DataSource = db.tel_Sucursal.Where(c=> c.IdEmpresa==this.IdEmpresa).ToList();

                this.dboSucursal.DataBind();

                this.cboOperador.DataSource = db.UsersInfoes.ToList();
                this.cboOperador.DataBind();
            }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            RecuperarCliente();
        }

        void RecuperarCliente()
        {
            this.lblMensaje.Text = "";

            using (var db = new DAL.SinapsisEntities())
            {
                int Sucursal;
                Sucursal = Convert.ToInt32(dboSucursal.SelectedValue);

                string Operador = cboOperador.SelectedValue;

                
                DateTime di;

                DateTime.TryParse(this.txtdFecha.Text, out di);

                DateTime df;

                DateTime.TryParse(this.txthFecha.Text, out df);
               

              //  var query = this.db.tel_Clientes.Where(c => c.IdEmpresa == this.IdEmpresa && c.IdSucursal == IdSucursal && !c.GeoLat.HasValue).OrderBy(c => c.Direccion).Take(5);

                var IdEmpresa = new SqlParameter
                {
                    ParameterName = "IdEmpresa",
                    Value = Global.IdEmpresa
                };

                var IdSucursal = new SqlParameter
                {
                    ParameterName = "IdSucursal",
                    Value = Sucursal
                };

                var dFecha = new SqlParameter
                {
                    ParameterName = "dFecha",
                    Value = di
                };

                var hFecha = new SqlParameter
                {
                    ParameterName = "hFecha",
                    Value = df
                };

                //Get student name of string type
                //listaGEO = dm.Database.SqlQuery<GeoData>("exec dbo.GEO1 @IdEmpresa, @IdSucursal ", IdEmpresa, IdSucursal).ToList<GeoData>();

                //listaGEO = dm.Database.SqlQuery<GeoData>("exec dbo.GEO1 @IdEmpresa, @IdSucursal ", IdEmpresa, IdSucursal).ToList<GeoData>();

                //var query = db.tel_Clientes.SqlQuery("exec dbo.GEOClientes @IdEmpresa, @IdSucursal,@dFecha,@hFecha ", IdEmpresa, IdSucursal,dFecha,hFecha).ToList<tel_Clientes>();

                //var q1 = db.Tel_Direcciones.Include("tel_Clientes").Where(p=> p.GeoLat == null).Any(u=> u.IdCliente

                var query = (from s in db.Tel_Direcciones.Include("tel_Clientes")
                             where db.tel_Pedidos.Any(es =>
                                 es.IdCliente == s.IdCliente && es.IdEmpresa == Global.IdEmpresa && es.Fecha >= di && es.Fecha <= df && es.IdTipoPedido=="01"
                                    && (es.UserName == Operador || Operador == "--"))
                                 && s.GeoLat == null
                                 && (s.IdSucursal==Sucursal || Sucursal==0)
                             orderby s.Direccion, s.NroCasa
                             select s).ToList();

                //query = query.Where(c => c.IdEmpresa == this.IdEmpresa && c.IdSucursal == 1);
                this.fvCliente.DataSource = query;
                this.fvCliente.DataBind();

                if (query.Count > 0 )
                {


                    this.txtDireccion.Text = query.FirstOrDefault().Direccion;

                }
                else
                {
                    this.txtDireccion.Text = "";
                }
            }
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblError.Text = "";
                this.lblMensaje.Text = "";

            using (var db1 = new DAL.SinapsisEntities())
            {
                //int IdSucursal;
                //IdSucursal = Convert.ToInt32(dboSucursal.SelectedValue);
                var numberFormatInfo = new NumberFormatInfo();
                numberFormatInfo.NumberDecimalSeparator = ".";

                var query = db1.Tel_Direcciones.Find(this.fvCliente.SelectedValue);
                //query = query.Where(c => c.IdEmpresa == this.IdEmpresa && c.IdSucursal == 1);
                query.GeoLat = Decimal.Parse(this.txtLat.Text, numberFormatInfo);
                query.GeoLng = Decimal.Parse(this.txtLng.Text, numberFormatInfo);
              //  db.tel_Clientes.Attach(query);
                        
                 //   query.Direccion1 = "c/Haedo";

                    db1.SaveChanges();

                    //this.RecuperarCliente();

                    this.txtLat.Text = "";
                    this.txtLng.Text = "";
                    this.lblMensaje.Text = "Registro actualizado correctamente.";
            }
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
        }

    }
}