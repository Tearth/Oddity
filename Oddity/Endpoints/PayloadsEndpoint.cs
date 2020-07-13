using System.Net.Http;
using Oddity.Builders;
using Oddity.Events;
using Oddity.Models.Payloads;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point for /payloads endpoint.
    /// </summary>
    public class PayloadsEndpoint : EndpointBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PayloadsEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public PayloadsEndpoint(HttpClient httpClient, OddityCore context, BuilderDelegates builderDelegates)
            : base(httpClient, context, builderDelegates)
        {

        }

        /// <summary>
        /// Gets data about the specified payload from the /payloads/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified payload.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<PayloadInfo> Get(string id)
        {
            return new SimpleBuilder<PayloadInfo>(HttpClient, "payloads", id, Context, builderDelegates);
        }

        /// <summary>
        /// Gets data about all payloads from the /payloads endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<PayloadInfo> GetAll()
        {
            return new ListBuilder<PayloadInfo>(HttpClient, "payloads", Context, builderDelegates);
        }

        /// <summary>
        /// Gets filtered and paginated data about all payloads from the /payloads/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<PayloadInfo> Query()
        {
            return new QueryBuilder<PayloadInfo>(HttpClient, "payloads/query", Context, builderDelegates);
        }
    }
}