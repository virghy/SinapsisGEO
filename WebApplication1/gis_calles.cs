//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class gis_calles
    {
        public gis_calles()
        {
            this.gis_Cuadrantes = new HashSet<gis_Cuadrantes>();
        }
    
        public int IdCalle { get; set; }
        public string Nombrecorto { get; set; }
        public string Tipo { get; set; }
        public string Titulo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Nullable<int> IdMunicipio { get; set; }
        public Nullable<int> IdDpto { get; set; }
        public string NombreLargo { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
    
        public virtual ICollection<gis_Cuadrantes> gis_Cuadrantes { get; set; }
    }
}
