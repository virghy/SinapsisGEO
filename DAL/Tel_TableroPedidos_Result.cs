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
    
    public partial class Tel_TableroPedidos_Result
    {
        public int IdPedido { get; set; }
        public Nullable<int> NroPedido { get; set; }
        public string Estado { get; set; }
        public Nullable<System.DateTime> Audit_Fecha { get; set; }
        public Nullable<int> tCola { get; set; }
        public Nullable<int> tPreparacion { get; set; }
        public Nullable<int> tEnvio { get; set; }
        public Nullable<int> tTotal { get; set; }
        public string Anulado { get; set; }
        public string IdTipoPedido { get; set; }
        public Nullable<int> IdFormaPago { get; set; }
        public string Nombre { get; set; }
    }
}
