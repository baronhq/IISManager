using System;
using System.Web;
using System.Collections.Specialized;
using System.Diagnostics;
using Microsoft.Web.Administration;

namespace CustomModules
{
    public class BlockLinks : IHttpModule
    {
        TraceSource ts;
        String permitBookmarks = "false";
        
        public BlockLinks()
        {
            // Class constructor.
        }

        // Classes that inherit IHttpModule 
        // must implement the Init and Dispose methods.
        public void Init(HttpApplication app)
        {
            // TODO:
            // Add initialization code
            // Including notifications
            app.BeginRequest += new EventHandler(app_BeginRequest);

            ts = new TraceSource("BlockLinks");

            // create the server management object
            ServerManager sm = new ServerManager();

            // Open the applicationHost.config data
            Configuration conf = sm.GetApplicationHostConfiguration();
            // Open the configuration section
            ConfigurationSection sect = conf.GetSection("BlockLinksSection");
            // Read the attribute value
            permitBookmarks = sect.GetAttributeValue("permitBookmarks").ToString();
        }

        public void Dispose()
        {
            // TODO:
            // Add code to clean up the
            // instance variables of a module.
        }

        // TODO:
        // add event notification methods
        // Define a custom BeginRequest event handler.

        public void app_BeginRequest(object o, EventArgs ea)
        {
            ts.TraceEvent(TraceEventType.Start, 0,
                      "[BlockLinks] START BeginRequest");

            HttpApplication httpApp = (HttpApplication)o;
            HttpContext ctx = HttpContext.Current;

            NameValueCollection coll;  // to handle the CGI variables

            String ServerName = String.Empty; // variable to store the SERVER_NAME 
            String Referer = String.Empty;    // and HTTP_REFERER CGI variables.

            // retrieve the URL requested
            String RequestUrl = ctx.Request.RawUrl;

            if (RequestUrl.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                RequestUrl.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) ||
                RequestUrl.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
            {
                // Is an image file
                ts.TraceEvent(TraceEventType.Information, 0,
                          "[BlockLinks] Detected request for image");

                // Load ServerVariable collection into NameValueCollection object.
                coll = ctx.Request.ServerVariables;

                // Get names of all keys into a string array. 
                ServerName = coll["SERVER_NAME"];
                Referer    = coll["HTTP_REFERER"];

                if (!Referer.Contains(ServerName))
                {
                    // NOT initiated by a link from a local web page!
                    if (Referer == "")
                    {
                        if (permitBookmarks == "false")
                        {
                            ts.TraceEvent(TraceEventType.Warning, 0,
                                      "[BlockLinks] Bookmark request detected");
                            ctx.RewritePath(
                                           "denied.bmp",  // replacement file
                                           "/images",     // replacement path
                                           ""             // replacement query string
                                           );
                        }
                    }
                    else
                    {
                        ts.TraceEvent(TraceEventType.Warning, 0,
                                  "[BlockLinks] Cross-Linked request detected from" + Referer);

                        ctx.RewritePath(
                              "denied.bmp",  // replacement file
                              "/images",     // replacement path
                              ""             // replacement query string
                              );
                    }
                }
            }

            ts.TraceEvent(TraceEventType.Stop, 0,
                      "[BlockLinks] END BeginRequest");
        }
    }
}
