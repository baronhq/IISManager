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

            //add the bindings for www.website1.com and website1.com
            managerServer.Sites["WebSite1"].Bindings.Add("www.website1.com:80", "http");
            managerServer.Sites["WebSite1"].Bindings.Add("website1.com:80", "http");

            //write the changes
            managerServer.CommitChanges();
        }
    }
}
