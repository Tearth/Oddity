using System;

namespace Oddity.API.Builders.Rockets.Exceptions
{
    /// <summary>
    /// The exception that is thrown when user tries to get API data without selected rocket type.
    /// </summary>
    public class RocketTypeNotSelectedException : Exception
    {
        /// <inheritdoc />
        public RocketTypeNotSelectedException()
        {

        }

        /// <inheritdoc />
        public RocketTypeNotSelectedException(string message) : base(message)
        {

        }

        /// <inheritdoc />
        public RocketTypeNotSelectedException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
