using System;

namespace org.tmapi.core
{
	/// <summary>
	///     Exception thrown when the <see cref="T:org.tmapi.core.TopicMapsSystemFactory"/> does not 
	///     recognize the name of a feature that the application is trying to enable or disable.
	/// </summary>
	[Serializable]
	public class FeatureNotRecognizedException : FactoryConfigurationException
	{
		#region constructor logic
		/// <summary>
		/// Initializes a new instance of the <see cref="FeatureNotRecognizedException"/> class.
		/// </summary>
		public FeatureNotRecognizedException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FeatureNotRecognizedException"/> class with the specified detail <paramref name="message"/>.
		/// </summary>
		/// <param name="message">The detail message.</param>
		public FeatureNotRecognizedException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FeatureNotRecognizedException"/> class that wraps another exception with the specified detail <paramref name="message"/>.
		/// </summary>
		/// <param name="message">The detail message.</param>
		/// <param name="innerException">Exception to be wrapped.</param>
		public FeatureNotRecognizedException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FeatureNotRecognizedException"/> class with serialized data.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object
		/// data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual
		/// information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
		protected FeatureNotRecognizedException(
			System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
			: base(info, context)
		{
		}
		#endregion
	}
}