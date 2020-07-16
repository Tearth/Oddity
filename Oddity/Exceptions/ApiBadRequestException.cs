using System;

namespace Oddity.Exceptions
{
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