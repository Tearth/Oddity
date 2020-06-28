using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Dragon;

namespace Oddity.API.Builders.Dragons
{
    /// <summary>
    /// Represents a set of methods to filter all Dragon types information and download them from API.
    /// </summary>
    public class AllDragonsBuilder : BuilderBase<List<DragonInfo>>
    {
        private const string DragonEndpoint = "dragons";

        /// <summary>
        /// Initializes a new instance of the <see cref="AllDragonsBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public AllDragonsBuilder(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer) : base(httpClient, builderDelegatesContainer)
        {

        }

        /// <inheritdoc />
        protected override async Task<List<DragonInfo>> ExecuteBuilder()
        {
            var link = BuildLink(DragonEndpoint);
            return await SendRequestToApi(link).ConfigureAwait(false);
        }
    }
}
