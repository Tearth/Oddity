using System.Net.Http;
using Oddity.Builders;
using Oddity.Events;
using Oddity.Models.Capsules;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents an entry point for /capsules endpoint.
    /// </summary>
    public class CapsulesEndpoint : EndpointBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CapsulesEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public CapsulesEndpoint(HttpClient httpClient, OddityCore context, BuilderDelegates builderDelegates) 
            : base(httpClient, context, builderDelegates)
        {

        }

        /// <summary>
        /// Gets data about the specified capsule from the /capsules/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified capsule.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<CapsuleInfo> Get(string id)
        {
            return new SimpleBuilder<CapsuleInfo>(HttpClient, "capsules", id, Context, builderDelegates);
        }

        /// <summary>
        /// Gets data about all capsules from the /capsules endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<CapsuleInfo> GetAll()
        {
            return new ListBuilder<CapsuleInfo>(HttpClient, "capsules", Context, builderDelegates);
        }

        /// <summary>
        /// Gets filtered and paginated data about all capsules from the /capsules/query endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public QueryBuilder<CapsuleInfo> Query()
        {
            return new QueryBuilder<CapsuleInfo>(HttpClient, "capsules/query", Context, builderDelegates);
        }
    }
}