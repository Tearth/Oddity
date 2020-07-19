namespace Oddity.Configuration
{
    /// <summary>
    /// Contains a set of constant parameters with library configuration.
    /// </summary>
    public class LibraryConfiguration
    {
        /// <summary>
        /// Library name used to generate user agent.
        /// </summary>
        public const string LibraryName = "Oddity";

        /// <summary>
        /// Library's GitHub used to generate user agent.
        /// </summary>
        public const string GitHubLink = "https://github.com/Tearth/Oddity";

        /// <summary>
        /// Lifetime of low-priority cached data (24 hours).
        /// </summary>
        public const int LowPriorityCacheLifetime = 60 * 60 * 24;

        /// <summary>
        /// Lifetime of medium-priority cached data (5 minutes).
        /// </summary>
        public const int MediumPriorityCacheLifetime = 60 * 5;

        /// <summary>
        /// Lifetime of high-priority cached data (20 seconds).
        /// </summary>
        public const int HighPriorityCacheLifetime = 20;
    }
}
