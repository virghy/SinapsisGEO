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
    
    public partial class tel_Ciudades
    {
        public tel_Ciudades()
        {
            this.tel_Barrios = new HashSet<tel_Barrios>();
            this.Tel_Direcciones = new HashSet<Tel_Direcciones>();
        }
    
        public int IdCiudad { get; set; }
        public string Ciudad { get; set; }
        public Nullable<int> IdDpto { get; set; }
    
        public virtual ICollection<tel_Barrios> tel_Barrios { get; set; }
        public virtual ICollection<Tel_Direcciones> Tel_Direcciones { get; set; }
    }
}