using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SinapsisWS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "FuturaServices" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione FuturaServices.svc o FuturaServices.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class FuturaServices : IFuturaServices
    {
        public void DoWork()
        {
        }


        public int wsEnviarPedido(Pedido pedido, List<Detalle> detalle)
        {
            return pedido.NroPedido;
        }
    }
}
