using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Events;
using Oddity.API.Models.Ships;

namespace Oddity.API.Endpoints
{
    /// <summary>
    /// Represents an entry point for /ships endpoint.
    /// </summary>
    public class ShipsEndpoint : EndpointBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipsEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public ShipsEndpoint(HttpClient httpClient, OddityCore context, BuilderDelegatesContainer builderDelegatesContainer)
            : base(httpClient, context, builderDelegatesContainer)
        {

        }

        /// <summary>
        /// Gets data about the specified ship from the /ships/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified ship.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<ShipInfo> Get(string id)
        {
            return new SimpleBuilder<ShipInfo>(HttpClient, "ships", id, Context, BuilderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about all ships from the /ships endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<ShipInfo> GetAll()
        {
            return new ListBuilder<ShipInfo>(HttpClient, "ships", Context, BuilderDelegatesContainer);
        }
    }
}