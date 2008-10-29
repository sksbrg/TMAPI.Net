using System;

namespace org.tmapi.core
{
    /// <summary>
    ///     This factory class provides access to a <see cref="T:org.tmapi.core.ITopicMapSystem"/>.
    ///     A new <see cref="T:org.tmapi.core.ITopicMapSystem"/>. instance is created by invoking 
    ///     the <see cref="M:org.tmapi.core.TopicMapSystemFactory.NewTopicMapSystem"/> method.
    ///     Configuration properties for the new <see cref="T:org.tmapi.core.ITopicMapSystem"/>. instance 
    ///     can be set by calling the <see cref="M:org.tmapi.core.TopicMapSystemFactory.SetFeature"/> and 
    ///     / or <see cref="M:org.tmapi.core.TopicMapSystemFactory.SetProperty"/> methods prior to 
    ///     invoking <see cref="M:org.tmapi.core.TopicMapSystemFactory.NewTopicMapSystem"/>. 
    /// </summary>
    public abstract class TopicMapSystemFactory
    {
        /// <summary>
        ///     Returns the particular feature requested for in the underlying implementation of 
        ///     <see cref="T:org.tmapi.core.ITopicMapSystem"/>.
        /// </summary>
        /// <param name="featureName">
        ///     The name of the feature to check.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the named feature is enabled for <see cref="T:org.tmapi.core.ITopicMapSystem"/> 
        ///     instances created by this factory; <c>false</c> if the named feature is disabled for 
        ///     <see cref="T:org.tmapi.core.ITopicMapSystem"/> instances created by this factory. 
        /// </returns>
        /// <exception cref="FeatureNotRecognizedException">
        ///     If the underlying implementation does not recognize the named feature.
        /// </exception>
        public abstract bool GetFeature(string featureName);

        /// <summary>
        ///     Gets the value of a property in the underlying implementation of <see cref="T:org.tmapi.core.ITopicMapSystem"/>.
        ///     A list of the core properties defined by TMAPI can be found at http://tmapi.org/properties/.
        ///     An implementation is free to support properties other than the core ones. 
        /// </summary>
        /// <param name="propertyName">
        ///     The name of the property to retrieve.
        /// </param>
        /// <returns>
        ///     The value set for this property or <c>null</c> if no value is currently set for the property.
        /// </returns>
        public abstract Object GetProperty(string propertyName);

        /// <summary>
        ///     Returns if the particular feature is supported by the <see cref="T:org.tmapi.core.ITopicMapSystem"/>.
        ///     Opposite to <see cref="M:org.tmapi.core.TopicMapSystemFactory.GetFeature"/> this method returns if 
        ///     the requested feature is generally available / supported by the underlying <see cref="T:org.tmapi.core.ITopicMapSystem"/> 
        ///     and does not return the state (enabled/disabled) of the feature. 
        /// </summary>
        /// <param name="featureName">
        ///     The name of the feature to check.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the requested feature is supported, otherwise <c>false</c>.
        /// </returns>
        public abstract bool HasFeature(string featureName);

        /// <summary>
        ///     Obtain a new instance of a TopicMapSystemFactory.
        /// </summary>
        /// <returns>
        ///     A new instance of TopicMapSystemFactory.
        /// </returns>
        /// <exception cref="FactoryConfigurationException">
        ///     If instance cannot be instantiated.
        /// </exception>
        public abstract TopicMapSystemFactory NewInstance();

        /// <summary>
        ///     Creates a new <see cref="T:org.tmapi.core.ITopicMapSystem"/> instance using the currently 
        ///     configured factory parameters.
        /// </summary>
        /// <returns>
        ///     A new instance of a <see cref="T:org.tmapi.core.ITopicMapSystem"/>.
        /// </returns>
        /// <exception cref="TMAPIException">
        ///     If a <see cref="T:org.tmapi.core.ITopicMapSystem"/> cannot be created which satisfies the requested configuration.
        /// </exception>
        public abstract ITopicMapSystem NewTopicMapSystem();

        /// <summary>
        ///     Sets a particular feature in the underlying implementation of <see cref="T:org.tmapi.core.ITopicMapSystem"/>.
        ///     A list of the core features can be found at http://tmapi.org/features/. 
        /// </summary>
        /// <param name="featureName">
        ///     The name of the feature to be set.
        /// </param>
        /// <param name="enable">
        ///     <c>true</c> to enable the feature, <c>false</c> to disable it.
        /// </param>
        /// <exception cref="FeatureNotRecognizedException">
        ///     If the underlying implementation does not recognize the named feature.
        /// </exception>
        /// <exception cref="FeatureNotSupportedException">
        ///     If the underlying implementation recognizes the named feature but does not support enabling or 
        ///     disabling it (as specified by <paramref name="enable"/>).
        /// </exception>
        public abstract void SetFeature(string featureName, bool enable);

        /// <summary>
        ///     Sets a property in the underlying implementation of <see cref="T:org.tmapi.core.ITopicMapSystem"/>.
        ///     A list of the core properties defined by TMAPI can be found at http://tmapi.org/properties/.
        ///     An implementation is free to support properties other than the core ones. 
        /// </summary>
        /// <param name="propertyName">
        ///     The name of the property to be set.
        /// </param>
        /// <param name="value">
        ///     The value to be set of this property or <c>null</c> to remove the property from the current factory configuration.
        /// </param>
        public abstract void SetProperty(string propertyName, Object value);
    }
}