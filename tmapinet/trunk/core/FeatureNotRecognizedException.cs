using System;

namespace org.tmapi.core {
	/// <summary>
	///     Exception thrown when the <see cref="T:org.tmapi.core.TopicMapsSystemFactory"/> does not 
	///     recognize the name of a feature that the application is trying to enable or disable.
	/// </summary>
    [Serializable]
    public class FeatureNotRecognizedException : FactoryConfigurationException
    {
        /// <summary>
        ///     Constructs a new exception.
        /// </summary>
        public FeatureNotRecognizedException() {}

        /// <summary>
        ///     Constructs a new exception with the specified detail <paramref name="message"/>.
        /// </summary>
        /// <param name="message">
        ///     The detail message.
        /// </param>
        public FeatureNotRecognizedException(string message)
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
        public FeatureNotRecognizedException(string message, Exception innerException)
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
        protected FeatureNotRecognizedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}