﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Properties;

namespace System.Web.Http.Hosting
{
    /// <summary>Represents a message handler that suppresses host authentication results.</summary>
    /// <remarks>
    /// This message handler sets the current principal to anonymous upon entry. As a result, any authentication
    /// performed by the host is ignored. The subsequent pipeline, including <see cref="IAuthenticationFilter"/>s, is
    /// then the exclusive authority for authentication.
    /// </remarks>
    public class SuppressHostPrincipalMessageHandler : DelegatingHandler
    {
        private static readonly Lazy<IPrincipal> _anonymousPrincipal = new Lazy<IPrincipal>(
            () => new ClaimsPrincipal(new ClaimsIdentity()), isThreadSafe: true);

        /// <inheritdoc />
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            SetCurrentPrincipalToAnonymous(request);

            return base.SendAsync(request, cancellationToken);
        }

        private static void SetCurrentPrincipalToAnonymous(HttpRequestMessage request)
        {
            Contract.Assert(request != null);

            HttpRequestContext requestContext = request.GetRequestContext();

            if (requestContext == null)
            {
                throw new ArgumentException(SRResources.Request_RequestContextMustNotBeNull, "request");
            }

            requestContext.Principal = _anonymousPrincipal.Value;
        }
    }
}
