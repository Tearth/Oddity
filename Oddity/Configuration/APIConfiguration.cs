namespace Oddity.Configuration
{
    /// <summary>
    /// Contains a set of constant parameters with API configuration.
    /// </summary>
    public class ApiConfiguration
    {
        /// <summary>
        /// Entry point of the API, used as base for all HTTP requests.
        /// </summary>
        public const string ApiEndpoint = "https://api.spacexdata.com/v4/";

        /// <summary>
        /// Default time after which timeout exception will be thrown.
        /// </summary>
        public const int DefaultTimeoutSeconds = 5;
    }
}
