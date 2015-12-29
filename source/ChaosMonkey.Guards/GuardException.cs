using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ChaosMonkey.Guards
{
    [Serializable]
    public class GuardException : Exception
    {
        // Constants
        internal const string DefaultMessage = "A guard codition has been violated.";

        // Constructors
        public GuardException()
            : base(DefaultMessage)
        {
        }

        public GuardException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public GuardException(string message)
            : base(message ?? string.Empty)
        {
        }

        public GuardException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

