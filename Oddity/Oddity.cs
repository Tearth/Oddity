using System.Net.Http;
using Oddity.API;

namespace Oddity
{
    /// <summary>
    /// Represents an core of the library. Use it to retrieve data from the SpaceX API.
    /// </summary>
    public class Oddity
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

            Company = new Company(_httpClient);
            Rocket = new Rocket(_httpClient);
            Capsule = new Capsule(_httpClient);
            Launchpad = new Launchpad(_httpClient);
            Launches = new Launches(_httpClient);
        }
    }
}
