namespace TMAPI.Net.UnitTests.Core
{
    using System.Collections.Generic;
    using Net.Core;
    using Xunit;

    /// <summary>
    /// Checks the "same topic map" constraint.
    /// </summary>
    public class SameTopicMapTests : TMAPITestCase
    {
        #region Fields

        private readonly ITopicMap _tm2;

        #endregion

        #region Constructors

        public SameTopicMapTests() {
            _tm2 = TopicMapSystem.CreateTopicMap("http://topicMap2");
        }

        #endregion

        #region Tests

        [Fact]
        public void CreateAssociation_IllegalType()
        {
            // action
            Assert.ThrowsDelegate e = () => TopicMap.CreateAssociation(_tm2.CreateTopic());

            // assert
            Assert.Throws<ModelConstraintException>("Expected a model constraint violation.", e);
        }

        [Fact]
        public void CreateAssociation_IllegalScopeArray()
        {
            // action
            Assert.ThrowsDelegate e = () => TopicMap.CreateAssociation(CreateTopic(), CreateTopic(), _tm2.CreateTopic());

            // assert
            Assert.Throws<ModelConstraintException>("Expected a model constraint violation.", e);
        }

        [Fact]
        public void CreateAssociation_IllegalScopeCollection()
        {
            // setup
            var scope = new List<ITopic>
                             {
                                 CreateTopic(),
                                 _tm2.CreateTopic()
                             };

            // action
            Assert.ThrowsDelegate e = () => TopicMap.CreateAssociation(CreateTopic(), scope);

            // assert
            Assert.Throws<ModelConstraintException>("Expected a model constraint violation.", e);
        }

        [Fact]
        public void CreateName_IllegalType()
        {
            // action
            Assert.ThrowsDelegate e = () => CreateTopic().CreateName(_tm2.CreateTopic(), "value");

            // assert
            Assert.Throws<ModelConstraintException>("Expected a model constraint violation.", e);
        }

        [Fact]
        public void CreateName_IllegalScopeArray()
        {
            // action
            Assert.ThrowsDelegate e = () => CreateTopic().CreateName(CreateTopic(), "value", CreateTopic(), _tm2.CreateTopic());

            // assert
            Assert.Throws<ModelConstraintException>("Expected a model constraint violation.", e);
        }

        [Fact]
        public void CreateName_IllegalScopeCollection()
        {
            // setup
            var scope = new List<ITopic>
                             {
                                 CreateTopic(),
                                 _tm2.CreateTopic()
                             };

            // action
            Assert.ThrowsDelegate e = () => CreateTopic().CreateName(CreateTopic(), "value", scope);

            // assert
            Assert.Throws<ModelConstraintException>("Expected a model constraint violation.", e);
        }

        [Fact]
        public void CreateOccurrence_IllegalType()
        {
            // action
            Assert.ThrowsDelegate e = () => CreateTopic().CreateOccurrence(_tm2.CreateTopic(), "value");

            // assert
            Assert.Throws<ModelConstraintException>("Expected a model constraint violation.", e);
        }

        [Fact]
        public void CreateOccurrence_IllegalScopeArray()
        {
            // action
            Assert.ThrowsDelegate e = () => CreateTopic().CreateOccurrence(CreateTopic(), "value", CreateTopic(), _tm2.CreateTopic());

            // assert
            Assert.Throws<ModelConstraintException>("Expected a model constraint violation.", e);
        }

        [Fact]
        public void CreateOccurrence_IllegalScopeCollection()
        {
            // setup
            var scope = new List<ITopic>
                             {
                                 CreateTopic(),
                                 _tm2.CreateTopic()
                             };

            // action
            Assert.ThrowsDelegate e = () => CreateTopic().CreateOccurrence(CreateTopic(), "value", scope);

            // assert
            Assert.Throws<ModelConstraintException>("Expected a model constraint violation.", e);
        }

