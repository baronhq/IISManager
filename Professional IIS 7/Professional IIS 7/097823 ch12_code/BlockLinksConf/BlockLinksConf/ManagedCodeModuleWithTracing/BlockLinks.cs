using System;
using System.Web;
using System.Collections.Specialized;

namespace CustomModules
{
    public class BlockLinks : IHttpModule
    {
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
                // Load ServerVariable collection into NameValueCollection object.
                coll = ctx.Request.ServerVariables;

                // Get names of all keys into a string array. 
                ServerName = coll["SERVER_NAME"];
                Referer    = coll["HTTP_REFERER"];

                if (!Referer.Contains(ServerName))
                {
                    // NOT initiated by a link from a local web page!
                    ctx.RewritePath(
                          "denied.bmp",  // replacement file
                          "/images",     // replacement path
                          ""             // replacement query string
                          );
                }
            }
        }
    }
}
