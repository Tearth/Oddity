using System;

namespace Oddity.API.Exceptions
{
    /// <summary>
    /// The exception that is thrown when SpaceX API is unavailable and data can't be loaded.
    /// </summary>
    public class APIUnavailableException : Exception
    {
        /// <inheritdoc />
        public APIUnavailableException()
        {

        }

        /// <inheritdoc />
        public APIUnavailableException(string message) : base(message)
        {

        }

        /// <inheritdoc />
        public APIUnavailableException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
