using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateSite
{
    class Program
    {
        //新建网站
        const int NUMBEROFSITES = 2;
        const int SITEBASENUMBER = 1000;
        const string POOLPREFIX = "POOL_";
        const string SITENAMEPREFIX = "SITE";
        const string ROOTDIR = "d:\\content";

        static void Main(string[] args)
        {
            //新建网站
            //ServerManager mgr = new ServerManager();
            //SiteCollection sites = mgr.Sites;
            //for (int i = SITEBASENUMBER; i < NUMBEROFSITES + SITEBASENUMBER; i++)
            //{
            //    if (!CreateSitesInIIS(sites, SITENAMEPREFIX, i, ROOTDIR))
            //    {
            //        Console.WriteLine("Creating site {0} failed", i);
            //    }
            //}

            //mgr.CommitChanges();

            //设置aspnet编译目录
            //ServerManager manager = new ServerManager();
            //Configuration rootConfig = manager.GetWebConfiguration(new WebConfigurationMap(), null);

            //ConfigurationSection section = rootConfig.GetSection("system.web/compilation");
            //section.Attributes["tempDirectory"].Value = @"e:\inetpub\temp\temporary asp.net files\site1";
            //section.SetMetadata("lockAttributes", "tempDirectory");

            //manager.CommitChanges();

            NewMethod();
        }

        private static void NewMethod()
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

        static bool CreateSitesInIIS(SiteCollection sites, string sitePrefix, int siteId, string dirRoot)
        {

            string siteName = sitePrefix + siteId;
            // site gets set to Poolname using the following format. Example: 'Site_POOL10'
            string poolName = POOLPREFIX + sitePrefix + siteId;

            try
            {
                Site site = sites.CreateElement();
                site.Id = siteId;
                site.SetAttributeValue("name", siteName);
                sites.Add(site);

                Application app = site.Applications.CreateElement();
                app.SetAttributeValue("path", "/");
                app.SetAttributeValue("applicationPool", poolName);
                site.Applications.Add(app);

                VirtualDirectory vdir = app.VirtualDirectories.CreateElement();
                vdir.SetAttributeValue("path", "/");
                vdir.SetAttributeValue("physicalPath", dirRoot + @"\" + siteName);

                app.VirtualDirectories.Add(vdir);

                Binding b = site.Bindings.CreateElement();
                b.SetAttributeValue("protocol", "http");
                b.SetAttributeValue("bindingInformation", ":80:" + siteName);
                site.Bindings.Add(b);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Create site {0} failed. Reason: {1}", siteName, ex.Message);
                return false;
            }

            return true;
        }

        static void SetAnonymousUserToProcessId()
        {
            ServerManager mgr = new ServerManager();
            try
            {
                Configuration config = mgr.GetApplicationHostConfiguration();
                ConfigurationSection section = config.GetSection("system.webServer/security/authentication/anonymousAuthentication");
                section.SetAttributeValue("userName", (object)"");
                // if we don't remove the attribute we end up with an encrypted empty string
                section.RawAttributes.Remove("password");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Removing anonymous user entry failed. Reason: {0}", ex.Message);
            }

            mgr.CommitChanges();
            return;
        }
    }
}
