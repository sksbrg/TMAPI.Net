using TMAPI.Net.Core;
using Xunit;

namespace TMAPI.Net.Tests.Core
{
    public class ReifiableTest : TMAPITestCase
    {
        #region Static Constants
        public static readonly string TestTM1 = "mem://localhost/testm1";
        #endregion

        #region Tests
        private static void TestReification(IReifiable reifiable)
        {
            var topicMap = reifiable.TopicMap;
            var reifier = topicMap.CreateTopic();

            Assert.Null(reifiable.Reifier);
            Assert.Null(reifier.Reified);

            reifiable.Reifier = reifier;

            Assert.Equal(reifier, reifiable.Reifier);
            Assert.Equal(reifiable, reifier.Reified);

            reifiable.Reifier = null;

            Assert.Null(reifiable.Reifier);
            Assert.Null(reifier.Reified);

            reifiable.Reifier = reifier;

            Assert.Equal(reifier, reifiable.Reifier);
            Assert.Equal(reifiable, reifier.Reified);

            //  TODO:   auf der TMAPI-mailingliste nach dem sinn fragen
            reifiable.Reifier = reifier;

            Assert.Equal(reifier, reifiable.Reifier);
            Assert.Equal(reifiable, reifier.Reified);
            //Assert.Throws<ModelConstraintException>("Setting the reifier to the same value is not allowed.", () => reifiable.Reifier = reifier);
        }

        private static void TestReificationCollosion(IReifiable reifiable)
        {
            var topicMap = reifiable.TopicMap;
            var reifier = topicMap.CreateTopic();

            Assert.Null(reifiable.Reifier);
            Assert.Null(reifier.Reified);

            var otherReifiable = topicMap.CreateAssociation(topicMap.CreateTopic());
            otherReifiable.Reifier = reifier;

            Assert.Equal(reifier, otherReifiable.Reifier);
            Assert.Equal(otherReifiable, reifier.Reified);

            Assert.Throws<ModelConstraintException>("The reifier reifies already another construct.", () => reifiable.Reifier = reifier);

            otherReifiable.Reifier = null;

            Assert.Null(otherReifiable.Reifier);
            Assert.Null(reifier.Reified);

            reifiable.Reifier = reifier;

            Assert.Equal(reifier, reifiable.Reifier);
            Assert.Equal(reifiable, reifier.Reified);
        }

        [Fact]
        public void TestTopicMap()
        {
            var topicMap = _system.CreateTopicMap(TestTM1);
            TestReification(topicMap);
        }

        [Fact]
        public void TestTopicMapReifierCollosion()
        {
            var topicMap = _system.CreateTopicMap(TestTM1);
            TestReificationCollosion(topicMap);
        }

        [Fact]
        public void TestAssociation()
        {
            var topicMap = _system.CreateTopicMap(TestTM1);
            var association = topicMap.CreateAssociation(topicMap.CreateTopic());

            TestReification(association);
        }

        [Fact]
        public void TestAssociationReifierCollosion()
        {
            var topicMap = _system.CreateTopicMap(TestTM1);
            var association = topicMap.CreateAssociation(topicMap.CreateTopic());

            TestReificationCollosion(association);
        }

        [Fact]
        public void TestRole()
        {
            var topicMap = _system.CreateTopicMap(TestTM1);
            var association = topicMap.CreateAssociation(topicMap.CreateTopic());
            var role = association.CreateRole(topicMap.CreateTopic(), topicMap.CreateTopic());

            TestReification(role);
        }

        [Fact]
        public void TestRoleReifierCollosion()
        {
            var topicMap = _system.CreateTopicMap(TestTM1);
            var association = topicMap.CreateAssociation(topicMap.CreateTopic());
            var role = association.CreateRole(topicMap.CreateTopic(), topicMap.CreateTopic());

            TestReificationCollosion(role);
        }

        [Fact]
        public void TestOccurrence()
        {
            var topicMap = _system.CreateTopicMap(TestTM1);
            var topic = topicMap.CreateTopic();
            var occurrence = topic.CreateOccurrence(topicMap.CreateTopic(), "Occurrence");

            TestReification(occurrence);
        }

        [Fact]
        public void TestOccurrenceReifierCollosion()
        {
            var topicMap = _system.CreateTopicMap(TestTM1);
            var topic = topicMap.CreateTopic();
            var occurrence = topic.CreateOccurrence(topicMap.CreateTopic(), "Occurrence");

            TestReificationCollosion(occurrence);
        }

        [Fact]
        public void TestName()
        {
            var topicMap = _system.CreateTopicMap(TestTM1);
            var topic = topicMap.CreateTopic();
            var name = topic.CreateName("Name");

            TestReification(name);
        }

        [Fact]
        public void TestNameReifierCollosion()
        {
            var topicMap = _system.CreateTopicMap(TestTM1);
            var topic = topicMap.CreateTopic();
            var name = topic.CreateName("Name");

            TestReificationCollosion(name);
        }

        [Fact]
        public void TestVariant()
        {
            var topicMap = _system.CreateTopicMap(TestTM1);
            var topic = topicMap.CreateTopic();
            var name = topic.CreateName("Name");
            var variant = name.CreateVariant("Variant", topicMap.CreateTopic());

            TestReification(variant);
        }

        [Fact]
        public void TestVariantReifierCollosion()
        {
            var topicMap = _system.CreateTopicMap(TestTM1);
            var topic = topicMap.CreateTopic();
            var name = topic.CreateName("Name");
            var variant = name.CreateVariant("Variant", topicMap.CreateTopic());

            TestReificationCollosion(variant);
        }
        #endregion
    }
}