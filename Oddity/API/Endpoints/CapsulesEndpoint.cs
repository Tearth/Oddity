using System.Collections.Generic;
using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Events;
using Oddity.API.Models.Capsules;
using Oddity.API.Models.Cores;

namespace Oddity.API.Endpoints
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
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public CapsulesEndpoint(HttpClient httpClient, OddityCore context, BuilderDelegatesContainer builderDelegatesContainer) 
            : base(httpClient, context, builderDelegatesContainer)
        {

        }

        /// <summary>
        /// Gets data about the specified capsule from the /capsules/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified capsule.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<CapsuleInfo> Get(string id)
        {
            return new SimpleBuilder<CapsuleInfo>(HttpClient, "capsules", id, Context, BuilderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about all capsules from the /capsules endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<CapsuleInfo> GetAll()
        {
            return new ListBuilder<CapsuleInfo>(HttpClient, "capsules", Context, BuilderDelegatesContainer);
        }
    }
}