// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Web.Routing;

namespace System.Web.Mvc.Routing
{
    /// <summary>
    /// Provides information for building a <see cref="Route"/>.
    /// </summary>
    public interface IRouteInfoProvider
    {
        /// <summary>
        /// Gets the name of the route to generate.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the route template describing the URI pattern to match against.
        /// </summary>
        string Template { get; }    
    }
}