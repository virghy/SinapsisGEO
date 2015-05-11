using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using SinapsisGEO;
using System.Configuration;
using log4net;
using System.Web.UI;

namespace SinapsisGEO
{
    public class Global : HttpApplication
    {
        public static Int32  IdEmpresa;
        public static Exception LastError;
        public static bool NotificarPedido;
        private readonly ILog log = LogManager.GetLogger("Aplicacion");
        void Application_Start(object sender, EventArgs e)
        {

            string str = "2.1.3";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-" + str + ".min.js",
                DebugPath = "~/Scripts/jquery-" + str + ".js",
                CdnPath = "http://http://code.jquery.com/jquery-" + str + ".min.js",
                CdnDebugPath = "http://code.jquery.com/jquery-" + str + ".js",
                CdnSupportsSecureConnection = true
            });


            ScriptManager.ScriptResourceMapping.AddDefinition("bootstrap", new ScriptResourceDefinition
            {
                Path = "~/Scripts/bootstrap.min.js",
                DebugPath = "~/Scripts/bootstrap.js",
                CdnPath = "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js",
                CdnDebugPath = "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.js",
                CdnSupportsSecureConnection = true
            });


            // Código que se ejecuta al iniciarse la aplicación
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            IdEmpresa = Convert.ToInt32(ConfigurationManager.AppSettings["IdEmpresa"]);
            NotificarPedido = Convert.ToBoolean(ConfigurationManager.AppSettings["NotificarPedido"]);
            //            log4net.Config.XmlConfigurator.Configure();
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(@Server.MapPath("~/log4net.config")));
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
            log.Error(LastError.Message, LastError);
            
        }
    }
}
