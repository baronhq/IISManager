﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.AspNet.Mvc.Facebook
{
    /// <summary>
    /// Model for the Facebook object connection when it contains a collection.
    /// </summary>
    /// <typeparam name="T">Type of the collection element.</typeparam>
    public class FacebookGroupConnection<T>
    {
        /// <summary>
        /// Gets or sets the connection data.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Needed for JSON deserialization")]
        public IList<T> Data { get; set; }
    }
}