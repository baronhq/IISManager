﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.ComponentModel;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.OData.Formatter;
using System.Web.OData.Properties;
using System.Web.OData.Query;

namespace System.Web.OData.Extensions
{
    /// <summary>
    /// Provides extension methods for the <see cref="HttpConfiguration"/> class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class HttpConfigurationExtensions
    {
        // Maintain the System.Web.OData. prefix in any new properties to avoid conflicts with user properties
        // and those of the v3 assembly.
        private const string ETagHandlerKey = "System.Web.OData.ETagHandler";

        /// <summary>
        /// Enables query support for actions with an <see cref="IQueryable" /> or <see cref="IQueryable{T}" /> return
        /// type. To avoid processing unexpected or malicious queries, use the validation settings on
        /// <see cref="EnableQueryAttribute"/> to validate incoming queries. For more information, visit
        /// http://go.microsoft.com/fwlink/?LinkId=279712.
        /// </summary>
        /// <param name="configuration">The server configuration.</param>
        public static void AddODataQueryFilter(this HttpConfiguration configuration)
        {
            AddODataQueryFilter(configuration, new EnableQueryAttribute());
        }

        /// <summary>
        /// Enables query support for actions with an <see cref="IQueryable" /> or <see cref="IQueryable{T}" /> return
        /// type. To avoid processing unexpected or malicious queries, use the validation settings on
        /// <see cref="EnableQueryAttribute"/> to validate incoming queries. For more information, visit
        /// http://go.microsoft.com/fwlink/?LinkId=279712.
        /// </summary>
        /// <param name="configuration">The server configuration.</param>
        /// <param name="queryFilter">The action filter that executes the query.</param>
        public static void AddODataQueryFilter(this HttpConfiguration configuration, IActionFilter queryFilter)
        {
            if (configuration == null)
            {
                throw Error.ArgumentNull("configuration");
            }

            configuration.Services.Add(typeof(IFilterProvider), new QueryFilterProvider(queryFilter));
        }

        /// <summary>
        /// Gets the <see cref="IETagHandler"/> from the configuration.
        /// </summary>
        /// <param name="configuration">The server configuration.</param>
        /// <returns>The <see cref="IETagHandler"/> for the configuration.</returns>
        public static IETagHandler GetETagHandler(this HttpConfiguration configuration)
        {
            if (configuration == null)
            {
                throw Error.ArgumentNull("configuration");
            }

            object handler;
            if (!configuration.Properties.TryGetValue(ETagHandlerKey, out handler))
            {
                IETagHandler defaultETagHandler = new DefaultODataETagHandler();
                configuration.SetETagHandler(defaultETagHandler);
                return defaultETagHandler;
            }

            if (handler == null)
            {
                throw Error.InvalidOperation(SRResources.NullETagHandler);
            }

            IETagHandler etagHandler = handler as IETagHandler;
            if (etagHandler == null)
            {
                throw Error.InvalidOperation(SRResources.InvalidETagHandler, handler.GetType());
            }

            return etagHandler;
        }

        /// <summary>
        /// Sets the <see cref="IETagHandler"/> on the configuration.
        /// </summary>
        /// <param name="configuration">The server configuration.</param>
        /// <param name="handler">The <see cref="IETagHandler"/> for the configuration.</param>
        public static void SetETagHandler(this HttpConfiguration configuration, IETagHandler handler)
        {
            if (configuration == null)
            {
                throw Error.ArgumentNull("configuration");
            }
            if (handler == null)
            {
                throw Error.ArgumentNull("handler");
            }

            configuration.Properties[ETagHandlerKey] = handler;
        }
    }
}
