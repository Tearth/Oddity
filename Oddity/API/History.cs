using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Builders.History;

namespace Oddity.API
{
    /// <summary>
    /// Represents a set of methods to get company history.
    /// </summary>
    public class History
    {
        private readonly HttpClient _httpClient;
        private readonly BuilderDelegatesContainer _builderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="History"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public History(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            _httpClient = httpClient;
            _builderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Gets company history event. This method returns only builder which doesn't retrieve data from API itself,
        /// you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to get the data from SpaceX API.
        /// </summary>
        /// <returns>The company history events builder.</returns>
        public EventBuilder GetEvent(int eventId)
        {
            return new EventBuilder(_httpClient, _builderDelegatesContainer).WithId(eventId);
        }

        /// <summary>
        /// Gets company history events. This method returns only builder which doesn't retrieve data from API itself,
        /// you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to get the data from SpaceX API.
        /// </summary>
        /// <returns>The company history events builder.</returns>
        public HistoryBuilder GetAll()
        {
            return new HistoryBuilder(_httpClient, _builderDelegatesContainer);
        }
    }
}
