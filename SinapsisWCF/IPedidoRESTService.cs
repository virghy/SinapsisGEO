using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SinapsisWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPedidoRESTService" in both code and config file together.
    [ServiceContract]
    public interface IPedidoRESTService
    {
        [OperationContract]
           [WebInvoke(Method = "GET",
                                    ResponseFormat = WebMessageFormat.Json,
                                   BodyStyle = WebMessageBodyStyle.Bare,
                                   UriTemplate = "GetProductList/")]
           List<Pedido> GetProductList();
    }
}
