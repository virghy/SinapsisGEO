using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SinapsisWS
{
    public class WSPedido
    {
        public int NroPedido { get; set; }
        public int NroSucursal { get; set; }
        public int IdModulo { get; set; }
        public int IdPersona { get; set; }
        public int IdDireccion { get; set; }
        public DateTime Fecha_pedido { get; set; }
        public DateTime Fecha_entrega { get; set; }
        public string Comentario { get; set; }
        public int CantidadItems { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Ruc { get; set; }
        public string Referencia { get; set; }
        public string Ciudad { get; set; }
        public override string ToString()
        {
            return String.Format(@"NroPedido={0}, NroSucursal{1}, IdModulo={2}, IdPersona={3}, 
IdDireccion={4}, Fecha_pedido={5}, Fecha_entrega={6}, Comentario={7},
CantidadItems={8}, Nombre={9}, Apellido={10}, 
Direccion={11}, Telefono{12}, Ruc={13}, Referencia={14}, Ciudad={15}" , 
                                NroPedido, NroSucursal, IdModulo,IdPersona,
                                IdDireccion, Fecha_pedido,Fecha_entrega,Comentario,
                                CantidadItems,Nombre,Apellido,
                                Direccion,Telefono,Ruc,Referencia,Ciudad);
        }

    }
    public class WSPedidoDet
    {
        public int NroItem { get; set; }
        public string IdArticulo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string Comentario { get; set; }
        public int NroItemPadre { get; set; }

        public override String ToString() {
            return String.Format("NroItem={0}, IdArticulo={1}, Cantidad={2}, Precio={3}, Comentario={4}, NroItemPadre={5}", NroItem, IdArticulo, Cantidad, Precio, Comentario, NroItemPadre);
        }

    }
}