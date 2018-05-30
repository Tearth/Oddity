using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Oddity.API.Exceptions;

namespace Oddity.API.Builders
{
    /// <summary>
    /// Represents an abstract base class for all builders.
    /// </summary>
    public abstract class BuilderBase<TReturn>
    {
        /// <summary>
        /// Gets or sets the http client which sends requests to the SpaceX API.
        /// </summary>
        protected HttpClient HttpClient { get; }

        private DeserializationError _deserializationError;
        private Dictionary<string, string> _filters;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuilderBase{TReturn}"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="deserializationError">The deserialization error delegate.</param>
        protected BuilderBase(HttpClient httpClient, DeserializationError deserializationError)
        {
            HttpClient = httpClient;

            _deserializationError = deserializationError;
            _filters = new Dictionary<string, string>();
        }

        /// <summary>
        /// Executes all filters and downloads result from API. If object with the specified filters is not available,
        /// returns null or empty list (depends on which data is requested).
        /// </summary>
        /// <returns>The all capsules information or null/empty list if object is not available.</returns>
        /// <exception cref="APIUnavailableException">Thrown when SpaceX API is unavailable.</exception>
        public abstract TReturn Execute();

        /// <summary>
        /// Executes all filters and downloads result from API asynchronously. If object with the specified filters is not available,
        /// returns null or empty list (depends on which data is requested).
        /// </summary>
        /// <returns>The all capsules information or null/empty list if object is not available.</returns>
        /// <exception cref="APIUnavailableException">Thrown when SpaceX API is unavailable.</exception>
        public abstract Task<TReturn> ExecuteAsync();

        /// <summary>
        /// Adds or overrides filter with the specified name and integer value.
        /// </summary>
        /// <param name="name">The filter name.</param>
        /// <param name="value">The filter integer value.</param>
        protected void AddFilter(string name, int value)
        {
            _filters[name] = value.ToString();
        }

        /// <summary>
        /// Adds or overrides filter with the specified name and string value.
        /// </summary>
        /// <param name="name">The filter name.</param>
        /// <param name="value">The filter string value.</param>
        protected void AddFilter(string name, string value)
        {
            _filters[name] = value;
        }

        /// <summary>
        /// Adds or overrides filter with the specified name and boolean value.
        /// </summary>
        /// <param name="name">The filter name.</param>
        /// <param name="value">The filter boolean value.</param>
        protected void AddFilter(string name, bool value)
        {
            _filters[name] = value.ToString().ToLower();
        }

        /// <summary>
        /// Adds or overrides filter with the specified name and DateTime value.
        /// </summary>
        /// <param name="name">The filter name.</param>
        /// <param name="value">The filter DateTime value.</param>
        /// <param name="formatType">Short (only date) and long (date and time).</param>
        protected void AddFilter(string name, DateTime value, DateFormatType formatType)
        {
            switch (formatType)
            {
                case DateFormatType.Short:
                {
                    _filters[name] = value.ToString("yyyy-MM-dd");
                    break;
                }

                case DateFormatType.Long:
                {
                    _filters[name] = value.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
                    break;
                }
            }
        }

        /// <summary>
        /// Build an link to the API with the specified endpoint and applied filters.
        /// </summary>
        /// <param name="endpoint">The API endpoint.</param>
        /// <returns>The link to the API ready to call.</returns>
        protected string BuildLink(string endpoint)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(endpoint);

            var filters = SerializeFilters();
            if (!string.IsNullOrEmpty(filters))
            {
                stringBuilder.Append("?");
                stringBuilder.Append(filters);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Sends an request to the SpaceX API with the specified link.
        /// </summary>
        /// <param name="link">The request link.</param>
        /// <returns>The deserialized object returned from API.</returns>
        /// <exception cref="APIUnavailableException">Thrown when SpaceX is unavailable and data can't be retrieved.</exception>
        protected async Task<TReturn> RequestForObject(string link)
        {
            var response = await HttpClient.GetAsync(link);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return default(TReturn);
                }

                throw new APIUnavailableException($"Status code: {(int)response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var deserializationSettings = new JsonSerializerSettings {Error = JsonDeserializationError};

            return JsonConvert.DeserializeObject<TReturn>(content, deserializationSettings);
        }

        private void JsonDeserializationError(object sender, ErrorEventArgs errorEventArgs)
        {
            _deserializationError(errorEventArgs);
        }

        private string SerializeFilters()
        {
            var stringBuilder = new StringBuilder();
            var first = true;

            foreach (var filter in _filters)
            {
                if (!first)
                {
                    stringBuilder.Append("&");
                }

                stringBuilder.Append($"{filter.Key}={filter.Value}");
                first = false;
            }

            return stringBuilder.ToString();
        }
    }
}
