using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Dragon;

namespace Oddity.API.Builders.Dragons
{
    /// <summary>
    /// Represents a set of methods to filter Dragon type information and download them from API.
    /// </summary>
    public class DragonBuilder : BuilderBase<DragonInfo>
    {
        private DraognId? _capsuleType;
        private const string DragonsEndpoint = "dragons";

        /// <summary>
        /// Initializes a new instance of the <see cref="DragonBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public DragonBuilder(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer) : base(httpClient, builderDelegatesContainer)
        {

        }

        /// <summary>
        /// Filters Dragon type information by the specified capsule type. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or
        /// <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to get result from the API. Every next call of this method will override previously saved capsule type filter.
        /// </summary>
        /// <param name="type">The capsule type (Dragon1, Dragon2, etc).</param>
        /// <returns>The capsule information.</returns>
        public DragonBuilder WithType(DraognId type)
        {
            _capsuleType = type;
            return this;
        }

        /// <inheritdoc />
        protected override async Task<DragonInfo> ExecuteBuilder()
        {
            var link = BuildLink(DragonsEndpoint);
            if (_capsuleType.HasValue)
            {
                link += $"/{_capsuleType.ToString().ToLower()}";
            }

            return await SendRequestToApi(link).ConfigureAwait(false);
        }
    }
}
