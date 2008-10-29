using System.Collections.ObjectModel;
using org.tmapi.core;

namespace org.tmapi.index {
	/// <summary>
    ///     Index for type-instance relationships between <see cref="T:org.tmapi.core.ITopic"/>s 
    ///     and for <see cref="T:org.tmapi.core.ITyped"/> Topic Maps constructs. 
    ///     This index provides access to <see cref="T:org.tmapi.core.ITopic"/>s used in
	///     <a href="http://www.isotopicmaps.org/sam/sam-model/#sect-types">type-
    ///     instance</a> relationships or as type of a <see cref="T:org.tmapi.core.ITyped"/>
    ///     construct. Futher, the retrieval of <see cref="T:org.tmapi.core.IAssociation"/>s, 
    ///     <see cref="T:org.tmapi.core.IRole"/>s, <see cref="T:org.tmapi.core.IOccurrence"/>s, 
    ///     and <see cref="T:org.tmapi.core.IName"/>s by their <c>type</c> property is supported.
	/// </summary>
	public interface ITypeInstanceIndex : IIndex {
        #region Properties
        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.ITopic"/>s in the topic map used 
        ///     in the type property of <see cref="T:org.tmapi.core.IAssociation"/>s. 
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <returns>
        ///     An unmodifiable collection of <see cref="T:org.tmapi.core.ITopic"/>s.
        /// </returns>
        ReadOnlyCollection<ITopic> AssociationTypes { get; }

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.ITopic"/>s in the topic map used 
        ///     in the type property of <see cref="T:org.tmapi.core.IName"/>s. 
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <returns>
        ///     An unmodifiable collection of <see cref="T:org.tmapi.core.ITopic"/>s.
        /// </returns>
        ReadOnlyCollection<ITopic> NameTypes { get; }

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.ITopic"/>s in the topic map used 
        ///     in the type property of <see cref="T:org.tmapi.core.IOccurrence"/>s. 
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <returns>
        ///     An unmodifiable collection of <see cref="T:org.tmapi.core.ITopic"/>s.
        /// </returns>
        ReadOnlyCollection<ITopic> OccurrenceTypes { get; }

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.ITopic"/>s in the topic map used 
        ///     in the type property of <see cref="T:org.tmapi.core.IRole"/>s. 
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <returns>
        ///     An unmodifiable collection of <see cref="T:org.tmapi.core.ITopic"/>s.
        /// </returns>
        ReadOnlyCollection<ITopic> RoleTypes { get; }

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.ITopic"/>s in topic map which are used 
        ///     as type in an "type-instance"-relationship. 
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <returns>
        ///     An unmodifiable collection of <see cref="T:org.tmapi.core.ITopic"/>s.
        /// </returns>
        /// <remarks>
        ///     Implementations may return only those topics which are member of the <c>types</c> 
        ///     property of other topics and may ignore <a href="http://www.isotopicmaps.org/sam/sam-model/#sect-types">
        ///     type-instance</a> relationships which are modelled as association. 
        ///     Further, <a href="http://www.isotopicmaps.org/sam/sam-model/#sect-subtypes">supertype-
        ///     subtype</a> relationships may also be ignored.
        /// </remarks>
        ReadOnlyCollection<ITopic> TopicTypes { get; }
        #endregion

        #region Methods
        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.IAssociation"/>s in the topic map whose 
        ///     type property equals <paramref name="type"/>. 
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <param name="type">
        ///     The type of the <see cref="T:org.tmapi.core.IAssociation"/>s to be returned.
        /// </param>
        /// <returns>
        ///     An unmodifiable collection of <see cref="T:org.tmapi.core.IAssociation"/>s.
        /// </returns>
        ReadOnlyCollection<IAssociation> GetAssociations(ITopic type);

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.IName"/>s in the topic map whose 
        ///     type property equals <paramref name="type"/>. 
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <param name="type">
        ///     The type of the <see cref="T:org.tmapi.core.IName"/>s to be returned.
        /// </param>
        /// <returns>
        ///     An unmodifiable collection of <see cref="T:org.tmapi.core.IName"/>s.
        /// </returns>
        ReadOnlyCollection<IName> GetNames(ITopic type);

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.IOccurrence"/>s in the topic map whose 
        ///     type property equals <paramref name="type"/>. 
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <param name="type">
        ///     The type of the <see cref="T:org.tmapi.core.IOccurrence"/>s to be returned.
        /// </param>
        /// <returns>
        ///     An unmodifiable collection of <see cref="T:org.tmapi.core.IOccurrence"/>s.
        /// </returns>
        ReadOnlyCollection<IOccurrence> GetOccurrences(ITopic type);

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.IRole"/>s in the topic map whose 
        ///     type property equals <paramref name="type"/>. 
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <param name="type">
        ///     The type of the <see cref="T:org.tmapi.core.IRole"/>s to be returned.
        /// </param>
        /// <returns>
        ///     An unmodifiable collection of <see cref="T:org.tmapi.core.IRole"/>s.
        /// </returns>
        ReadOnlyCollection<IRole> GetRoles(ITopic type);

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.ITopic"/>s which are an instance of 
        ///     the specified <paramref name="type"/>. 
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <param name="type">
        ///     The type of the <see cref="T:org.tmapi.core.ITopic"/>s to be returned.
        /// </param>
        /// <returns>
        ///     An unmodifiable collection of <see cref="T:org.tmapi.core.ITopic"/>s.
        /// </returns>
        /// <remarks>
        ///     Implementations may return only those topics whose <tt>types</tt> property
        ///     contains the type and may ignore <a href="http://www.isotopicmaps.org/sam/sam-model/#sect-types">
        ///     type-instance</a> relationships which are modelled as association. Further, 
        ///     <a href="http://www.isotopicmaps.org/sam/sam-model/#sect-subtypes">supertype-
        ///     subtype</a> relationships may also be ignored. 
        /// </remarks>
        ReadOnlyCollection<ITopic> GetTopics(ITopic type);

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.ITopic"/>s in the topic map whose type 
        ///     property equals one of those <paramref name="types"/> at least. 
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <param name="types">
        ///     Types of the <see cref="T:org.tmapi.core.ITopic"/>s to be returned.
        /// </param>
        /// <param name="matchAll">
        ///     If <c>true</c>, a topic must be an instance of all <paramref name="types"/>, 
        ///     if <c>false</c> the topic must be an instance of one type at least.
        /// </param>
        /// <returns>
        ///     An unmodifiable collection of <see cref="T:org.tmapi.core.ITopic"/>s.
        /// </returns>
        /// <remarks>
        ///     Implementations may return only those topics whose <tt>types</tt> property
        ///     contains the type and may ignore <a href="http://www.isotopicmaps.org/sam/sam-model/#sect-types">
        ///     type-instance</a> relationships which are modelled as association. Further, 
        ///     <a href="http://www.isotopicmaps.org/sam/sam-model/#sect-subtypes">supertype-
        ///     subtype</a> relationships may also be ignored. 
        /// </remarks>
        ReadOnlyCollection<ITopic> GetTopics(ITopic[] types, bool matchAll);
        #endregion
	}
}