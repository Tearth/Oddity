using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Capsule;

namespace Oddity.API.Builders.Capsules
{
    /// <summary>
    /// Represents a set of methods to filter capsule information and download them from API.
    /// </summary>
    public class CapsuleBuilder : BuilderBase<CapsuleInfo>
    {
        private string _capsuleSerial;
        private const string CapsuleInfoEndpoint = "capsules";

        /// <summary>
        /// Initializes a new instance of the <see cref="CapsuleBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public CapsuleBuilder(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer) : base(httpClient, builderDelegatesContainer)
        {

        }

        /// <summary>
        /// Filters capsule information by the specified capsule serial. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or
        /// <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to get result from the API. Every next call of this method will override previously saved capsule serial filter.
        /// </summary>
        /// <param name="capsuleSerial">The capsule serial (C101, C102, etc).</param>
        /// <returns>The capsule information.</returns>
        public CapsuleBuilder WithSerial(string capsuleSerial)
        {
            _capsuleSerial = capsuleSerial;
            return this;
        }

        /// <inheritdoc />
        protected override async Task<CapsuleInfo> ExecuteBuilder()
        {
            var link = BuildLink(CapsuleInfoEndpoint);
            if (_capsuleSerial != null)
            {
                link += $"/{_capsuleSerial.ToUpper()}";
            }

            return await SendRequestToApi(link).ConfigureAwait(false);
        }
    }
}
