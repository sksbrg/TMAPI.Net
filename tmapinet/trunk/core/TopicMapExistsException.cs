using System;

namespace org.tmapi.core {
	/// <summary>
	///     Exception thrown when an attempt is made to create a new <see cref="T:org.tmapi.core.ITopicMap"/> under 
	///     a storage address (an IRI) that is already assigned to another <see cref="T:org.tmapi.core.ITopicMap"/> 
	///     in the same <see cref="T:org.tmapi.core.ITopicMapSystem"/>.
	/// </summary>
    [Serializable]
    public class TopicMapExistsException : TMAPIException
    {
        /// <summary>
        ///     Constructs a new exception.
        /// </summary>
        public TopicMapExistsException() {}

        /// <summary>
        ///     Constructs a new exception with the specified detail <paramref name="message"/>.
        /// </summary>
        /// <param name="message">
        ///     The detail message.
        /// </param>
        public TopicMapExistsException(string message)
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
        public TopicMapExistsException(string message, Exception innerException)
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
        protected TopicMapExistsException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}