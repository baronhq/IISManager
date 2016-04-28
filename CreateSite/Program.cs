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
            ServerManager mgr = new ServerManager();
            SiteCollection sites = mgr.Sites;
            for (int i = SITEBASENUMBER; i < NUMBEROFSITES + SITEBASENUMBER; i++)
            {
                if (!CreateSitesInIIS(sites, SITENAMEPREFIX, i, ROOTDIR))
                {
                    Console.WriteLine("Creating site {0} failed", i);
                }
            }

            mgr.CommitChanges();
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
    }
}
