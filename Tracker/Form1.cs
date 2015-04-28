using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tracker
{
    public partial class Form1 : Form
    {

        zkemkeeper.CZKEM axCZKEM1 = new zkemkeeper.CZKEM();
        SWS.WebService1SoapClient ws = new SWS.WebService1SoapClient();
        String IP;
        int Puerto;
         bool bIsConnected = false ;
         int iMachineNumber =1;
         int idwErrorCode;



        public Form1()
        {
            InitializeComponent();
            Puerto = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Puerto"]);
            IP = System.Configuration.ConfigurationManager.AppSettings["IP"];
            Conectar();

        }
        void Conectar()
        {
            if (btnConnect.Text=="Desconectar")
            {
                axCZKEM1.Disconnect();
                axCZKEM1.OnAttTransactionEx -= axCZKEM1_OnAttTransactionEx;
                 bIsConnected = false;
            btnConnect.Text = "Conectar";
            lblState.Text = "Estado Actual:Desconectado";
            Cursor = Cursors.Default;
            return;
            }
            else
            {
                bIsConnected = axCZKEM1.Connect_Net(IP, Puerto);
                if (bIsConnected)
                {
                    if (axCZKEM1.RegEvent(iMachineNumber, 65535))
                    {
                        axCZKEM1.OnAttTransactionEx += axCZKEM1_OnAttTransactionEx;
                    }
                    btnConnect.Text = "Desconectar";
                    lblState.Text = "Estado Actual:Conectado"; 
                }
                else
                {
                    axCZKEM1.GetLastError(idwErrorCode);
                    lblState.Text = "No se pudo conectar, Error=" + idwErrorCode.ToString();

                }
               
            }
           
            
        }

        void axCZKEM1_OnAttTransactionEx(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        {
          //  lbRTShow.Items.Add("RTEvent OnAttTrasactionEx Has been Triggered,Verified OK");
        lbRTShow.Items.Add("Movil: " + EnrollNumber);
       // lbRTShow.Items.Add("...isInvalid:" + IsInValid.ToString());
        lbRTShow.Items.Add("...Operacion: " + AttState.ToString());
    //    lbRTShow.Items.Add("...VerifyMethod:" + VerifyMethod.ToString());
    //    lbRTShow.Items.Add("...Workcode:"  + WorkCode.ToString()); //the difference between the event OnAttTransaction and OnAttTransactionEx
        lbRTShow.Items.Add("...Hora: " + Year.ToString() + "-" + Month.ToString() + "-" + Day.ToString() + " " + Hour.ToString() + ":" + Minute.ToString() + ":" + Second.ToString());

            EnviarEvento(Convert.ToInt32(EnrollNumber), new DateTime(Year, Month, Day, Hour, Minute, Second), AttState.ToString());
                   
        }
        void EnviarEvento(int IdMovil, DateTime Fecha, String Operacion)
        {
            int result = -1;
            result = ws.ActualizarMovil(IdMovil, Fecha, Operacion.Trim());
            lbRTShow.Items.Add("...Pedido: " + result.ToString()); 
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Conectar();
        }

    }
}
