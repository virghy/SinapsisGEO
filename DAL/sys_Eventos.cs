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
    
    public partial class sys_Eventos
    {
        public int IdEvento { get; set; }
        public string TipoEvento { get; set; }
        public string Info { get; set; }
        public Nullable<System.DateTime> FechaEvento { get; set; }
        public string Usuario { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
    }
}
