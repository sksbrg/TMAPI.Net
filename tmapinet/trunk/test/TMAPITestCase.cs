using System;
using TMAPI.Net.Core;

namespace TMAPI.Net.Tests
{
	/// <summary>
	/// Base super class for all tests.
	/// </summary>
	/// <remarks>
	/// It will initialize a new <see cref="TopicMapSystemFactory"/> and a <see cref="ITopicMapSystem"/>.
	/// </remarks>
	public class TMAPITestCase
	{
		#region Fields
		protected readonly ITopicMapSystem _system;
		#endregion

		#region constructor logic
		/// <summary>
		/// Initializes a new instance of the <see cref="TMAPITestCase"/> class.
		/// </summary>
		public TMAPITestCase()
		{
			TopicMapSystemFactory tmf = NewTopicMapSystemFactoryInstance();
			_system = tmf.NewTopicMapSystem();
		}
		#endregion

		#region methods
		/// <summary>
		/// Returns a new instance of <see cref="TopicMapSystemFactory"/>.
		/// </summary>
		/// <remarks>
		/// Tries to find an implementation (subclass) of <see cref="TopicMapSystemFactory"/> 
		/// and will invoke the <see cref="TopicMapSystemFactory.NewInstance"/> method.
		/// </remarks>
		/// <returns>A new instance of TopicMapSystemFactory.</returns>
		public static TopicMapSystemFactory NewTopicMapSystemFactoryInstance()
		{
			throw new InvalidOperationException("You have to implement NewTopicMapSystemFactoryInstance method first.");

			// TODO: implement NewTopicMapSystemFactoryInstance method for testing.
			// return TopicMapSystemFactory.NewInstance<YOUR_FACTORY_IMPLEMENTATION_TYPE>();
		}
		#endregion
	}
}