namespace TrafficLightDataAnalyzer.Exception
{
    /// <summary>
    /// Invalid argument state exception class.
    /// </summary>
    public class InvalidArgumentStateException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="System.Exception">System.Exception</see> class.
        /// </summary>
        public InvalidArgumentStateException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="System.Exception">System.Exception</see> class with a specified error <paramref name="message" />.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidArgumentStateException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="System.Exception">System.Exception</see> class with a specified error
        /// <paramref name="message" /> and a reference to the <paramref name="innerException" /> that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public InvalidArgumentStateException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
