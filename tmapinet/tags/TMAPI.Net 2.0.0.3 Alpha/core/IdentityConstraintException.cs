using System;

namespace org.tmapi.core {
	/// <summary>
	///     This exception is used to report identity constraint violations.
	///     Assigning an item identifier, a subject identifier, or a subject locator to 
	///     different objects causes an <c>IdentityConstraintException</c> to be thrown.
	/// </summary>
    [Serializable]
    public class IdentityConstraintException : ModelConstraintException
    {
        /// <summary>
        ///     Constructs a new exception.
        /// </summary>
        public IdentityConstraintException() {}

        /// <summary>
        ///     Constructs a new exception with the specified detail <paramref name="message"/>.
        /// </summary>
        /// <param name="message">
        ///     The detail message.
        /// </param>
        public IdentityConstraintException(string message)
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
        public IdentityConstraintException(string message, Exception innerException)
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
        protected IdentityConstraintException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}