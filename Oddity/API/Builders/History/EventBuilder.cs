using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.History;

namespace Oddity.API.Builders.History
{
    /// <summary>
    /// Represents a set of methods to filter history event and download them from API.
    /// </summary>
    public class EventBuilder : BuilderBase<HistoryEvent>
    {
        private int? _eventId;
        private const string CapsuleInfoEndpoint = "history";

        /// <summary>
        /// Initializes a new instance of the <see cref="EventBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public EventBuilder(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer) : base(httpClient, builderDelegatesContainer)
        {

        }

        /// <summary>
        /// Filters history event information by the specified ID. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or
        /// <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to get result from the API. Every next call of this method will override previously saved capsule serial filter.
        /// </summary>
        /// <param name="eventId">The history event ID.</param>
        /// <returns>The history event information.</returns>
        public EventBuilder WithId(int eventId)
        {
            _eventId = eventId;
            return this;
        }

        /// <inheritdoc />
        protected override async Task<HistoryEvent> ExecuteBuilder()
        {
            var link = BuildLink(CapsuleInfoEndpoint);
            if (_eventId != null)
            {
                link += $"/{_eventId.ToString().ToUpper()}";
            }

            return await SendRequestToApi(link).ConfigureAwait(false);
        }
    }
}
