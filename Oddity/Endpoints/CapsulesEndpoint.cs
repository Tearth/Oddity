using System.Net.Http;
using Oddity.Builders;
using Oddity.Cache;
using Oddity.Configuration;
using Oddity.Events;
using Oddity.Models.Capsules;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point for /capsules endpoint.
    /// </summary>
    public class CapsulesEndpoint : EndpointBase
    {
        private CacheService<CapsuleInfo> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="CapsulesEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public CapsulesEndpoint(HttpClient httpClient, OddityCore context, BuilderDelegates builderDelegates) 
            : base(httpClient, context, builderDelegates)
        {
            _cache = new CacheService<CapsuleInfo>(LibraryConfiguration.MediumPriorityCacheLifetime);
        }

        /// <summary>
        /// Gets data about the specified capsule from the /capsules/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified capsule.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<CapsuleInfo> Get(string id)
        {
            return new SimpleBuilder<CapsuleInfo>(HttpClient, "capsules", id, Context, _cache, BuilderDelegates);
        }

        /// <summary>
        /// Gets data about all capsules from the /capsules endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<CapsuleInfo> GetAll()
        {
            return new ListBuilder<CapsuleInfo>(HttpClient, "capsules", Context, _cache, BuilderDelegates);
        }

        /// <summary>
        /// Gets filtered and paginated data about all capsules from the /capsules/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<CapsuleInfo> Query()
        {
            return new QueryBuilder<CapsuleInfo>(HttpClient, "capsules/query", Context, BuilderDelegates);
        }
    }
}