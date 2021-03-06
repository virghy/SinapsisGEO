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
    
    public partial class tel_Productos
    {
        public tel_Productos()
        {
            this.tel_Carrito_Item = new HashSet<tel_Carrito_Item>();
            this.tel_PedidosDet = new HashSet<tel_PedidosDet>();
            this.tel_Precios = new HashSet<tel_Precios>();
            this.tel_ProductoOpcion = new HashSet<tel_ProductoOpcion>();
            this.tel_CombosDet = new HashSet<tel_CombosDet>();
        }
    
        public int IdEmpresa { get; set; }
        public string IdProducto { get; set; }
        public string IdPadre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Activo { get; set; }
        public string Tipo { get; set; }
        public string IdGrupo { get; set; }
        public string IdGrupoPadre { get; set; }
        public string Contenido { get; set; }
        public Nullable<bool> PideCantidad { get; set; }
        public Nullable<int> SaboresMax { get; set; }
        public string Orden { get; set; }
        public Nullable<bool> Seleccionable { get; set; }
        public Nullable<bool> FiltraSucursal { get; set; }
        public string DescripcionCorta { get; set; }
        public Nullable<bool> EsCombo { get; set; }
        public string IdProducto1 { get; set; }
        public string IdFamilia { get; set; }
        public string IdLinea { get; set; }
        public string IdTam { get; set; }
        public Nullable<bool> PermiteMitad { get; set; }
        public Nullable<bool> IncluyeEnvio { get; set; }
        public string IdProductoAgranda { get; set; }
        public string IdCostoAgranda { get; set; }
        public Nullable<int> IdVersion { get; set; }
    
        public virtual ICollection<tel_Carrito_Item> tel_Carrito_Item { get; set; }
        public virtual tel_Familia tel_Familia { get; set; }
        public virtual tel_Linea tel_Linea { get; set; }
        public virtual ICollection<tel_PedidosDet> tel_PedidosDet { get; set; }
        public virtual ICollection<tel_Precios> tel_Precios { get; set; }
        public virtual ICollection<tel_ProductoOpcion> tel_ProductoOpcion { get; set; }
        public virtual ICollection<tel_CombosDet> tel_CombosDet { get; set; }
    }
}
