using System;

namespace org.tmapi.core {
	/// <summary>
    ///     Exception thrown when a <see cref="T:org.tmapi.core.TopicMapSystemFactory"/> instance cannot be 
    ///     instantiated through the method <see cref="M:org.tmapi.core.TopicMapSystemFactory.NewInstance"/>.
	/// </summary>
    [Serializable]
	public class FactoryConfigurationException : TMAPIException
    {
        /// <summary>
        ///     Constructs a new exception.
        /// </summary>
        public FactoryConfigurationException() {}

        /// <summary>
        ///     Constructs a new exception with the specified detail <paramref name="message"/>.
        /// </summary>
        /// <param name="message">
        ///     The detail message.
        /// </param>
        public FactoryConfigurationException(string message)
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
        public FactoryConfigurationException(string message, Exception innerException)
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
        protected FactoryConfigurationException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}