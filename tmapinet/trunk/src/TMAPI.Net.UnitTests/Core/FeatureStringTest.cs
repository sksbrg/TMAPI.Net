// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssociationTest.cs">
//  TMAPI.Net was created collectively by the membership of the tmapinet-discuss mailing list 
//  (https://lists.sourceforge.net/lists/listinfo/tmapinet-discuss) with support by the 
//  tmapi-discuss mailing list (http://lists.sourceforge.net/mailman/listinfo/tmapi-discuss),
//  and is hereby released into the public domain; and comes with NO WARRANTY.
//  
//  No one owns TMAPI.Net: you may use it freely in both commercial and
//  non-commercial applications, bundle it with your software
//  distribution, include it on a CD-ROM, list the source code in a
//  book, mirror the documentation at your own web site, or use it in
//  any other way you see fit.
// </copyright>
// <summary>
//   Defines the AssociationTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TMAPI.Net.UnitTests.Core
{
    using Xunit;

    /// <summary>
    /// Tests if the TMAPI feature strings are recognised.
    /// </summary>
    public class FeatureStringTest : TMAPITestCase
    {
        /// <summary>
        /// "type-instance-associations" feature string
        /// </summary>
        private const string TypeInstanceAssocs = "http://tmapi.org/features/type-instance-associations";

        /// <summary>
        /// "readOnly" feature string
        /// </summary>
        private const string ReadOnly = "http://tmapi.org/features/readOnly";

        /// <summary>
        /// "automerge" feature string
        /// </summary>
        private const string Automerge = "http://tmapi.org/features/automerge";

        /// <summary>
        /// Tests the feature string "type-instance-associations".
        /// </summary>
        [Fact]
        public void CheckSupportForTypeInstanceAssociationsFeatureString()
        {
            TestFeature(TypeInstanceAssocs);
        }

        /// <summary>
        /// Tests the feature string "automerge".
        /// </summary>
        [Fact]
        public void CheckSupportForAutomergeFeatureString()
        {
            TestFeature(Automerge);
        }

        /// <summary>
        /// Tests the feature string "readOnly".
        /// </summary>
        [Fact]
        public void CheckSupportForReadOnlyFeatureString()
        {
            TestFeature(ReadOnly);
        }

        /// <summary>
        /// Tests the provided <paramref name="featureName"/>. The featureName must be recognized by the engine.
        /// </summary>
        /// <param name="featureName">
        /// The name of the feature to test.
        /// </param>
        private static void TestFeature(string featureName) 
        {
            var factory = NewTopicMapSystemFactoryInstance();

            var enabledInFactory = false;

            Assert.ThrowsDelegate throwsDelegate = () => { enabledInFactory = factory.GetFeature(featureName); };

            // assert no FeatureNotRecognizedException is thrown when feature is requested
            Assert.DoesNotThrow(throwsDelegate);

            throwsDelegate = () => factory.SetFeature(featureName, enabledInFactory);

            // assert no FeatureNotSupportedException is thrown when feature is set
            Assert.DoesNotThrow(throwsDelegate);

            var topicMapSystem = factory.NewTopicMapSystem();

            var enabledInSystem = topicMapSystem.GetFeature(featureName);
            Assert.Equal(enabledInFactory, enabledInSystem);
        }
    }
}