        [Fact]
        public void CreateRole_IllegalType()
        {
            // action
            Assert.ThrowsDelegate e = () => CreateAssociation().CreateRole(_tm2.CreateTopic(), CreateTopic());

            // assert
            Assert.Throws<ModelConstraintException>("Expected a model constraint violation.", e);
        }

        [Fact]
        public void CreateRole_IllegalPlayer()
        {
            // action
            Assert.ThrowsDelegate e = () => CreateAssociation().CreateRole(CreateTopic(), _tm2.CreateTopic());

            // assert
            Assert.Throws<ModelConstraintException>("Expected a model constraint violation.", e);
        }

        private void AddIllegalTheme(IScoped scoped)
        {
            // action
            Assert.ThrowsDelegate e = () => scoped.AddTheme(_tm2.CreateTopic());

            // assert
            Assert.Throws<ModelConstraintException>("Adding a theme from another topic map shouldn't be allowed.", e);
        }

        [Fact]
        public void Association_AddIllegalTheme()
        {
            AddIllegalTheme(CreateAssociation());
        }

        [Fact]
        public void Occurrence_AddIllegalTheme()
        {
            AddIllegalTheme(CreateOccurrence());
        }

        [Fact]
        public void Name_AddIllegalTheme()
        {
            AddIllegalTheme(CreateName());
        }

        [Fact]
        public void Variant_AddIllegalTheme()
        {
            AddIllegalTheme(CreateVariant());
        }

        private void SetIllegalType(ITyped typed)
        {
            // action
            Assert.ThrowsDelegate e = () => typed.Type = _tm2.CreateTopic();

            // assert
            Assert.Throws<ModelConstraintException>("Setting the type to a topic from another topic map shouldn't be allowed.", e);
        }

        [Fact]
        public void Association_SetIllegalType()
        {
            SetIllegalType(CreateAssociation());
        }

        [Fact]
        public void Role_SetIllegalType()
        {
            SetIllegalType(CreateRole());
        }

        [Fact]
        public void Occurrence_SetIllegalType()
        {
            SetIllegalType(CreateOccurrence());
        }

        [Fact]
        public void Name_SetIllegalType()
        {
            SetIllegalType(CreateName());
        }

        [Fact]
        public void Role_SetIllegalPlayer()
        {
            // action
            Assert.ThrowsDelegate e = () => CreateRole().Player = _tm2.CreateTopic();

            // assert
            Assert.Throws<ModelConstraintException>("Setting the player to a topic of another topic map shouldn't be allowed.", e);
        }

        private void SetIllegalReifier(IReifiable reifiable)
        {
            // action
            Assert.ThrowsDelegate e = () => reifiable.Reifier = _tm2.CreateTopic();

            // assert
            Assert.Throws<ModelConstraintException>("Setting the reifier to a topic of another topic map shouldn't be allowed.", e);
        }

        [Fact]
        public void TopicMap_SetIllegalReifier()
        {
            SetIllegalReifier(TopicMap);
        }

        [Fact]
        public void Association_SetIllegalReifier()
        {
            SetIllegalReifier(CreateAssociation());
        }

        [Fact]
        public void Role_SetIllegalReifier()
        {
            SetIllegalReifier(CreateRole());
        }

        [Fact]
        public void Occurrence_SetIllegalReifier()
        {
            SetIllegalReifier(CreateOccurrence());
        }

        [Fact]
        public void Name_SetIllegalReifier()
        {
            SetIllegalReifier(CreateName());
        }

        [Fact]
        public void Variant_SetIllegalReifier()
        {
            SetIllegalReifier(CreateVariant());
        }

        [Fact]
        public void Topic_AddIllegalType()
        {
            // action
            Assert.ThrowsDelegate e = () => CreateTopic().AddType(_tm2.CreateTopic());

            // assert
            Assert.Throws<ModelConstraintException>("The type is not from the same topic map. Disallowed.", e);
        }

        #endregion
    }
}
