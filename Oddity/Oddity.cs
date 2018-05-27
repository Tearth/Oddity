using System;
using System.Net.Http;
using Oddity.API;

namespace Oddity
{
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
        /// Gets the launchpads information.
        /// </summary>
        public Launchpad Launchpad { get; }

        /// <summary>
        /// Gets the launches information.
        /// </summary>
        public Launches Launches { get; }

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

            Company = new Company(_httpClient);
            Rocket = new Rocket(_httpClient);
            Capsule = new Capsule(_httpClient);
            Launchpad = new Launchpad(_httpClient);
            Launches = new Launches(_httpClient);
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
    }
}
