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
    using System.Collections.Generic;
    
    public partial class tel_Ph_Interfase
    {
        public int IdPedido { get; set; }
        public Nullable<int> IdSucursal { get; set; }
        public string Header { get; set; }
        public string Details { get; set; }
        public string Cliente { get; set; }
        public Nullable<int> IdComanda { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public Nullable<int> IdDireccion { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<System.DateTime> Audit_Fecha { get; set; }
        public Nullable<int> Audit_Intentos { get; set; }
        public Nullable<System.DateTime> Audit_Intento1 { get; set; }
        public Nullable<System.DateTime> Audit_IntentoX { get; set; }
    }
}