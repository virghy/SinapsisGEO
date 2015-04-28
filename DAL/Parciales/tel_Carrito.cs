using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [MetadataType(typeof(CarritoMetaData))]
    public partial class tel_Carrito
    {
        public class CarritoMetaData
        {
            [DataType(DataType.Currency)]
            [DisplayFormat(DataFormatString = "{0:C}")]
            public Object TotalPedido { get; set; }
        }
       
    }

    public partial class tel_CombosDet
    {
        public String Descripcion
        {
            get
            {
                //return this.tel_Productos.Descripcion;
                return string.Empty;
            }
        }
    }

    


}
