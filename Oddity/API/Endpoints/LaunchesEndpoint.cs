using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Events;
using Oddity.API.Models.Launches;

namespace Oddity.API.Endpoints
{
    /// <summary>
    /// Represents an entry point for /launches endpoint.
    /// </summary>
    public class LaunchesEndpoint : EndpointBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchesEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public LaunchesEndpoint(HttpClient httpClient, OddityCore context, BuilderDelegatesContainer builderDelegatesContainer)
            : base(httpClient, context, builderDelegatesContainer)
        {

        }

        /// <summary>
        /// Gets data about the specified launch from the /launches/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified launch.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<LaunchInfo> Get(string id)
        {
            return new SimpleBuilder<LaunchInfo>(HttpClient, "launches", id, Context, BuilderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about the latest launch from the /launches/latest endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<LaunchInfo> GetLatest()
        {
            return new SimpleBuilder<LaunchInfo>(HttpClient, "launches/latest", Context, BuilderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about the next launch from the /launches/latest endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<LaunchInfo> GetNext()
        {
            return new SimpleBuilder<LaunchInfo>(HttpClient, "launches/next", Context, BuilderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about all launches from the /launches endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<LaunchInfo> GetAll()
        {
            return new ListBuilder<LaunchInfo>(HttpClient, "launches", Context, BuilderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about all past launches from the /launches endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<LaunchInfo> GetPast()
        {
            return new ListBuilder<LaunchInfo>(HttpClient, "launches/past", Context, BuilderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about all upcoming launches from the /launches endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<LaunchInfo> GetUpcoming()
        {
            return new ListBuilder<LaunchInfo>(HttpClient, "launches/upcoming", Context, BuilderDelegatesContainer);
        }

        /// <summary>
        /// Gets filtered and paginated data about all launches from the /launches/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<LaunchInfo> Query()
        {
            return new QueryBuilder<LaunchInfo>(HttpClient, "launches/query", Context, BuilderDelegatesContainer);
        }
    }
}