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
    
    public partial class tel_ProductoOpcion
    {
        public int IdOPProd { get; set; }
        public Nullable<int> IdOpcion { get; set; }
        public string IdProducto { get; set; }
        public Nullable<int> IdCategoria { get; set; }
        public string IdGrupo { get; set; }
        public string IdFamilia { get; set; }
        public string IdLinea { get; set; }
        public string IdTam { get; set; }
        public Nullable<int> Orden { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
    
        public virtual tel_Opciones tel_Opciones { get; set; }
        public virtual tel_Productos tel_Productos { get; set; }
    }
}
