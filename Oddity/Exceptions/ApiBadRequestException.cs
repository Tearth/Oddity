using System;

namespace Oddity.Exceptions
{
    /// <summary>
    /// The exception that is thrown when SpaceX API has received invalid request which cannot be processed.
    /// </summary>
    public class ApiBadRequestException : Exception
    {
        /// <inheritdoc />
        public ApiBadRequestException()
        {

        }

        /// <inheritdoc />
        public ApiBadRequestException(string message) : base(message)
        {

        }

        /// <inheritdoc />
        public ApiBadRequestException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}