using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SinapsisWS
{
    public class Global : System.Web.HttpApplication
    {

        public static Int32  IdEmpresa;
        public static Exception LastError;
        public static bool NotificarPedido;
     //   private readonly ILog log = LogManager.GetLogger("Aplicacion");
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciarse la aplicación

            IdEmpresa = Convert.ToInt32(ConfigurationManager.AppSettings["IdEmpresa"]);
         //   NotificarPedido = Convert.ToBoolean(ConfigurationManager.AppSettings["NotificarPedido"]);
            //            log4net.Config.XmlConfigurator.Configure();
       //     log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(@Server.MapPath("~/log4net.config")));
          // Tools.Mailer ml = new Tools.Mailer();
          //  ml.EnviarMailAsync("vgonzalez@futura.com.py","Prueba de sistema","Probando");
            
             
            
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Código que se ejecuta al cerrarse la aplicación

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Código que se ejecuta cuando se produce un error sin procesar
            //this.LastError = Server.GetLastError();
            LastError = Server.GetLastError();
       //     log.Error(LastError.Message, LastError);
            
        }
    }
}