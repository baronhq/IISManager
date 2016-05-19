﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Web.Http;
using Microsoft.OData.Edm;

namespace System.Web.OData.Routing
{
    /// <summary>
    /// An <see cref="ODataPathSegment"/> implementation representing an indexing into an entity collection by key.
    /// </summary>
    public class KeyValuePathSegment : ODataPathSegment
    {
        private IDictionary<string, string> _values;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyValuePathSegment" /> class.
        /// </summary>
        /// <param name="value">The key value to use for indexing into the collection.</param>
        public KeyValuePathSegment(string value)
        {
            if (value == null)
            {
                throw Error.ArgumentNull("value");
            }

            Value = value;
        }

        /// <summary>
        /// The raw text of the path segment and the source of the Values collection.
        /// </summary>
        public string Value
        {
            get;
            private set;
        }

        internal IDictionary<string, string> Values
        {
            get
            {
                if (_values == null)
                {
                    _values = KeyValueParser.ParseKeys(Value);
                }

                return _values;
            }
        }

        /// <summary>
        /// Gets the segment kind for the current segment.
        /// </summary>
        public override string SegmentKind
        {
            get
            {
                return ODataSegmentKinds.Key;
            }
        }

        /// <summary>
        /// Gets the EDM type for this segment.
        /// </summary>
        /// <param name="previousEdmType">The EDM type of the previous path segment.</param>
        /// <returns>
        /// The EDM type for this segment.
        /// </returns>
        public override IEdmType GetEdmType(IEdmType previousEdmType)
        {
            IEdmCollectionType previousCollectionType = previousEdmType as IEdmCollectionType;
            if (previousCollectionType != null)
            {
                return previousCollectionType.ElementType.Definition;
            }
            return null;
        }

        /// <summary>
        /// Gets the entity set for this segment.
        /// </summary>
        /// <param name="previousEntitySet">The entity set of the previous path segment.</param>
        /// <returns>
        /// The entity set for this segment.
        /// </returns>
        public override IEdmEntitySet GetEntitySet(IEdmEntitySet previousEntitySet)
        {
            return previousEntitySet;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Value;
        }

        /// <inheritdoc/>
        public override bool TryMatch(ODataPathSegment pathSegment, IDictionary<string, object> values)
        {
            return pathSegment.SegmentKind == ODataSegmentKinds.Key;
        }
    }
}
