using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH.Entidades
{
    public class SP_CALL_PRODUCTO
    {
    //IDARTICULO Varchar(14),
    //IDGRUPO Integer,
    //GRUPO Varchar(30),
    //IDMEDIDA Integer,
    //IDLINEA Integer,
    //LINEA Varchar(40),
    //ARTICULO Varchar(100),
    //ESTADO Varchar(1),
    //DESCRIPCION_CORTA Varchar(20),
    //IDIMPUESTO Integer,
    //IDFAMILIA Integer,
    //FAMILIA Varchar(20),
    //IDMARCA Integer,
    //IDCOLECCION Integer,
    //COMBO Smallint,
    //PRODUCCION Smallint,
    //IDFRANQUICIA Integer,
    //FRANQUICIA Varchar(30),
    //DESCRIPCION_WEB Varchar(100) )
        public string IDARTICULO { get; set; }
        public int IDGRUPO { get; set; }
        public string GRUPO { get; set; }
        public int IDMEDIDA { get; set; }
        public int IDLINEA { get; set; }
        public string LINEA { get; set; }
        public string ARTICULO { get; set; }
        public string ESTADO { get; set; }
        public string DESCRIPCION_CORTA { get; set; }
        public int IDIMPUESTO { get; set; }
        public int IDFAMILIA { get; set; }
        public string FAMILIA { get; set; }
        public int IDMARCA { get; set; }
        public int IDCOLECCION { get; set; }
        public int COMBO { get; set; }
        public int PRODUCCION { get; set; }
        public int IDFRANQUICIA { get; set; }
        public string FRANQUICIA { get; set; }
        public string DESCRIPCION_WEB { get; set; }

 
    }
}
