using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Builders.Dragons;
using Oddity.API.Models.Dragon;

namespace Oddity.API
{
    /// <summary>
    /// Represents a set of methods to get Dragon information.
    /// </summary>
    public class Dragons
    {
        private readonly HttpClient _httpClient;
        private readonly BuilderDelegatesContainer _builderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dragons"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public Dragons(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            _httpClient = httpClient;
            _builderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Gets information about the specified Dragon type. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <param name="dragonType">The Dragon type.</param>
        /// <returns>The capsule builder.</returns>
        public DragonBuilder GetAbout(DraognId dragonType)
        {
            return new DragonBuilder(_httpClient, _builderDelegatesContainer).WithType(dragonType);
        }

        /// <summary>
        /// Gets information about all Dragon types. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all capsules builder.</returns>
        public AllDragonsBuilder GetAll()
        {
            return new AllDragonsBuilder(_httpClient, _builderDelegatesContainer);
        }
    }
}
