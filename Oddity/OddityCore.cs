using System;
using System.Net.Http;
using System.Reflection;
using Newtonsoft.Json.Serialization;
using Oddity.API;

namespace Oddity
{
    public delegate void DeserializationError(ErrorEventArgs args);

    /// <summary>
    /// Represents an core of the library. Use it to retrieve data from the SpaceX API.
    /// </summary>
    public class OddityCore : IDisposable
    {
        /// <summary>
        /// Gets the company information.
        /// </summary>
        public Company Company { get; }

        /// <summary>
        /// Gets the rockets information.
        /// </summary>
        public Rockets Rockets { get; }

        /// <summary>
        /// Gets the capsules information.
        /// </summary>
        public Capsules Capsules { get; }

        /// <summary>
        /// Gets the detailed capsules information.
        /// </summary>
        public DetailedCapsules DetailedCapsules { get; }

        /// <summary>
        /// Gets the detailed core information.
        /// </summary>
        public DetailedCores DetailedCores { get; }

        /// <summary>
        /// Gets the launchpads information.
        /// </summary>
        public Launchpads Launchpads { get; }

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
        /// Initializes a new instance of the <see cref="OddityCore"/> class.
        /// </summary>
        public OddityCore()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ApiConfiguration.ApiEndpoint);
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd($"{ApiConfiguration.LibraryName}/{GetVersion()} ({ApiConfiguration.GitHubLink})");

            SetTimeout(ApiConfiguration.DefaultTimeoutSeconds);

            Company = new Company(_httpClient, DeserializationError);
            Rockets = new Rockets(_httpClient, DeserializationError);
            Capsules = new Capsules(_httpClient, DeserializationError);
            DetailedCapsules = new DetailedCapsules(_httpClient, DeserializationError);
            DetailedCores = new DetailedCores(_httpClient, DeserializationError);
            Launchpads = new Launchpads(_httpClient, DeserializationError);
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

        /// <summary>
        /// Gets the current version of library.
        /// </summary>
        /// <returns>The library version.</returns>
        public string GetVersion()
        {
            return GetType().GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        private void DeserializationError(ErrorEventArgs args)
        {
            OnDeserializationError?.Invoke(this, args);
        }
    }
}
