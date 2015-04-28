using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services.Protocols;
using System.Xml.Linq;


namespace SinapsisWS
{
    public class Log4NetSoapExtension : SoapExtension
    {
        private static readonly ILog logger = LogManager.GetLogger("SinapsisWS");

        Stream oldStream;
        Stream newStream;

        public override Stream ChainStream(Stream stream)
        {
            oldStream = stream;
            newStream = new MemoryStream();
            return newStream;
        }

        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
        {
            return methodInfo.Name;
        }

        public override object GetInitializer(Type WebServiceType)
        {
            return WebServiceType.Name;
        }

        public override void Initialize(object initializer)
        {
        }

        public override void ProcessMessage(SoapMessage message)
        {
            switch (message.Stage)
            {
                case SoapMessageStage.BeforeSerialize:
                    break;
                case SoapMessageStage.AfterSerialize:
                    WriteOutput(message);
                    break;
                case SoapMessageStage.BeforeDeserialize:
                    WriteInput(message);
                    break;
                case SoapMessageStage.AfterDeserialize:
                    break;
            }
        }

        public void WriteOutput(SoapMessage message)
        {
            var soapString = (message is SoapServerMessage) ? "SoapResponse" : "SoapRequest";
            var header = soapString + ": " + message.MethodInfo.Name + "\n";

            if (message.Exception != null)
            {
                Log(header, newStream, message.Exception);
                return;
            }

            Log(header, newStream);

            Copy(newStream, oldStream);
        }

        public void WriteInput(SoapMessage message)
        {
            Copy(oldStream, newStream);

            string soapString = (message is SoapServerMessage) ? "SoapRequest" : "SoapResponse";
            var header = soapString + ": " + message.MethodInfo.Name + "\n";

            Log(header, newStream);
        }

        void Log(string header, Stream stream, Exception e = null)
        {
            var sb = new StringBuilder();
            var w = new StringWriter(sb);

            stream.Position = 0;
            Copy(stream, w);
            var msg = sb.ToString();
            try
            {
                //Since we're looking at SOAP, parse the XML so it gets formatted nicely.
                var log = header + XElement.Parse(msg.Trim()).ToString();
                if (e == null)
                    logger.Info(log);
                else
                    logger.Error(log, e);
            }
            catch (Exception) //message is not valid xml
            {
                if (e == null)
                    logger.Info(header + msg);
                else
                    logger.Error(header + msg, e);
            }

            //if (e != null)
            //    Elmah.ErrorSignal.FromCurrentContext().Raise(e);

            stream.Position = 0;
        }

        void Copy(Stream from, TextWriter to)
        {
            var reader = new StreamReader(from);
            to.WriteLine(reader.ReadToEnd());
            to.Flush();
        }

        void Copy(Stream from, Stream to)
        {
            TextReader reader = new StreamReader(from);
            TextWriter writer = new StreamWriter(to);
            writer.WriteLine(reader.ReadToEnd());
            writer.Flush();
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class Log4NetSoapExtensionAttribute : SoapExtensionAttribute
    {
        public override Type ExtensionType
        {
            get { return typeof(Log4NetSoapExtension); }
        }

        public override int Priority { get; set; }
    }
}