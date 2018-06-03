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
        private CapsuleId? _capsuleType;
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
        /// Filters capsule information by the specified capsule type. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or
        /// <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to get result from the API. Every next call of this method will override previously saved capsule type filter.
        /// </summary>
        /// <param name="type">The capsule type (Dragon1, Dragon2, etc).</param>
        /// <returns>The capsule information.</returns>
        public CapsuleBuilder WithType(CapsuleId type)
        {
            _capsuleType = type;
            return this;
        }

        /// <inheritdoc />
        protected override async Task<CapsuleInfo> ExecuteBuilder()
        {
            var link = BuildLink(CapsuleInfoEndpoint);
            if (_capsuleType.HasValue)
            {
                link += $"/{_capsuleType.ToString().ToLower()}";
            }

            return await SendRequestToApi(link);
        }
    }
}
