using System;

namespace org.tmapi.core {
	/// <summary>
	///     The base class for all standard (non run-time) exceptions thrown by a TMAPI system.
	/// </summary>
    [Serializable] 
	public class TMAPIException : Exception 
    {
        /// <summary>
        ///     Constructs a new exception.
        /// </summary>
        public TMAPIException() {}

        /// <summary>
        ///     Constructs a new exception with the specified detail <paramref name="message"/>.
        /// </summary>
        /// <param name="message">
        ///     The detail message.
        /// </param>
        public TMAPIException(string message)
            : base(message)
        {

        }

        /// <summary>
        ///     Constructs a new exception that wraps another exception with the specified detail <paramref name="message"/>.
        /// </summary>
        /// <param name="message">
        ///     The detail message.    
        /// </param>
        /// <param name="innerException">
        ///     Exception to be wrapped.
        /// </param>
        public TMAPIException(string message, Exception innerException)
            : base(message, innerException)
        {
            
        }

        /// <summary>
        ///     Constructs a new exception with serialized data. 
        /// </summary>
        /// <param name="info">
        ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object 
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual 
        ///     information about the source or destination.
        /// </param>
        protected TMAPIException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) 
            : base(info, context)
        {
            
        }
	}
}