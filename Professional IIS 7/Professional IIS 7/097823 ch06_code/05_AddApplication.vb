using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Web.Administration;
using Microsoft.Web.Management;

namespace ProfessionalIIS7
{
    public class IIS7
    {
        // Creates an application under WebSite1.
        public void CreateApplication()
        {
            ServerManager manager = new ServerManager();
            Site defaultSite = manager.Sites["WebSite1"];
            defaultSite.Applications.Add("/app1", @"C:\inetpub\wwwroot\app1");
            manager.CommitChanges();
        }
    }
}
