using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Capsule;

namespace Oddity.API.Builders.Capsules
{
    /// <summary>
    /// Represents a set of methods to filter all capsules information and download them from API.
    /// </summary>
    public class AllCapsulesBuilder : BuilderBase<List<CapsuleInfo>>
    {
        private const string CapsuleInfoEndpoint = "capsules";

        /// <summary>
        /// Initializes a new instance of the <see cref="AllCapsulesBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="deserializationError">The deserialization error delegate.</param>
        public AllCapsulesBuilder(HttpClient httpClient, DeserializationError deserializationError) : base(httpClient, deserializationError)
        {

        }

        /// <inheritdoc />
        protected override async Task<List<CapsuleInfo>> ExecuteBuilder()
        {
            var link = BuildLink(CapsuleInfoEndpoint);
            return await SendRequestToApi(link);
        }
    }
}
