using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace IISManagerMvc.App_Code
{
    public class PermissionModule : IHttpModule
    {

        public void Init(HttpApplication app)
        {
            app.AcquireRequestState += new EventHandler(context_AcquireRequestState);

            app.AuthorizeRequest += new EventHandler(context_AuthorizeRequest);

            app.AuthenticateRequest += new EventHandler(context_AuthenticateRequest);

            app.BeginRequest += new EventHandler(app_BeginRequest);
        }

        private void app_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication httpApp = (HttpApplication)sender;
            HttpContext ctx = HttpContext.Current;

            NameValueCollection coll;  // to handle the CGI variables

            String ServerName = String.Empty; // variable to store the SERVER_NAME 
            String Referer = String.Empty;    // and HTTP_REFERER CGI variables.

            coll = ctx.Request.ServerVariables;

            // Get names of all keys into a string array. 
            ServerName = coll["SERVER_NAME"];
            Referer = coll["HTTP_REFERER"];

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

        private void context_AuthenticateRequest(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void context_AuthorizeRequest(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void context_AcquireRequestState(object sender, EventArgs e)
        {
           
        }

        public void Dispose()
        {

        }
    }
}