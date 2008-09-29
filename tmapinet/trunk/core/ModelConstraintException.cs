using System;

namespace org.tmapi.core
{
    /// <summary>
    ///     This exception is used to report 
    ///     <a href="http://www.isotopicmaps.org/sam/sam-model/">Topic Maps — Data Model</a> constraint violations.
    /// </summary>
    [Serializable]
    public class ModelConstraintException : TMAPIRuntimeException
    {
        /// <summary>
        ///     Constructs a new exception.
        /// </summary>
        public ModelConstraintException() {}

        /// <summary>
        ///     Constructs a new exception with the specified detail <paramref name="message"/>.
        /// </summary>
        /// <param name="message">
        ///     The detail message.
        /// </param>
        public ModelConstraintException(string message)
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
        public ModelConstraintException(string message, Exception innerException)
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
        protected ModelConstraintException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}