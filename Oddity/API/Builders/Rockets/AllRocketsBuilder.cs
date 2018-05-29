using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Rocket;

namespace Oddity.API.Builders.Rocket
{
    /// <summary>
    /// Represents a set of methods to filter all rockets information and download them from API.
    /// </summary>
    public class AllRocketsBuilder : BuilderBase<List<RocketInfo>>
    {
        private const string RocketInfoEndpoint = "rockets";

        /// <summary>
        /// Initializes a new instance of the <see cref="AllRocketsBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="deserializationError">The deserialization error delegate.</param>
        public AllRocketsBuilder(HttpClient httpClient, DeserializationError deserializationError) : base(httpClient, deserializationError)
        {

        }

        /// <inheritdoc />
        public override List<RocketInfo> Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <inheritdoc />
        public override async Task<List<RocketInfo>> ExecuteAsync()
        {
            var link = BuildLink(RocketInfoEndpoint);
            return await RequestForObject(link);
        }
    }
}
