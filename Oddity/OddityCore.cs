using System;
using System.Net.Http;
using System.Reflection;
using Newtonsoft.Json.Serialization;
using Oddity.API;
using Oddity.API.Builders;

namespace Oddity
{
    /// <summary>
    /// Represents an core of the library. Use it to retrieve data from the SpaceX API.
    /// </summary>
    public class OddityCore : IDisposable
    {
        /// <summary>
        /// Gets the API information.
        /// </summary>
        public Api Api { get; }

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
        /// Gets the Tesla Roadster information.
        /// </summary>
        public Roadster Roadster { get; }

        /// <summary>
        /// Event triggered when an error occurred during JSON deserialization.
        /// </summary>
        public event EventHandler<ErrorEventArgs> OnDeserializationError;

        /// <summary>
        /// Event triggered when a request is just before send to the server.
        /// </summary>
        public event EventHandler<RequestSendEventArgs> OnRequestSend;

        /// <summary>
        /// Event triggered when a response has been received.
        /// </summary>
        public event EventHandler<ResponseReceiveEventArgs> OnResponseReceive;

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

            var builderDelegatesContainer = new BuilderDelegatesContainer
            {
                DeserializationError = DeserializationError,
                RequestSend = RequestSend,
                ResponseReceived = ResponseReceived
            };

            Api = new Api(_httpClient, builderDelegatesContainer);
            Company = new Company(_httpClient, builderDelegatesContainer);
            Rockets = new Rockets(_httpClient, builderDelegatesContainer);
            Capsules = new Capsules(_httpClient, builderDelegatesContainer);
            DetailedCapsules = new DetailedCapsules(_httpClient, builderDelegatesContainer);
            DetailedCores = new DetailedCores(_httpClient, builderDelegatesContainer);
            Launchpads = new Launchpads(_httpClient, builderDelegatesContainer);
            Launches = new Launches(_httpClient, builderDelegatesContainer);
            Roadster = new Roadster(_httpClient, builderDelegatesContainer);
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

        private void RequestSend(RequestSendEventArgs args)
        {
            OnRequestSend?.Invoke(this, args);
        }

        private void ResponseReceived(ResponseReceiveEventArgs args)
        {
            OnResponseReceive?.Invoke(this, args);
        }
    }
}
