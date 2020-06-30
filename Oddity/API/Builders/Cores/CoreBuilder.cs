using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.DetailedCore;

namespace Oddity.API.Builders.Cores
{
    /// <summary>
    /// Represents a set of methods to filter core information and download them from API.
    /// </summary>
    public class CoreBuilder : BuilderBase<CoreInfo>
    {
        private string _coreSerial;
        private const string CapsuleInfoEndpoint = "cores";

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public CoreBuilder(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer) : base(httpClient, builderDelegatesContainer)
        {

        }

        /// <summary>
        /// Filters capsule information by the specified core serial. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or
        /// <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to get result from the API. Every next call of this method will override previously saved core serial filter.
        /// </summary>
        /// <param name="coreSerial">The capsule serial (C101, C113, etc).</param>
        /// <returns>The capsule information.</returns>
        public CoreBuilder WithSerial(string coreSerial)
        {
            _coreSerial = coreSerial;
            return this;
        }

        /// <inheritdoc />
        protected override async Task<CoreInfo> ExecuteBuilder()
        {
            var link = BuildLink(CapsuleInfoEndpoint);
            if (_coreSerial != null)
            {
                link += $"/{_coreSerial.ToUpper()}";
            }

            return await SendRequestToApi(link).ConfigureAwait(false);
        }
    }
}
