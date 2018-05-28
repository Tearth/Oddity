using System.Net.Http;
using Oddity.API.Builders.Company;

namespace Oddity.API
{
    /// <summary>
    /// Represents a set of methods to get company information.
    /// </summary>
    public class Company
    {
        private HttpClient _httpClient;
        private DeserializationError _deserializationError;

        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="deserializationError">The deserialization error delegate.</param>
        public Company(HttpClient httpClient, DeserializationError deserializationError)
        {
            _httpClient = httpClient;
            _deserializationError = deserializationError;
        }

        /// <summary>
        /// Gets information about the company. This method returns only builder which doesn't retrieve data from API itself,
        /// you should call <see cref="InfoBuilder.Execute"/> or <see cref="InfoBuilder.ExecuteAsync"/> to get the data from SpaceX API.
        /// </summary>
        /// <returns>The company information builder.</returns>
        public InfoBuilder GetInfo()
        {
            return new InfoBuilder(_httpClient, _deserializationError);
        }

        /// <summary>
        /// Gets company history events. This method returns only builder which doesn't retrieve data from API itself,
        /// you should call <see cref="HistoryBuilder.Execute"/> or <see cref="HistoryBuilder.ExecuteAsync"/> to get the data from SpaceX API.
        /// </summary>
        /// <returns>The company history events builder.</returns>
        public HistoryBuilder GetHistory()
        {
            return new HistoryBuilder(_httpClient, _deserializationError);
        }
    }
}
