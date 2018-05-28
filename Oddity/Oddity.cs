using System;
using System.Net.Http;
using Newtonsoft.Json.Serialization;
using Oddity.API;

namespace Oddity
{
    public delegate void DeserializationError(ErrorEventArgs args);

    /// <summary>
    /// Represents an core of the library. Use it to retrieve data from the SpaceX API.
    /// </summary>
    public class Oddity : IDisposable
    {
        /// <summary>
        /// Gets the company information.
        /// </summary>
        public Company Company { get; }

        /// <summary>
        /// Gets the rockets information.
        /// </summary>
        public Rocket Rocket { get; }

        /// <summary>
        /// Gets the capsules information.
        /// </summary>
        public Capsule Capsule { get; }

        /// <summary>
        /// Gets the detailed capsules information.
        /// </summary>
        public DetailedCapsules DetailedCapsules { get; }

        /// <summary>
        /// Gets the launchpads information.
        /// </summary>
        public Launchpad Launchpad { get; }

        /// <summary>
        /// Gets the launches information.
        /// </summary>
        public Launches Launches { get; }

        /// <summary>
        /// Event triggered when an error occured during JSON deserialization.
        /// </summary>
        public event EventHandler<ErrorEventArgs> OnDeserializationError;

        private HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="Oddity"/> class.
        /// </summary>
        public Oddity()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ApiConfiguration.ApiEndpoint);
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Oddity/1.0 (https://github.com/Tearth/Oddity)");

            SetTimeout(ApiConfiguration.DefaultTimeoutSeconds);

            Company = new Company(_httpClient, DeserializationError);
            Rocket = new Rocket(_httpClient, DeserializationError);
            Capsule = new Capsule(_httpClient, DeserializationError);
            DetailedCapsules = new DetailedCapsules(_httpClient, DeserializationError);
            Launchpad = new Launchpad(_httpClient, DeserializationError);
            Launches = new Launches(_httpClient, DeserializationError);
        }

        /// <summary>
        /// Sets the timeout for all API requests.
        /// </summary>
        /// <param name="timeoutSeconds">Timeout in seconds.</param>
        public void SetTimeout(int timeoutSeconds)
        {
            _httpClient.Timeout = new TimeSpan(0, 0, 0, timeoutSeconds);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        private void DeserializationError(ErrorEventArgs args)
        {
            OnDeserializationError(this, args);
        }
    }
}
