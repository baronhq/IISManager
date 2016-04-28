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
            

            managerServer.Sites["WebSite1"].LogFile.Enabled = true;
            managerServer.Sites["WebSite1"].LogFile.LogFormat = LogFormat.W3c;
            managerServer.Sites["WebSite1"].LogFile.LocalTimeRollover = true;
            managerServer.Sites["WebSite1"].LogFile.Directory = "c:\\logs\\" + managerServer.Sites["WebSite1"].Id.ToString();

            managerServer.CommitChanges();
        }
    }
}
