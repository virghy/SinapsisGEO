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
    
    public partial class tel_Familia
    {
        public tel_Familia()
        {
            this.tel_Linea = new HashSet<tel_Linea>();
            this.tel_Productos = new HashSet<tel_Productos>();
        }
    
        public int IdEmpresa { get; set; }
        public string IdFamilia { get; set; }
        public string Familia { get; set; }
        public Nullable<bool> Activo { get; set; }
    
        public virtual ICollection<tel_Linea> tel_Linea { get; set; }
        public virtual ICollection<tel_Productos> tel_Productos { get; set; }
    }
}
