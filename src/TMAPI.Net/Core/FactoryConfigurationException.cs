// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryConfigurationException.cs">
//  TMAPI.Net was created collectively by the membership of the tmapinet-discuss mailing list 
//  (https://lists.sourceforge.net/lists/listinfo/tmapinet-discuss) with support by the 
//  tmapi-discuss mailing list (http://lists.sourceforge.net/mailman/listinfo/tmapi-discuss),
//  and is hereby released into the public domain; and comes with NO WARRANTY.
//  
//  No one owns TMAPI.Net: you may use it freely in both commercial and
//  non-commercial applications, bundle it with your software
//  distribution, include it on a CD-ROM, list the source code in a
//  book, mirror the documentation at your own web site, or use it in
//  any other way you see fit.
// </copyright>
// <summary>
//   Exception thrown when a <see cref="T:TMAPI.Net.Core.TopicMapSystemFactory" /> instance cannot be
//   instantiated through the method <see cref="M:TMAPI.Net.Core.TopicMapSystemFactory.NewInstance" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TMAPI.Net.Core
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception thrown when a <see cref="T:TMAPI.Net.Core.TopicMapSystemFactory"/> instance cannot be 
    /// instantiated through the method <see cref="M:TMAPI.Net.Core.TopicMapSystemFactory.NewInstance"/>.
    /// </summary>
    [Serializable]
    public class FactoryConfigurationException : TMAPIException
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FactoryConfigurationException"/> class.
        /// </summary>
        public FactoryConfigurationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FactoryConfigurationException"/> class.
        /// </summary>
        /// <param name="message">
        /// The detail message.
        /// </param>
        public FactoryConfigurationException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FactoryConfigurationException"/> class.
        /// </summary>
        /// <param name="message">
        /// The detail message.
        /// </param>
        /// <param name="innerException">
        /// Exception to be wrapped.
        /// </param>
        public FactoryConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FactoryConfigurationException"/> class.
        /// </summary>
        /// <param name="info">
        /// The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object
        /// data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual
        /// information about the source or destination.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="info"/> parameter is null. 
        /// </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">
        /// The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). 
        /// </exception>
        protected FactoryConfigurationException(
                SerializationInfo info,
                StreamingContext context) : base(info, context)
        {
        }

        #endregion
    }
}