using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SinapsisGEO.Tools
{
    public class RecycleIIS
    {
        public void PoolRecycle(string appPoolName)
        {
            //using (var serverMgr = new ServerManager())
            //{
            //    var appPool = serverMgr.ApplicationPools.SingleOrDefault(p => p.Name.Equals(appPoolName, StringComparison.InvariantCultureIgnoreCase));
            //    if (appPool != null)
            //    {
            //        appPool.Recycle();
            //    }
            //    else
            //    {
            //        Trace.WriteLine(string.Format("[PoolRecycle] Can't find pool: [{0}]", appPoolName));
            //    }
            //}
        }
    }
}