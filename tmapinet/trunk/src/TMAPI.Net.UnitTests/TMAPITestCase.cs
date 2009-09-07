namespace TMAPI.Net.Tests
{
    using System;
    using Net.Core;

    /// <summary>
    /// Base super class for all tests.
    /// </summary>
    /// <remarks>
    /// It will initialize a new <see cref="TopicMapSystemFactory"/> and a <see cref="ITopicMapSystem"/>.
    /// </remarks>
    public class TMAPITestCase : IDisposable
    {
        #region Fields

        /// <summary>
        /// Default topic map address.
        /// </summary>
        protected const string DefaultAddress = "http://sourceforge.net/projects/tmapinet/";

        /// <summary>
        /// Represents the current topic map system instance for the test case.
        /// </summary>
        protected readonly ITopicMapSystem topicMapSystem;

        /// <summary>
        /// Represents the current topic map system factory.
        /// </summary>
        protected readonly TopicMapSystemFactory topicMapSystemFactory;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TMAPITestCase"/> class.
        /// </summary>
        protected TMAPITestCase()
        {
            topicMapSystemFactory = NewTopicMapSystemFactoryInstance();
            topicMapSystem = topicMapSystemFactory.NewTopicMapSystem();

            TopicMap = topicMapSystem.CreateTopicMap(DefaultAddress);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the topic map.
        /// </summary>
        protected ITopicMap TopicMap { get; private set; }

        #endregion

        #region Methods

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

        /// <summary>
        /// Removes all topic maps.
        /// </summary>
        public void Dispose()
        {
            foreach (var locator in topicMapSystem.Locators)
            {
                var topicMap = topicMapSystem.GetTopicMap(locator);

                topicMap.Remove();
            }
        }

        /// <summary>
        /// Creates a topic with a random item identifier.
        /// </summary>
        /// <returns>
        /// The topic.
        /// </returns>
        protected ITopic CreateTopic()
        {
            return TopicMap.CreateTopic();
        }

        /// <summary>
        /// Creates an association with a random type and no roles.
        /// </summary>
        /// <returns>
        /// The association.
        /// </returns>
        protected IAssociation CreateAssociation()
        {
            return TopicMap.CreateAssociation(CreateTopic());
        }

        /// <summary>
        /// Creates a role which is part of a random association with a random player and type.
        /// </summary>
        /// <returns>
        /// The new role.
        /// </returns>
        protected IRole CreateRole()
        {
            return CreateAssociation().CreateRole(CreateTopic(), CreateTopic());
        }

        /// <summary>
        /// Creates an occurrence which is part of a random topic with a random type.
        /// </summary>
        /// <returns>
        /// The occurrence.
        /// </returns>
        protected IOccurrence CreateOccurrence()
        {
            return CreateTopic().CreateOccurrence(CreateTopic(), "Occurrence");
        }

        /// <summary>
        /// Creates a name which is part of a newly created topic using the default type name.
        /// </summary>
        /// <returns>
        /// The new name.
        /// </returns>
        protected IName CreateName()
        {
            return CreateTopic().CreateName("Name");
        }

        /// <summary>
        /// Creates a variant which is part of a newly created name.
        /// </summary>
        /// <returns>
        /// The variant.
        /// </returns>
        protected IVariant CreateVariant()
        {
            return CreateName().CreateVariant("Variant", CreateTopic());
        }

        #endregion
    }
}