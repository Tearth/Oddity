using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Builders.Cores;

namespace Oddity.API
{
    /// <summary>
    /// Represents a set of methods to get cores information.
    /// </summary>
    public class Cores
    {
        private readonly HttpClient _httpClient;
        private readonly BuilderDelegatesContainer _builderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cores"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public Cores(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            _httpClient = httpClient;
            _builderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Gets information about the specified capsule. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <param name="coreSerial">The core serial.</param>
        /// <returns>The capsule builder.</returns>
        public CoreBuilder GetAbout(string coreSerial)
        {
            return new CoreBuilder(_httpClient, _builderDelegatesContainer).WithSerial(coreSerial);
        }

        /// <summary>
        /// Gets detailed information about all cores. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all core builder.</returns>
        public AllCoresBuilder GetAll()
        {
            return new AllCoresBuilder(_httpClient, _builderDelegatesContainer);
        }
    }
}
