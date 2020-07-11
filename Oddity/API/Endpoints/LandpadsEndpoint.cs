using System.Collections.Generic;
using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Events;
using Oddity.API.Models.Crew;
using Oddity.API.Models.Landpads;
using Oddity.API.Models.Payloads;

namespace Oddity.API.Endpoints
{
    /// <summary>
    /// Represents an entry point for /landpads endpoint.
    /// </summary>
    public class LandpadsEndpoint : EndpointBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LandpadsEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public LandpadsEndpoint(HttpClient httpClient, OddityCore context, BuilderDelegatesContainer builderDelegatesContainer)
            : base(httpClient, context, builderDelegatesContainer)
        {

        }

        /// <summary>
        /// Gets data about the specified landpad from the /landpads/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified landpad.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<LandpadInfo> Get(string id)
        {
            return new SimpleBuilder<LandpadInfo>(HttpClient, "landpads", id, Context, BuilderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about all landpads from the /landpads endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<LandpadInfo> GetAll()
        {
            return new ListBuilder<LandpadInfo>(HttpClient, "landpads", Context, BuilderDelegatesContainer);
        }
    }
}