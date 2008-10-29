using System;

namespace org.tmapi.core {
	/// <summary>
	///     Exception thrown when the underlying implementation cannot support enabling or 
	///     disabling a recognised feature. If the feature name is not recognised, implementations 
    ///     <strong>MUST</strong> throw a <c>FeatureNotRecognizedException</c> rather than a <c>FeatureNotSupportedException</c>.
	/// </summary>
    [Serializable]
    public class FeatureNotSupportedException : FactoryConfigurationException
    {
        /// <summary>
        ///     Constructs a new exception.
        /// </summary>
        public FeatureNotSupportedException() {}

        /// <summary>
        ///     Constructs a new exception with the specified detail <paramref name="message"/>.
        /// </summary>
        /// <param name="message">
        ///     The detail message.
        /// </param>
        public FeatureNotSupportedException(string message)
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
        public FeatureNotSupportedException(string message, Exception innerException)
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
        protected FeatureNotSupportedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}