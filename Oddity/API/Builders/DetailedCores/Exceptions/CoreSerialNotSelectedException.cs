using System;

namespace Oddity.API.Builders.DetailedCores.Exceptions
{
    /// <summary>
    /// The exception that is thrown when user tries to get API data without selected core serial.
    /// </summary>
    public class CoreSerialNotSelectedException : Exception
    {
        /// <inheritdoc />
        public CoreSerialNotSelectedException()
        {

        }

        /// <inheritdoc />
        public CoreSerialNotSelectedException(string message) : base(message)
        {

        }

        /// <inheritdoc />
        public CoreSerialNotSelectedException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
