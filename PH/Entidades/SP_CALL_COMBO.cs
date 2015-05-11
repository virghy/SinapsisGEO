using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH.Entidades
{
    public class SP_CALL_COMBO
    {
    //IDPROMO Varchar(14),
    //PROMO Varchar(200),
    //IDDEFINICION_PROMO Integer,
    //DEFINICION_PROMO Varchar(100),
    //CANTIDAD_DEFINICION Integer,
    //IDPRODUCTO_CMB Integer,
    //IDPRODUCTO Varchar(14),
    //PRODUCTO Varchar(200),
    //CANTIDAD Double precision,
    //PREDETERMINADO Integer,
    //ESTADO Integer,
    //COMBINACIONES Double precision,
    //AGRANDADO Varchar(14),
    //IDART_COSTO_AGRANDADO Varchar(14) )
        public string IDPROMO { get; set; }
        public string PROMO { get; set; }
        public int IDDEFINICION_PROMO { get; set; }
        public string DEFINICION_PROMO { get; set; }
        public int CANTIDAD_DEFINICION { get; set; }
        public int IDPRODUCTO_CMB { get; set; }
        public string IDPRODUCTO { get; set; }
        public string PRODUCTO { get; set; }
        public decimal CANTIDAD { get; set; }
        public int PREDETERMINADO { get; set; }
        public int? ESTADO { get; set; }
        public int? COMBINACIONES { get; set; }
        public String AGRANDADO { get; set; }
        public string IDART_COSTO_AGRANDADO { get; set; }
    }
}
