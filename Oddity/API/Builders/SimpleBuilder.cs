using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Exceptions;

namespace Oddity.API.Builders
{
    public class SimpleBuilder<TReturn> : BuilderBase<TReturn>
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleBuilder{TReturn}"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="endpoint">The endpoint used in this instance to retrieve data from API.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public SimpleBuilder(HttpClient httpClient, string endpoint, BuilderDelegatesContainer builderDelegates) : base(builderDelegates)
        {
            _httpClient = httpClient;
            _endpoint = endpoint;
        }

        /// <inheritDoc />
        public override TReturn Execute()
        {
            return ExecuteAsync().GetAwaiter().GetResult();
        }

        /// <inheritDoc />
        public override async Task<TReturn> ExecuteAsync()
        {
            BuilderDelegatesContainer.RequestSend(new RequestSendEventArgs(_httpClient.BaseAddress + _endpoint));

            var response = await _httpClient.GetAsync(_endpoint).ConfigureAwait(false);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return default;
                }

                throw new APIUnavailableException($"Status code: {(int)response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var eventArgs = new ResponseReceiveEventArgs(content, response.StatusCode, response.ReasonPhrase);
            BuilderDelegatesContainer.ResponseReceived(eventArgs);

            return DeserializeJson(content);
        }
    }
}
