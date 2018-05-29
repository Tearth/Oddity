using System;

namespace Oddity.API.Builders.Launchpads.Exceptions
{
    /// <summary>
    /// The exception that is thrown when user tries to get API data without selected launchpad type.
    /// </summary>
    public class LaunchpadTypeNotSelectedException : Exception
    {
        /// <inheritdoc />
        public LaunchpadTypeNotSelectedException()
        {

        }

        /// <inheritdoc />
        public LaunchpadTypeNotSelectedException(string message) : base(message)
        {

        }

        /// <inheritdoc />
        public LaunchpadTypeNotSelectedException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
