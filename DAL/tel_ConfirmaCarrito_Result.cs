//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    
    public partial class tel_ConfirmaCarrito_Result
    {
        public int IdPedido { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public Nullable<int> NroPedido { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public string Estado { get; set; }
        public Nullable<long> Telefono { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Empresa { get; set; }
        public string referencia { get; set; }
        public Nullable<int> audit_Usuario { get; set; }
        public Nullable<System.DateTime> Audit_Fecha { get; set; }
        public Nullable<int> horaCola { get; set; }
        public Nullable<int> horaPreparacion { get; set; }
        public Nullable<int> HoraEnvio { get; set; }
        public string HoraEntrega { get; set; }
        public string obs { get; set; }
        public Nullable<int> IdMovil { get; set; }
        public Nullable<int> IdSucursal { get; set; }
        public string cuadrante { get; set; }
        public string IdTipoPedido { get; set; }
        public Nullable<decimal> CostoEnvio { get; set; }
        public Nullable<decimal> TotalPedido { get; set; }
        public Nullable<decimal> TotalGeneral { get; set; }
        public Nullable<decimal> Vuelto { get; set; }
        public string UserName { get; set; }
        public string Anulado { get; set; }
        public Nullable<int> IdFormaPago { get; set; }
        public Nullable<int> IdCarrito { get; set; }
        public Nullable<int> IdPedidoWeb { get; set; }
    }
}
