using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Builders.Company;
using Oddity.API.Builders.History;

namespace Oddity.API
{
    /// <summary>
    /// Represents a set of methods to get company information.
    /// </summary>
    public class Company
    {
        private readonly HttpClient _httpClient;
        private readonly BuilderDelegatesContainer _builderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public Company(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            _httpClient = httpClient;
            _builderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Gets information about the company. This method returns only builder which doesn't retrieve data from API itself,
        /// you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to get the data from SpaceX API.
        /// </summary>
        /// <returns>The company information builder.</returns>
        public InfoBuilder GetInfo()
        {
            return new InfoBuilder(_httpClient, _builderDelegatesContainer);
        }

        /// <summary>
        /// Gets company history events. This method returns only builder which doesn't retrieve data from API itself,
        /// you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to get the data from SpaceX API.
        /// </summary>
        /// <returns>The company history events builder.</returns>
        public HistoryBuilder GetHistory()
        {
            return new HistoryBuilder(_httpClient, _builderDelegatesContainer);
        }
    }
}
