using TMAPI.Net.Core;
using Xunit;

namespace TMAPI.Net.Tests.Core
{
    public class ConstructTest : TMAPITestCase
    {
        #region Static Constants
        public static readonly string TestTM1 = "mem://localhost/testm1";
        #endregion

        #region Tests
        private static void ItemIdentifiers_AddRemoveAndRetrieveByItemIdentifier(IConstruct construct)
        {
            var topicMap = construct.TopicMap;

            Assert.Empty(construct.ItemIdentifiers);

            var itemIdentifier = topicMap.CreateLocator(TestTM1 + "/12345");
            construct.AddItemIdentifier(itemIdentifier);

            Assert.Equal(1, construct.ItemIdentifiers.Count);
            Assert.True(construct.ItemIdentifiers.Contains(itemIdentifier));
            Assert.Equal(construct, topicMap.GetConstructByItemIdentifier(itemIdentifier));

            construct.RemoveItemIdentifier(itemIdentifier);

            Assert.Empty(construct.ItemIdentifiers);
            Assert.False(construct.ItemIdentifiers.Contains(itemIdentifier));
            Assert.Null(topicMap.GetConstructByItemIdentifier(itemIdentifier));
            Assert.Throws<ModelConstraintException>("Using null as item identifier is not allowed.", () => construct.AddItemIdentifier(null));
        }

        [Fact]
        public void TestTopicMap()
        {
            var topicMap = topicMapSystem.CreateTopicMap(TestTM1);
            ItemIdentifiers_AddRemoveAndRetrieveByItemIdentifier(topicMap);

            Assert.Null(topicMap.Parent);
            Assert.Equal(topicMap, topicMap.TopicMap);

            var id = topicMap.Id;
            Assert.Equal(topicMap, topicMap.GetConstructById(id));
        }

        [Fact]
        public void TestTopic()
        {
            var topicMap = topicMapSystem.CreateTopicMap(TestTM1);
            var topic = topicMap.CreateTopicBySubjectLocator(topicMap.CreateLocator(TestTM1 + "/12345"));

            ItemIdentifiers_AddRemoveAndRetrieveByItemIdentifier(topic);

            Assert.NotNull(topic.Parent);
            Assert.Equal(topicMap, topic.TopicMap);

            var id = topic.Id;
            Assert.Equal(topic, topicMap.GetConstructById(id));
        }

        [Fact]
        public void TestAssociation()
        {
            var topicMap = topicMapSystem.CreateTopicMap(TestTM1);
            var association = topicMap.CreateAssociation(topicMap.CreateTopic());

            ItemIdentifiers_AddRemoveAndRetrieveByItemIdentifier(association);

            Assert.NotNull(association.Parent);
            Assert.Equal(topicMap, association.TopicMap);

            var id = association.Id;
            Assert.Equal(association, topicMap.GetConstructById(id));
        }

        [Fact]
        public void TestRole()
        {
            var topicMap = topicMapSystem.CreateTopicMap(TestTM1);
            var association = topicMap.CreateAssociation(topicMap.CreateTopic());
            var role = association.CreateRole(topicMap.CreateTopic(), topicMap.CreateTopic());

            ItemIdentifiers_AddRemoveAndRetrieveByItemIdentifier(role);

            Assert.NotNull(role.Parent);
            Assert.Equal(topicMap, role.TopicMap);

            var id = role.Id;
            Assert.Equal(role, topicMap.GetConstructById(id));
        }

        [Fact]
        public void TestOccurrence()
        {
            var topicMap = topicMapSystem.CreateTopicMap(TestTM1);
            var topic = topicMap.CreateTopic();
            var occurrence = topic.CreateOccurrence(topicMap.CreateTopic(), "Occurrence");

            ItemIdentifiers_AddRemoveAndRetrieveByItemIdentifier(occurrence);

            Assert.NotNull(occurrence.Parent);
            Assert.Equal(topicMap, occurrence.TopicMap);

            var id = occurrence.Id;
            Assert.Equal(occurrence, topicMap.GetConstructById(id));
        }

        [Fact]
        public void TestName()
        {
            var topicMap = topicMapSystem.CreateTopicMap(TestTM1);
            var topic = topicMap.CreateTopic();
            var name = topic.CreateName("Name");

            ItemIdentifiers_AddRemoveAndRetrieveByItemIdentifier(name);

            Assert.NotNull(name.Parent);
            Assert.Equal(topicMap, name.TopicMap);

            var id = name.Id;
            Assert.Equal(name, topicMap.GetConstructById(id));
        }

        [Fact]
        public void TestVariant()
        {
            var topicMap = topicMapSystem.CreateTopicMap(TestTM1);
            var topic = topicMap.CreateTopic();
            var name = topic.CreateName("Name");
            var variant = name.CreateVariant("Variant", topicMap.CreateTopic());

            ItemIdentifiers_AddRemoveAndRetrieveByItemIdentifier(variant);

            Assert.NotNull(variant.Parent);
            Assert.Equal(topicMap, variant.TopicMap);

            var id = variant.Id;
            Assert.Equal(variant, topicMap.GetConstructById(id));
        }
        #endregion
    }
}