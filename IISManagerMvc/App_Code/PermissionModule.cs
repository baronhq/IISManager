using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IISManagerMvc.App_Code
{
    public class PermissionModule : IHttpModule
    {

        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += new EventHandler(context_AcquireRequestState);

            context.AuthorizeRequest += new EventHandler(context_AuthorizeRequest);

            context.AuthenticateRequest += new EventHandler(context_AuthenticateRequest);
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