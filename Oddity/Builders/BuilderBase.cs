using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Oddity.Events;
using Oddity.Exceptions;
using Oddity.Models.Query;

namespace Oddity.Builders
{
    /// <summary>
    /// Represents an abstract base class for all builders.
    /// </summary>
    /// <typeparam name="TReturn">Type which will be returned after successful API request.</typeparam>
    public abstract class BuilderBase<TReturn>
    {
        protected readonly HttpClient HttpClient;
        protected readonly BuilderDelegates builderDelegates;

        private JsonSerializerSettings _serializationSettings;

        protected BuilderBase(HttpClient httpClient, BuilderDelegates builderDelegates)
        {
            HttpClient = httpClient;
            builderDelegates = builderDelegates;

            _serializationSettings = new JsonSerializerSettings
            {
                Error = JsonDeserializationError,
#if DEBUG
                CheckAdditionalContent = true,
                MissingMemberHandling = MissingMemberHandling.Error
#endif
            };
        }

        /// <summary>
        /// Performs a request to the API and returns deserialized JSON.
        /// </summary>
        /// <returns>The all capsules information or null/empty list if object is not available.</returns>
        /// <exception cref="ApiUnavailableException">Thrown when SpaceX API is unavailable.</exception>
        public abstract TReturn Execute();

        public abstract void Execute(TReturn model);

        /// <summary>
        /// Performs an async request to the API and returns deserialized JSON.
        /// </summary>
        /// <returns>The all capsules information or null/empty list if object is not available.</returns>
        /// <exception cref="ApiUnavailableException">Thrown when SpaceX API is unavailable.</exception>
        public abstract Task<TReturn> ExecuteAsync();

        public abstract Task ExecuteAsync(TReturn model);

        protected async Task<string> GetResponseFromEndpoint(string link)
        {
            builderDelegates.RequestSend(new RequestSendEventArgs(link));

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

            builderDelegates.ResponseReceived(eventArgs);

            return content;
        }

        protected async Task<string> GetResponseFromEndpoint(string link, QueryModel query)
        {
            var serializedQuery = JsonConvert.SerializeObject(query);
            var httpContent = new StringContent(serializedQuery, Encoding.UTF8, "application/json");

            builderDelegates.RequestSend(new RequestSendEventArgs(link, serializedQuery));

            var response = await HttpClient.PostAsync(link, httpContent).ConfigureAwait(false);
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

            builderDelegates.ResponseReceived(eventArgs);

            return content;
        }

        protected TReturn DeserializeJson(string content)
        {
            return JsonConvert.DeserializeObject<TReturn>(content, _serializationSettings);
        }

        protected void DeserializeJson(string content, TReturn model)
        {
            JsonConvert.PopulateObject(content, model, _serializationSettings);
        }

        private void JsonDeserializationError(object sender, ErrorEventArgs errorEventArgs)
        {
            builderDelegates.DeserializationError(errorEventArgs);
        }
    }
}
