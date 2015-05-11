using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH.Entidades
{
    public class SP_CALL_PRECIO
    {
        public string IDARTICULO { get; set; }
        public decimal PRECIO { get; set; }
        public int IDLISTA { get; set; }
        public string LISTA { get; set; }
    }
}
