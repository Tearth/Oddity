using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Oddity.API.Events;
using Oddity.API.Exceptions;
using Oddity.API.Models;

namespace Oddity.API.Builders
{
    /// <summary>
    /// Represents an abstract base class for all builders.
    /// </summary>
    /// <typeparam name="TReturn">Type which will be returned after successful API request.</typeparam>
    public abstract class BuilderBase<TReturn>
    {
        protected readonly HttpClient HttpClient;
        protected readonly BuilderDelegatesContainer BuilderDelegatesContainer;

        protected BuilderBase(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            HttpClient = httpClient;
            BuilderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Performs a request to the API and returns deserialized JSON.
        /// </summary>
        /// <returns>The all capsules information or null/empty list if object is not available.</returns>
        /// <exception cref="ApiUnavailableException">Thrown when SpaceX API is unavailable.</exception>
        public abstract TReturn Execute();

        /// <summary>
        /// Performs an async request to the API and returns deserialized JSON.
        /// </summary>
        /// <returns>The all capsules information or null/empty list if object is not available.</returns>
        /// <exception cref="ApiUnavailableException">Thrown when SpaceX API is unavailable.</exception>
        public abstract Task<TReturn> ExecuteAsync();

        protected async Task<string> GetResponseFromEndpoint(string link)
        {
            BuilderDelegatesContainer.RequestSend(new RequestSendEventArgs(link));

            var response = await HttpClient.GetAsync(link).ConfigureAwait(false);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return default;
                }

                throw new ApiUnavailableException($"Status code: {(int)response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var eventArgs = new ResponseReceiveEventArgs(content, response.StatusCode, response.ReasonPhrase);

            BuilderDelegatesContainer.ResponseReceived(eventArgs);

            return content;
        }

        protected TReturn DeserializeJson(string content)
        {
            var deserializationSettings = new JsonSerializerSettings
            {
                Error = JsonDeserializationError,
#if DEBUG
                CheckAdditionalContent = true,
                MissingMemberHandling = MissingMemberHandling.Error
#endif
            };

            return JsonConvert.DeserializeObject<TReturn>(content, deserializationSettings);
        }

        private void JsonDeserializationError(object sender, ErrorEventArgs errorEventArgs)
        {
            BuilderDelegatesContainer.DeserializationError(errorEventArgs);
        }
    }
}
