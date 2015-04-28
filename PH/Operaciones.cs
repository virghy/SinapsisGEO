using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web;
using FirebirdSql.Data.FirebirdClient;
namespace PH
{
    public class Operaciones
    {
        public PH.SP_COMANDA SP_GG_COMANDA_ADD(PH.PHEntities Entidad, Nullable<int> iDSUCURSAL, string hEADER, string dETAILS, string cLIENTE, Nullable<int> iDPEDIDO)
        {
           string spName = ConfigurationManager.AppSettings["SP_NAME_COMANDA"];
           return Entidad.SP_COMANDA.SqlQuery(spName, iDSUCURSAL, hEADER, dETAILS, cLIENTE, iDPEDIDO).FirstOrDefault();

            //return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_COMANDA>("SP_GG_COMANDA_ADD_EH", mergeOption, iDSUCURSALParameter, hEADERParameter, dETAILSParameter, cLIENTEParameter, iDPEDIDOParameter);
        }
        
        public PH.SP_COMANDA SP_GG_COMANDA_ADD(Nullable<int> iDSUCURSAL, string hEADER, string dETAILS, string cLIENTE, Nullable<int> iDPEDIDO)
        {
            PH.SP_COMANDA cm = null;
            using (FirebirdSql.Data.FirebirdClient.FbConnection cn = new FbConnection(ConfigurationManager.ConnectionStrings["PHConnection"].ConnectionString))
            {
                try
                {
                    cn.Open();
                    string spName = ConfigurationManager.AppSettings["SP_NAME_COMANDA"];
                    // declare command
                    FbCommand readCommand =
                      new FbCommand(spName, cn);
                   // new FbCommand("Select * From " + spName + "(@IDSucursal,@Header,@Details,@Cliente,@IdPedido)", cn);
                    readCommand.Parameters.Add(new FbParameter("@IDSucursal", iDSUCURSAL));
                    readCommand.Parameters.Add(new FbParameter("@Header", hEADER));
                    readCommand.Parameters.Add(new FbParameter("@Details", dETAILS));
                    readCommand.Parameters.Add(new FbParameter("@Cliente", cLIENTE));
                    readCommand.Parameters.Add(new FbParameter("@IdPedido", iDPEDIDO));
                    FbDataReader myreader = readCommand.ExecuteReader();
                    while (myreader.Read())
                    {
                        // load the combobox with the names of the people inside.
                        // myreader[0] reads from the 1st Column
                        //DeleteComboBox.Items.Add(myreader[0]);
                        cm = new SP_COMANDA();
                        cm.IDCOMANDA = myreader.GetInt32(0);
                        cm.IDCLIENTE = myreader.GetInt32(1);
                        cm.IDDIRECCION = myreader.GetInt32(2);
                        cm.ESTADO = myreader.GetInt32(3);
                        return cm;

                    }
                    myreader.Close(); // we are done with the reader
                }
                catch (Exception x)
                {
                    //MessageBox.Show(x.Message);
                    throw x;
                }
                finally
                {
                    cn.Close();
                }

            }

            return cm;
        }


    }
}


