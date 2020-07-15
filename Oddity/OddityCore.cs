using System;
using System.Net.Http;
using System.Reflection;
using Newtonsoft.Json.Serialization;
using Oddity.Configuration;
using Oddity.Endpoints;
using Oddity.Events;

namespace Oddity
{
    /// <summary>
    /// Represents an core of the library. Use it to retrieve data from the unofficial SpaceX API.
    /// </summary>
    public class OddityCore : IDisposable
    {
        public bool CacheEnabled { get; set; }

        /// <summary>
        /// Entry point of the /capsules endpoint.
        /// </summary>
        public CapsulesEndpoint CapsulesEndpoint { get; }

        /// <summary>
        /// Entry point of the /company endpoint.
        /// </summary>
        public CompanyEndpoint CompanyEndpoint { get; }

        /// <summary>
        /// Entry point of the /cores endpoint.
        /// </summary>
        public CoresEndpoint CoresEndpoint { get; }

        /// <summary>
        /// Entry point of the /crew endpoint.
        /// </summary>
        public CrewEndpoint CrewEndpoint { get; }

        /// <summary>
        /// Entry point of the /landpads endpoint.
        /// </summary>
        public LandpadsEndpoint LandpadsEndpoint { get; }

        /// <summary>
        /// Entry point of the /launches endpoint.
        /// </summary>
        public LaunchesEndpoint LaunchesEndpoint { get; }

        /// <summary>
        /// Entry point of the /launchpads endpoint.
        /// </summary>
        public LaunchpadsEndpoint LaunchpadsEndpoint { get; }

        /// <summary>
        /// Entry point of the /payloads endpoint.
        /// </summary>
        public PayloadsEndpoint PayloadsEndpoint { get; }

        /// <summary>
        /// Entry point of the /roadster endpoint.
        /// </summary>
        public RoadsterEndpoint RoadsterEndpoint { get; }

        /// <summary>
        /// Entry point of the /rockets endpoint.
        /// </summary>
        public RocketsEndpoint RocketsEndpoint { get; }

        /// <summary>
        /// Entry point of the /ships endpoint.
        /// </summary>
        public ShipsEndpoint ShipsEndpoint { get; }

        /// <summary>
        /// Entry point of the /starlink endpoint.
        /// </summary>
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

        public OddityCore() : this(true)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OddityCore"/> class.
        /// </summary>
        public OddityCore(bool cacheEnabled)
        {
            CacheEnabled = cacheEnabled;

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ApiConfiguration.ApiEndpoint);
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(GetUserAgent());

            SetTimeout(ApiConfiguration.DefaultTimeoutSeconds);

            var builderDelegates = new BuilderDelegates
            {
                DeserializationError = DeserializationError,
                RequestSend = RequestSend,
                ResponseReceived = ResponseReceived
            };

            CapsulesEndpoint = new CapsulesEndpoint(_httpClient, this, builderDelegates);
            CompanyEndpoint = new CompanyEndpoint(_httpClient, this, builderDelegates);
            CoresEndpoint = new CoresEndpoint(_httpClient, this, builderDelegates);
            CrewEndpoint = new CrewEndpoint(_httpClient, this, builderDelegates);
            LandpadsEndpoint = new LandpadsEndpoint(_httpClient, this, builderDelegates);
            LaunchesEndpoint = new LaunchesEndpoint(_httpClient, this, builderDelegates);
            LaunchpadsEndpoint = new LaunchpadsEndpoint(_httpClient, this, builderDelegates);
            PayloadsEndpoint = new PayloadsEndpoint(_httpClient, this, builderDelegates);
            RoadsterEndpoint = new RoadsterEndpoint(_httpClient, this, builderDelegates);
            RocketsEndpoint = new RocketsEndpoint(_httpClient, this, builderDelegates);
            ShipsEndpoint = new ShipsEndpoint(_httpClient, this, builderDelegates);
            StarlinkEndpoint = new StarlinkEndpoint(_httpClient, this, builderDelegates);
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
