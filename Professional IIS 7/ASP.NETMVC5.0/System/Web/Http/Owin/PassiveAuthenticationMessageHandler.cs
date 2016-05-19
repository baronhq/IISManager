﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Hosting;
using System.Web.Http.Owin.Properties;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace System.Web.Http.Owin
{
    /// <summary>Represents a message handler that treats all OWIN authentication middleware as passive.</summary>
    /// <remarks>
    /// This message handler sets the current principal to anonymous upon entry and disables the default OWIN
    /// authentication middleware challenges. As a result, any default authentication performed by the host is ignored.
    /// The subsequent pipeline, including <see cref="IAuthenticationFilter"/>s, is then the exclusive authority for
    /// authentication.
    /// </remarks>
    public class PassiveAuthenticationMessageHandler : DelegatingHandler
    {
        private static readonly Lazy<IPrincipal> _anonymousPrincipal = new Lazy<IPrincipal>(
            () => new ClaimsPrincipal(new ClaimsIdentity()), isThreadSafe: true);

        /// <inheritdoc />
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            SetCurrentPrincipalToAnonymous(request);

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            SuppressDefaultAuthenticationChallenges(request);

            return response;
        }

        private static void SetCurrentPrincipalToAnonymous(HttpRequestMessage request)
        {
            Contract.Assert(request != null);

            HttpRequestContext requestContext = request.GetRequestContext();

            if (requestContext == null)
            {
                throw new ArgumentException(OwinResources.Request_RequestContextMustNotBeNull, "request");
            }

            requestContext.Principal = _anonymousPrincipal.Value;
        }

        private static void SuppressDefaultAuthenticationChallenges(HttpRequestMessage request)
        {
            Contract.Assert(request != null);

            IAuthenticationManager authenticationManager = request.GetAuthenticationManager();

            if (authenticationManager == null)
            {
                throw new InvalidOperationException(OwinResources.IAuthenticationManagerNotAvailable);
            }

            AuthenticationResponseChallenge currentChallenge = authenticationManager.AuthenticationResponseChallenge;

            // A null challenge or challenge.AuthenticationTypes == null or empty represents the the default behavior
            // of running all active authentication middleware challenges.
            // Provide an array with a single null item to suppress this default behavior.
            string[] suppressAuthenticationTypes = new string[] { null };

            if (currentChallenge == null)
            {
                authenticationManager.AuthenticationResponseChallenge = new AuthenticationResponseChallenge(
                    suppressAuthenticationTypes, new AuthenticationProperties());
            }
            else if (currentChallenge.AuthenticationTypes == null || currentChallenge.AuthenticationTypes.Length == 0)
            {
                authenticationManager.AuthenticationResponseChallenge = new AuthenticationResponseChallenge(
                    suppressAuthenticationTypes, currentChallenge.Properties);
            }
        }
    }
}
