using System.Net.Http;
using Oddity.Builders;
using Oddity.Cache;
using Oddity.Configuration;
using Oddity.Events;
using Oddity.Models.Company;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point for /company endpoint.
    /// </summary>
    public class CompanyEndpoint : EndpointBase
    {
        private CacheService<CompanyInfo> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public CompanyEndpoint(HttpClient httpClient, OddityCore context, BuilderDelegates builderDelegates)
            : base(httpClient, context, builderDelegates)
        {
            _cache = new CacheService<CompanyInfo>(LibraryConfiguration.LowPriorityCacheLifetime);
        }

        /// <summary>
        /// Gets data about company from the /company endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<CompanyInfo> Get()
        {
            return new SimpleBuilder<CompanyInfo>(HttpClient, "company", Context, _cache, BuilderDelegates);
        }
    }
}