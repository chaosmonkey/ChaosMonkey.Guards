using System;
using System.Runtime.Serialization;

namespace ChaosMonkey.Guards
{
    [Serializable]
    public class GuardException : Exception
    {
        /// <summary>
        /// Default message for a Guard Exception
        /// </summary>
        public const string DefaultMessage = "A guard codition has been violated.";

        /// <summary>
        /// Create a GuardException with the default message and no inner exception.
        /// </summary>
        public GuardException()
            : base(DefaultMessage)
        {
        }

        /// <summary>
        /// Constructor for GuardException for serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public GuardException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Create a GuardException with a custom message. 
        /// </summary>
        /// <param name="message"></param>
        public GuardException(string message)
            : base(message ?? string.Empty)
        {
        }

        /// <summary>
        /// Create a GuardException with a custom message and an inner exception.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public GuardException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
