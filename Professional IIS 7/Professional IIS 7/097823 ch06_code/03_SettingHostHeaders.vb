using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Web.Administration;

namespace ProfessionalIIS7
{
    class IIS7
    {
        static void Main(string[] args)
        {
            // create the server management object
            ServerManager managerServer = new ServerManager();
            
            //create site object off the server management object
            managerServer.Sites.Add("WebSite1", "http", "*:80:www.website1.com", "c:\\inetpub\\wwwroot\\website1");
            
            //create application pool
            managerServer.ApplicationPools.Add("WebSite1AppPool");

            //assign application pool to site.
            managerServer.Sites["WebSite1"].Applications[0].ApplicationPoolName = "WebSite1AppPool";

            //create apppool object
            ApplicationPool appPool = managerServer.ApplicationPools["WebSite1AppPool"];
            
            //set app pool options
            appPool.ManagedPipelineMode = ManagedPipelineMode.Integrated;
            appPool.AutoStart = true;
            appPool.Failure.RapidFailProtection = true;

            //write the changes
            managerServer.CommitChanges();
        }
    }
}
