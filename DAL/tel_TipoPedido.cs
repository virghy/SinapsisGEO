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
    
    public partial class tel_TipoPedido
    {
        public tel_TipoPedido()
        {
            this.tel_Pedidos = new HashSet<tel_Pedidos>();
        }
    
        public int IdEmpresa { get; set; }
        public string IdTipoPedido { get; set; }
        public string TipoPedido { get; set; }
        public Nullable<decimal> Costo { get; set; }
        public string IdProductoCosto { get; set; }
    
        public virtual ICollection<tel_Pedidos> tel_Pedidos { get; set; }
    }
}
