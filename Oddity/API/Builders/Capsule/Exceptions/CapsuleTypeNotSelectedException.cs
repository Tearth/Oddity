using System;

namespace Oddity.API.Builders.Capsule.Exceptions
{
    /// <summary>
    /// The exception that is thrown when user tries to get API data without selected capsule type.
    /// </summary>
    public class CapsuleTypeNotSelectedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CapsuleTypeNotSelectedException"/> class.
        /// </summary>
        public CapsuleTypeNotSelectedException()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CapsuleTypeNotSelectedException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CapsuleTypeNotSelectedException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CapsuleTypeNotSelectedException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null 
        /// reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public CapsuleTypeNotSelectedException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
