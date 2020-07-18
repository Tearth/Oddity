using System;
using System.Net.Http;
using System.Reflection;
using Newtonsoft.Json.Serialization;
using Oddity.Configuration;
using Oddity.Endpoints;
using Oddity.Events;
using Oddity.Models.Capsules;
using Oddity.Models.Company;
using Oddity.Models.Cores;
using Oddity.Models.Crew;
using Oddity.Models.Landpads;
using Oddity.Models.Launches;
using Oddity.Models.Launchpads;
using Oddity.Models.Payloads;
using Oddity.Models.Roadster;
using Oddity.Models.Rockets;
using Oddity.Models.Ships;
using Oddity.Models.Starlink;

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
        public CapsulesEndpoint<CapsuleInfo> CapsulesEndpoint { get; }

        /// <summary>
        /// Entry point of the /company endpoint.
        /// </summary>
        public CompanyEndpoint<CompanyInfo> CompanyEndpoint { get; }

        /// <summary>
        /// Entry point of the /cores endpoint.
        /// </summary>
        public CoresEndpoint<CoreInfo> CoresEndpoint { get; }

        /// <summary>
        /// Entry point of the /crew endpoint.
        /// </summary>
        public CrewEndpoint<CrewInfo> CrewEndpoint { get; }

        /// <summary>
        /// Entry point of the /landpads endpoint.
        /// </summary>
        public LandpadsEndpoint<LandpadInfo> LandpadsEndpoint { get; }

        /// <summary>
        /// Entry point of the /launches endpoint.
        /// </summary>
        public LaunchesEndpoint<LaunchInfo> LaunchesEndpoint { get; }

        /// <summary>
        /// Entry point of the /launchpads endpoint.
        /// </summary>
        public LaunchpadsEndpoint<LaunchpadInfo> LaunchpadsEndpoint { get; }

        /// <summary>
        /// Entry point of the /payloads endpoint.
        /// </summary>
        public PayloadsEndpoint<PayloadInfo> PayloadsEndpoint { get; }

        /// <summary>
        /// Entry point of the /roadster endpoint.
        /// </summary>
        public RoadsterEndpoint<RoadsterInfo> RoadsterEndpoint { get; }

        /// <summary>
        /// Entry point of the /rockets endpoint.
        /// </summary>
        public RocketsEndpoint<RocketInfo> RocketsEndpoint { get; }

        /// <summary>
        /// Entry point of the /ships endpoint.
        /// </summary>
        public ShipsEndpoint<ShipInfo> ShipsEndpoint { get; }

        /// <summary>
        /// Entry point of the /starlink endpoint.
        /// </summary>
        public StarlinkEndpoint<StarlinkInfo> StarlinkEndpoint { get; }

        public TimeSpan Timeout
        {
            get => HttpClient.Timeout;
            set => HttpClient.Timeout = value;
        }

        public string UserAgent => $"{LibraryConfiguration.LibraryName}/{Version} ({LibraryConfiguration.GitHubLink})";

        public string Version => GetType().GetTypeInfo()
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            .InformationalVersion;

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

        protected internal readonly HttpClient HttpClient;
        protected internal readonly BuilderDelegates BuilderDelegates;

        /// <summary>
        /// Initializes a new instance of the <see cref="OddityCore"/> class.
        /// </summary>
        public OddityCore(bool cacheEnabled = true)
        {
            CacheEnabled = cacheEnabled;

            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri(ApiConfiguration.ApiEndpoint);
            HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);

            Timeout = new TimeSpan(0, 0, ApiConfiguration.DefaultTimeoutSeconds);

            BuilderDelegates = new BuilderDelegates
            {
                DeserializationError = DeserializationError,
                RequestSend = RequestSend,
                ResponseReceived = ResponseReceived
            };

            CapsulesEndpoint = new CapsulesEndpoint<CapsuleInfo>(this);
            CompanyEndpoint = new CompanyEndpoint<CompanyInfo>(this);
            CoresEndpoint = new CoresEndpoint<CoreInfo>(this);
            CrewEndpoint = new CrewEndpoint<CrewInfo>(this);
            LandpadsEndpoint = new LandpadsEndpoint<LandpadInfo>(this);
            LaunchesEndpoint = new LaunchesEndpoint<LaunchInfo>(this);
            LaunchpadsEndpoint = new LaunchpadsEndpoint<LaunchpadInfo>(this);
            PayloadsEndpoint = new PayloadsEndpoint<PayloadInfo>(this);
            RoadsterEndpoint = new RoadsterEndpoint<RoadsterInfo>(this);
            RocketsEndpoint = new RocketsEndpoint<RocketInfo>(this);
            ShipsEndpoint = new ShipsEndpoint<ShipInfo>(this);
            StarlinkEndpoint = new StarlinkEndpoint<StarlinkInfo>(this);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            HttpClient?.Dispose();
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
