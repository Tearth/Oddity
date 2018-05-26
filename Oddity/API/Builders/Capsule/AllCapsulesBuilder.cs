using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Capsule;

namespace Oddity.API.Builders.Capsule
{
    /// <summary>
    /// Represents a set of methods to filter all capsules information and download them from API.
    /// </summary>
    public class AllCapsulesBuilder : BuilderBase
    {
        private const string CapsuleInfoEndpoint = "capsules";

        /// <summary>
        /// Initializes a new instance of the <see cref="AllCapsulesBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        public AllCapsulesBuilder(HttpClient httpClient) : base(httpClient)
        {

        }

        /// <summary>
        /// Executes all filters and downloads result from API.
        /// </summary>
        /// <returns>The all capsules information.</returns>
        public List<CapsuleInfo> Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <summary>
        /// Executes all filters and downloads result from API asynchronously.
        /// </summary>
        /// <returns>The all capsules information.</returns>
        public async Task<List<CapsuleInfo>> ExecuteAsync()
        {
            var link = BuildLink(CapsuleInfoEndpoint);
            var json = await HttpClient.GetStringAsync(link);

            return JsonConvert.DeserializeObject<List<CapsuleInfo>>(json);
        }
    }
}
