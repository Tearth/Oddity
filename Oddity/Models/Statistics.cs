namespace Oddity.Models
{
    /// <summary>
    /// Represents an container for statistics.
    /// </summary>
    public class Statistics
    {
        /// <summary>
        /// Gets or sets the number of made requests.
        /// </summary>
        public uint RequestsMade { get; set; }

        /// <summary>
        /// Gets or sets the number of received responses.
        /// </summary>
        public uint ResponsesReceived { get; set; }

        /// <summary>
        /// Gets or sets the number of cache updates.
        /// </summary>
        public uint CacheUpdates { get; set; }

        /// <summary>
        /// Gets or sets the number of cache hits.
        /// </summary>
        public uint CacheHits { get; set; }
    }
}
