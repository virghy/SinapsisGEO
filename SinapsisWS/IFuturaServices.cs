using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SinapsisWS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IFuturaServices" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IFuturaServices
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        int wsEnviarPedido(Pedido pedido, List<Detalle> detalle);

    }

    [DataContract]
    public class Pedido
    {

    [DataMember]
        public int NroPedido { get; set; }
    
    }

    [DataContract]
    public class Detalle
    {
        [DataMember]
        public int NroItem { get; set; }

    }
}
