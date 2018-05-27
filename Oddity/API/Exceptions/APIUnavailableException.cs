using System;

namespace Oddity.API.Exceptions
{
    /// <summary>
    /// The exception that is thrown when SpaceX API is unavailable and data can't be loaded.
    /// </summary>
    public class APIUnavailableException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="APIUnavailableException"/> class.
        /// </summary>
        public APIUnavailableException()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="APIUnavailableException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public APIUnavailableException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="APIUnavailableException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null 
        /// reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public APIUnavailableException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
