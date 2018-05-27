using System;

namespace Oddity.API.Builders.Capsule.Exceptions
{
    /// <summary>
    /// The exception that is thrown when user tries to get API data without selected capsule type.
    /// </summary>
    public class CapsuleTypeNotSelectedException : Exception
    {
        /// <inheritdoc />
        public CapsuleTypeNotSelectedException()
        {

        }

        /// <inheritdoc />
        public CapsuleTypeNotSelectedException(string message) : base(message)
        {

        }

        /// <inheritdoc />
        public CapsuleTypeNotSelectedException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
