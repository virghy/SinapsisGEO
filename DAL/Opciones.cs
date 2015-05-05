using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Opciones
    {
        public string IdProducto { get; set; }
        public string Descripcion { get; set; }
        public bool? Predet { get; set; }
        public decimal Cantidad { get; set; }
    }
}
