﻿using Oddity.Builders;
using Oddity.Configuration;
using Oddity.Models;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point for /payloads endpoint.
    /// </summary>
    public class PayloadsEndpoint<T> : EndpointBase<T> where T : ModelBase, IIdentifiable, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PayloadsEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public PayloadsEndpoint(OddityCore context)
            : base(context, LibraryConfiguration.MediumPriorityCacheLifetime)
        {

        }

        /// <summary>
        /// Gets data about the specified payload from the /payloads/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified payload.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<T> Get(string id)
        {
            return new SimpleBuilder<T>(Context, Cache, "payloads", id);
        }

        /// <summary>
        /// Gets data about all payloads from the /payloads endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<T> GetAll()
        {
            return new ListBuilder<T>(Context, Cache, "payloads");
        }

        /// <summary>
        /// Gets filtered and paginated data about all payloads from the /payloads/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<T> Query()
        {
            return new QueryBuilder<T>(Context, Cache, "payloads/query");
        }
    }
}