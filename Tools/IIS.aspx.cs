using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tools
{
    public partial class IIS : System.Web.UI.Page
    {
        const String AppName = "Sinapsis";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdReciclar_Click(object sender, EventArgs e)
        {
            try 
            {
            ServerManager server = new ServerManager();
            ApplicationPool myApplicationPool = null;
            
            //we will create a new ApplicationPool named 'MyApplicationPool'
            //we will first check to make sure that this pool does not already exist
            //since the ApplicationPools property is a collection, we can use the Linq FirstOrDefault method
            //to check for its existence by name
            if (server.ApplicationPools != null && server.ApplicationPools.Count > 0)
            {
                if (server.ApplicationPools.FirstOrDefault(p => p.Name == AppName) != null)
                {
                    //if we find the pool already there, we will get a referecne to it for update
                    myApplicationPool = server.ApplicationPools.FirstOrDefault(p => p.Name == AppName);
                    myApplicationPool.Recycle();
                    server.CommitChanges();
                    this.lblResultado.Text = "Aplicacion Sinapsis reciclada correctamente.";
                }
                
                else
                {
                    //if the pool is not already there we will create it
                    myApplicationPool = server.ApplicationPools.Add(AppName);
                }
               
            }
            else
            {
                //if the pool is not already there we will create it
                myApplicationPool = server.ApplicationPools.Add(AppName);
            }

            //if (myApplicationPool != null)
            //{
            //    //for this sample, we will set the pool to run under the NetworkService identity
            //    myApplicationPool.ProcessModel.IdentityType = ProcessModelIdentityType.NetworkService;

            //    //we set the runtime version
            //    myApplicationPool.ManagedRuntimeVersion = "v4.0";

            //    //we save our new ApplicationPool!
            //    server.CommitChanges();
            //}
                       
		
	        }
	        catch ( Exception ex)
	        {
		
		        this.lblResultado.Text=ex.Message;
	        }

        }
    }
}