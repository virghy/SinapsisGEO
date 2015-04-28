using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Web;
namespace SinapsisGEO.Tools
{


    public class Mailer
    {
        public string AspTextMerge(string TemplatePageAndQueryString)
        {
            string MergedText = "";


            // *** Save the current request information
            HttpContext Context = HttpContext.Current;


            // *** Fix up the path to point at the templates directory
            TemplatePageAndQueryString = Context.Request.ApplicationPath + "/" + TemplatePageAndQueryString;

            // *** Now call the other page and load into StringWriter
            StringWriter sw = new StringWriter();
            try
            {
                // *** IMPORTANT: Child page's FilePath still points at current page
                //                QueryString provided is mapped into new page and then reset
                Context.Server.Execute(TemplatePageAndQueryString, sw);
                MergedText = sw.ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
                MergedText = null;
            }


            return MergedText;
        }

        public void EnviarMailAsync(string Destino, string Titulo, string mensaje)
        {
            EnviarMailDelegate dc = new EnviarMailDelegate(this.EnviarMail);
            AsyncCallback cb = new AsyncCallback(GetResultsOnCallback);
            IAsyncResult ar = dc.BeginInvoke(Destino, Titulo, mensaje, cb, null);
        }

        private delegate void EnviarMailDelegate(string Destino, string Titulo, string mensaje);

        private void GetResultsOnCallback(IAsyncResult ar)
        {
            EnviarMailDelegate del = (EnviarMailDelegate)((System.Runtime.Remoting.Messaging.AsyncResult)ar).AsyncDelegate;
        }


        private void EnviarMail(string Destino, string Titulo, string mensaje)
        {
            try
            {
                //Dim smtpServer As String = System.Configuration.ConfigurationManager.AppSettings("SMTPServer")
                string MailSoporte = System.Configuration.ConfigurationManager.AppSettings["MailSoporte"];

                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                if (Destino !=null)
                {
                    msg.To.Add(Destino);

                }

                if (MailSoporte !=null)
                {
                    msg.Bcc.Add(MailSoporte);                    
                }

                System.Configuration.AppSettingsReader appst = new System.Configuration.AppSettingsReader();

                //msg.To.Add("vgonzalez@futura.com.py")
                //msg.From = New System.Net.Mail.MailAddress("vgonzalez@futura.com.py", "Sinapsis", System.Text.Encoding.UTF8)
                msg.Subject = Titulo;
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.Body = mensaje;
                //msg.BodyEncoding = System.Text.Encoding.Default
                msg.IsBodyHtml = true;

                //Aquí es donde se hace lo especial
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                //client.Credentials = New System.Net.NetworkCredential("vgonzalez@futura.com.py", "Loquito06")
                //client.Port = 587
                //client.Port = 25
                //client.Host = smtpServer
                //client.EnableSsl = True ''--Esto es para que vaya a través de SSL que es obligatorio con GMail
                // Try
                client.Send(msg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                System.Diagnostics.EventLog Log = new System.Diagnostics.EventLog();
                Log.Source = "Sinapsis";

                Log.WriteEntry(Utility.GetMessageError(ex), System.Diagnostics.EventLogEntryType.Error);

            }

        }

        public void EnviarMailRegistro(string Destino)
        {
            //  Dim mail As New Mailer
            //Dim md As MailDefinition = New MailDefinition

            //md.BodyFileName = "~/MailTemplate/NuevaCuenta.htm"
            //Dim fileMsg As System.Net.Mail.MailMessage
            //Dim userInfo As MembershipUser = Membership.GetUser(Destino)

            //'Construct the verification URL
            //'Dim verifyUrl As String = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) & Page.ResolveUrl("~/Verify.aspx?ID=" & userInfo.ProviderUserKey.ToString())

            //Dim verifyUrl As String = VirtualPathUtility.ToAbsolute("~/ActivaCuenta.aspx?ID=" & userInfo.ProviderUserKey.ToString())

            //'Replace <%VerifyUrl%> placeholder with verifyUrl value
            //Dim replacements As ListDictionary = New ListDictionary
            //replacements.Add("<%VerifyUrl%>", verifyUrl)


            //fileMsg = md.CreateMailMessage(Destino, replacements, Nothing)

            //EnviarMailAsync(Destino, "Registro de Usuario McEntrega", fileMsg.Body)
            EnviarMailAsync(Destino, "Registro de Usuario McEntrega", AspTextMerge("MailTemplate/Registrado.aspx?Id=" + Destino));
        }

        public void EnviarMailPedido(string Destino, int Id)
        {
            //  Dim mail As New Mailer
            EnviarMailAsync(Destino, "Su Pedido en  McEntrega", AspTextMerge("MailTemplate/PedidoAgregado.aspx?Id=" + Id.ToString()));
        }

    }

}