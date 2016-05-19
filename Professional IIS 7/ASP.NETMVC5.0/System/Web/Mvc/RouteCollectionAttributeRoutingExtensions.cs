﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace System.Web.Mvc
{
    // Corresponds to the Web API implementation of attribute routing in System.Web.Http.HttpConfigurationExtensions.
    public static class RouteCollectionAttributeRoutingExtensions
    {
        /// <summary>
        /// Maps the attribute-defined routes for the application.
        /// </summary>
        /// <param name="routes"></param>
        public static void MapMvcAttributeRoutes(this RouteCollection routes)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }

            AttributeRoutingMapper.MapAttributeRoutes(routes, new DefaultInlineConstraintResolver());
        }

        /// <summary>
        /// Maps the attribute-defined routes for the application.
        /// </summary>
        /// <param name="routes"></param>
        /// <param name="constraintResolver">
        /// The <see cref="IInlineConstraintResolver"/> to use for resolving inline constraints in route templates.
        /// </param>
        public static void MapMvcAttributeRoutes(this RouteCollection routes,
            IInlineConstraintResolver constraintResolver)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }

            if (constraintResolver == null)
            {
                throw new ArgumentNullException("constraintResolver");
            }

            AttributeRoutingMapper.MapAttributeRoutes(routes, constraintResolver);
        }
    }
}
