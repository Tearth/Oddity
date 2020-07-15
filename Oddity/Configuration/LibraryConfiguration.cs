namespace Oddity.Configuration
{
    /// <summary>
    /// Contains a set of constant parameters with library configuration.
    /// </summary>
    public class LibraryConfiguration
    {
        public const string LibraryName = "Oddity";
        public const string GitHubLink = "https://github.com/Tearth/Oddity";

        public const int LowPriorityCacheLifetime = 60 * 60 * 24;
        public const int MediumPriorityCacheLifetime = 60 * 5;
        public const int HighPriorityCacheLifetime = 20;
    }
}
