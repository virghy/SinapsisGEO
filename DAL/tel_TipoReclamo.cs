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
    
    public partial class tel_TipoReclamo
    {
        public tel_TipoReclamo()
        {
            this.tel_Comentarios = new HashSet<tel_Comentarios>();
        }
    
        public int IdEmpresa { get; set; }
        public string IdTipoReclamo { get; set; }
        public string TipoReclamo { get; set; }
        public Nullable<bool> Anula { get; set; }
        public Nullable<bool> Activo { get; set; }
        public string Grupo { get; set; }
    
        public virtual ICollection<tel_Comentarios> tel_Comentarios { get; set; }
    }
}
