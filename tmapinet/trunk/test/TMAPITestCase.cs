using System;
using System.Reflection;
using TMAPI.Net.Core;

namespace TMAPI.Net.Tests
{
	public class TMAPITestCase
	{
		#region Fields
		protected readonly ITopicMapSystem _system;
		#endregion

		#region constructor logic
		public TMAPITestCase()
		{
			var tmf = NewTopicMapSystemFactoryInstance();
			_system = tmf.NewTopicMapSystem();
		}

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
			foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
			{
				if (type.IsSubclassOf(typeof(TopicMapSystemFactory)))
				{
					foreach (MethodInfo methodInfo in type.GetMethods(BindingFlags.Static | BindingFlags.Public))
					{
						if (methodInfo.Name == "NewInstance" && methodInfo.GetParameters().Length == 0)
						{
							return methodInfo.Invoke(null, null) as TopicMapSystemFactory;
						}
					}
				}
			}

			throw new InvalidOperationException("You have to implement TopicMapSystemFactory first and add the reference to this project.");
		}
		#endregion
	}
}