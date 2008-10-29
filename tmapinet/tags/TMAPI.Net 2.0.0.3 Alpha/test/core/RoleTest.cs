using org.tmapi.core;
using Xunit;

namespace org.tmapi.test
{
    public class RoleTest
    {
        #region Fields
        private readonly ITopicMapSystem _system; 
        #endregion

        #region Static Constants
        public static readonly string TestTM1 = "mem://localhost/testm1";
        #endregion

        #region Constructors
        public RoleTest()
        {
            var tmf = TopicMapSystemFactory.NewInstance();
            _system = tmf.NewTopicMapSystem();
        }
        #endregion

        #region Tests
        [Fact]
        public void TestRoleParentRelationship()
        {
            var topicMap = _system.CreateTopicMap(TestTM1);
            var parent = topicMap.CreateAssociation(topicMap.CreateTopic());

            Assert.Empty(parent.Roles);

            var role = parent.CreateRole(topicMap.CreateTopic(), topicMap.CreateTopic());

            Assert.Equal(parent, role.Parent);
            Assert.Equal(1, parent.Roles.Count);
            Assert.True(parent.Roles.Contains(role));

            role.Remove();

            Assert.Empty(parent.Roles);
        }

        [Fact]
        public void Player_GetAndSetRolePlayer()
        {
            var topicMap = _system.CreateTopicMap(TestTM1);
            var association = topicMap.CreateAssociation(topicMap.CreateTopic());

            Assert.Empty(association.Roles);

            var roleType = topicMap.CreateTopic();
            var player = topicMap.CreateTopic();
            var role = association.CreateRole(roleType, player);

            Assert.Equal(roleType, role.Type);
            Assert.Equal(player, role.Player);
            Assert.True(player.RolesPlayed.Contains(role));

            var player2 = topicMap.CreateTopic();

            role.Player = player2;

            Assert.Equal(player2, role.Player);
            Assert.True(player2.RolesPlayed.Contains(role));
            Assert.Empty(player.RolesPlayed);

            role.Player = player;

            Assert.Equal(player, role.Player);
        }

        [Fact]
        public void Player_UsingInvalidPlayerThrowsException()
        {
            var topicMap = _system.CreateTopicMap(TestTM1);
            var association = topicMap.CreateAssociation(topicMap.CreateTopic());
            var role = association.CreateRole(topicMap.CreateTopic(), topicMap.CreateTopic());

            Assert.Throws<ModelConstraintException>("Using null as player for a role is not allowed.", () => role.Player = null);
        }
        #endregion
    }
}