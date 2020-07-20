using System;

namespace Oddity.Exceptions
{
    /// <summary>
    /// The exception that is thrown when SpaceX API is unavailable and data can't be loaded.
    /// </summary>
    public class ApiUnavailableException : Exception
    {
        /// <inheritdoc />
        public ApiUnavailableException()
        {

        }

        /// <inheritdoc />
        public ApiUnavailableException(string message) : base(message)
        {

        }

        /// <inheritdoc />
        public ApiUnavailableException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
