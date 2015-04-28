using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SinapsisGEO.Control
{
    public class myCheckBox : CheckBoxList
        
        
    {
        public String IdOpcion { get; set; }

        public override string ClientID
        {
	    get 
	    { 
		     return IdOpcion;
	    }
}

//        Public Class myCheckBox
//    Inherits CheckBoxList

//    Public Property IdOpcion As String
//    Public Overrides ReadOnly Property ClientID As String
//        Get
//            Return IdOpcion
//        End Get
//    End Property

//End Class
    }
}