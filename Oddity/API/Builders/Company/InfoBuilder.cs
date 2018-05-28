using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Exceptions;
using Oddity.API.Models.Company;

namespace Oddity.API.Builders.Company
{
    /// <summary>
    /// Represents a set of methods to filter company information and download them from API.
    /// </summary>
    public class InfoBuilder : BuilderBase<CompanyInfo>
    {
        private const string CompanyInfoEndpoint = "info";

        /// <summary>
        /// Initializes a new instance of the <see cref="InfoBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="deserializationError">The deserialization error delegate.</param>
        public InfoBuilder(HttpClient httpClient, DeserializationError deserializationError) : base(httpClient, deserializationError)
        {

        }

        /// <inheritdoc />
        public override CompanyInfo Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <inheritdoc />
        public override async Task<CompanyInfo> ExecuteAsync()
        {
            var link = BuildLink(CompanyInfoEndpoint);
            return await RequestForObject(link);
        }
    }
}
