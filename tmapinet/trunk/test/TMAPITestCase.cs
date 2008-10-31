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

		public static TopicMapSystemFactory NewTopicMapSystemFactoryInstance()
		{
			return TopicMapSystemFactory.NewInstance();
		}
		#endregion
	}
}