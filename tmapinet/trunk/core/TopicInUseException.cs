using System;

namespace org.tmapi.core {
	/// <summary>
	///     Thrown when an attempt is made to remove a <see cref="T:org.tmapi.core.ITopic"/> which is being used as 
	///     a type, as a reifier, or as a role player in an association, or in a scope.
	/// </summary>
    [Serializable]
    public class TopicInUseException : ModelConstraintException
    {
        /// <summary>
        ///     Constructs a new exception.
        /// </summary>
        public TopicInUseException() {}

        /// <summary>
        ///     Constructs a new exception with the specified detail <paramref name="message"/>.
        /// </summary>
        /// <param name="message">
        ///     The detail message.
        /// </param>
        public TopicInUseException(string message)
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
        public TopicInUseException(string message, Exception innerException)
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
        protected TopicInUseException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}