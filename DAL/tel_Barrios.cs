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
    
    public partial class tel_Barrios
    {
        public tel_Barrios()
        {
            this.Tel_Direcciones = new HashSet<Tel_Direcciones>();
        }
    
        public int IdBarrio { get; set; }
        public string Barrio { get; set; }
        public Nullable<int> IdCiudad { get; set; }
    
        public virtual tel_Ciudades tel_Ciudades { get; set; }
        public virtual ICollection<Tel_Direcciones> Tel_Direcciones { get; set; }
    }
}
