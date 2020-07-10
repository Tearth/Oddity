using System;
using System.Net.Http;
using System.Reflection;
using Newtonsoft.Json.Serialization;
using Oddity.API.Endpoints;
using Oddity.API.Events;
using Oddity.Configuration;

namespace Oddity
{
    /// <summary>
    /// Represents an core of the library. Use it to retrieve data from the unofficial SpaceX API.
    /// </summary>
    public class OddityCore : IDisposable
    {
        public CrewEndpoint CrewEndpoint { get; }
        public LandpadsEndpoint LandpadsEndpoint { get; }
        public PayloadsEndpoint PayloadsEndpoint { get; }
        public RoadsterEndpoint RoadsterEndpoint { get; }
        public ShipsEndpoint ShipsEndpoint { get; }
        public StarlinkEndpoint StarlinkEndpoint { get; }

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

        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="OddityCore"/> class.
        /// </summary>
        public OddityCore()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ApiConfiguration.ApiEndpoint);
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(GetUserAgent());

            SetTimeout(ApiConfiguration.DefaultTimeoutSeconds);

            var builderDelegatesContainer = new BuilderDelegatesContainer
            {
                DeserializationError = DeserializationError,
                RequestSend = RequestSend,
                ResponseReceived = ResponseReceived
            };

            CrewEndpoint = new CrewEndpoint(_httpClient, builderDelegatesContainer);
            LandpadsEndpoint = new LandpadsEndpoint(_httpClient, builderDelegatesContainer);
            PayloadsEndpoint = new PayloadsEndpoint(_httpClient, builderDelegatesContainer);
            RoadsterEndpoint = new RoadsterEndpoint(_httpClient, builderDelegatesContainer);
            ShipsEndpoint = new ShipsEndpoint(_httpClient, builderDelegatesContainer);
            StarlinkEndpoint = new StarlinkEndpoint(_httpClient, builderDelegatesContainer);
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
        /// Gets the current version of library saved in the assembly metadata.
        /// </summary>
        /// <returns>The library version.</returns>
        public string GetLibraryVersion()
        {
            var assembly = GetType().GetTypeInfo().Assembly;
            return assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        }

        /// <summary>
        /// Gets the user agent that is send in every request to the API.
        /// </summary>
        /// <returns>User agent.</returns>
        public string GetUserAgent()
        {
            return $"{LibraryConfiguration.LibraryName}/{GetLibraryVersion()} ({LibraryConfiguration.GitHubLink})";
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
