﻿using System.Collections.Generic;
using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Events;
using Oddity.API.Models.Starlink;

namespace Oddity.API.Endpoints
{
    /// <summary>
    /// Represents an entry point for /starlink endpoint.
    /// </summary>
    public class StarlinkEndpoint : EndpointBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StarlinkEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public StarlinkEndpoint(HttpClient httpClient, OddityCore context, BuilderDelegatesContainer builderDelegatesContainer)
            : base(httpClient, context, builderDelegatesContainer)
        {

        }

        /// <summary>
        /// Gets data about the specified Starlink satellite from the /starlink/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified Starlink satellite.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<StarlinkInfo> Get(string id)
        {
            return new SimpleBuilder<StarlinkInfo>(HttpClient, "starlink", id, Context, BuilderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about all Starlink satellites from the /starlink endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<StarlinkInfo> GetAll()
        {
            return new ListBuilder<StarlinkInfo>(HttpClient, "starlink", Context, BuilderDelegatesContainer);
        }
    }
}