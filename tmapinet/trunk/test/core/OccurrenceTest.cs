using org.tmapi.core;
using Xunit;
using TopicMapSystemFactory=org.tmapi.core.TopicMapSystemFactory;

namespace net.nexxor.kalanchoe.test.tmapi.core
{
    public class OccurrenceTest
    {
        #region Fields
        private readonly ITopicMapSystem _system; 
        #endregion

        #region Static Constants
        public static readonly string TestTM1 = "mem://localhost/testm1";
        public static readonly string TestLocator1 = TestTM1 + "/locator1";
        public static readonly string TestLocator2 = TestTM1 + "/locator2";
        #endregion

        #region Constructors
        public OccurrenceTest()
        {
            var tmf = TopicMapSystemFactory.NewInstance();
            _system = tmf.NewTopicMapSystem();
        }
        #endregion

        #region Tests
        [Fact]
        public void TestOccurrenceParentRelationship()
        {
            var topicMap = _system.CreateTopicMap(TestTM1);
            var parent = topicMap.CreateTopic();

            Assert.Empty(parent.Occurrences);

            var occurrence = parent.CreateOccurrence(topicMap.CreateTopic(), "Occurrence");

            Assert.Equal(parent, occurrence.Parent);
            Assert.Equal(1, parent.Occurrences.Count);
            Assert.True(parent.Occurrences.Contains(occurrence));

            occurrence.Remove();

            Assert.Empty(parent.Occurrences);
        }
        #endregion
    }
}