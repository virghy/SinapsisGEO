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
    
    public partial class tel_Moviles
    {
        public tel_Moviles()
        {
            this.tel_Pedidos = new HashSet<tel_Pedidos>();
            this.tel_MovilTracker = new HashSet<tel_MovilTracker>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdMovil { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<bool> Ocupado { get; set; }
        public Nullable<int> IdSucursal { get; set; }
    
        public virtual ICollection<tel_Pedidos> tel_Pedidos { get; set; }
        public virtual tel_Sucursal tel_Sucursal { get; set; }
        public virtual ICollection<tel_MovilTracker> tel_MovilTracker { get; set; }
    }
}
