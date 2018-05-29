using System;

namespace Oddity.API.Builders.DetailedCapsules.Exceptions
{
    /// <summary>
    /// The exception that is thrown when user tries to get API data without selected capsule serial.
    /// </summary>
    public class CapsuleSerialNotSelectedException : Exception
    {
        /// <inheritdoc />
        public CapsuleSerialNotSelectedException()
        {

        }

        /// <inheritdoc />
        public CapsuleSerialNotSelectedException(string message) : base(message)
        {

        }

        /// <inheritdoc />
        public CapsuleSerialNotSelectedException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
