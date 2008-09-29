using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace org.tmapi.core {
	/// <summary>
	///     Represents a 
	///     <a href="http://www.isotopicmaps.org/sam/sam-model/#d0e739">topic item</a>.
	/// </summary>
	public interface ITopic : IConstruct {
        #region Properties
        /// <summary>
        ///     Returns the types of which this topic is an instance of.
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <returns>
        ///     An unmodifiable set of <see cref="T:org.tmapi.core.ITopic"/>s.
        /// </returns>
        /// <remarks>
        ///     This method may return only those types which where added by <see cref="M:org.tmapi.core.ITopic.AddType"/> 
        ///     and may ignore <a href="http://www.isotopicmaps.org/sam/sam-model/#sect-types">type-instance</a> 
        ///     relationships which are modelled as association.
        /// </remarks>
        ReadOnlyCollection<ITopic> Types { get; }

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.IOccurrence"/>s of this topic.
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <returns>
        ///     An unmodifiable set of <see cref="T:org.tmapi.core.IOccurrence"/>s belonging to this topic.
        /// </returns>
        ReadOnlyCollection<IOccurrence> Occurrences { get; }

        /// <summary>
        ///     Returns the subject identifiers assigned to this topic.
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <returns>
        ///     An unmodifiable set of <see cref="T:org.tmapi.core.ILocator"/>s representing the subject identifiers.
        /// </returns>
        ReadOnlyCollection<ILocator> SubjectIdentifiers { get; }

        /// <summary>
        ///     Returns the subject locators assigned to this topic.
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <returns>
        ///     An unmodifiable set of <see cref="T:org.tmapi.core.ILocator"/>s representing the subject locators.
        /// </returns>
        ReadOnlyCollection<ILocator> SubjectLocators { get; }

        /// <summary>
        ///     Returns the names of this topic.
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <returns>
        ///     An unmodifiable set of <see cref="T:org.tmapi.core.IName"/>s belonging to this topic.
        /// </returns>
        ReadOnlyCollection<IName> Names { get; }

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.ITopicMap"/> to which this topic belongs.
        /// </summary>
        /// <returns>
        ///     The <see cref="T:org.tmapi.core.ITopicMap"/> to which this topic belongs.
        /// </returns>
        new ITopicMap Parent { get; }

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.IConstruct"/> which is reified by this topic.
        /// </summary>
        /// <returns>
        ///     The <see cref="T:org.tmapi.core.IReifiable"/> that is reified by this topic or 
        ///     <c>null</c> if this topic does not reify a statement.
        /// </returns>
        IReifiable Reified { get; }

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.IRole"/>s played by this topic.
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <returns>
        ///     An unmodifiable set of <see cref="T:org.tmapi.core.IRole"/>s played by this topic.
        /// </returns>
        ReadOnlyCollection<IRole> RolesPlayed { get; }
        #endregion

        #region Methods
        /// <summary>
        ///     Adds an item identifier to this topic.
        ///     If adding the specified item identifier would make this topic represent the same subject 
        ///     as another topic and the feature "automerge" (http://tmapi.org/features/automerge) is disabled, 
        ///     an <see cref="IdentityConstraintException"/> is thrown.
        /// </summary>
        /// <param name="iid">
        ///     The item identifier to be added; must not be <c>null</c>.
        /// </param>
        /// <exception cref="IdentityConstraintException">
        ///     If adding <paramref name="iid"/> would make this topic represent the same subject 
        ///     as another topic and the feature "automerge" (http://tmapi.org/features/automerge) is disabled.
        /// </exception>
        new void AddItemIdentifier(ILocator iid);

        /// <summary>
        ///     Adds a subject identifier to this topic.
        ///     If adding the specified subject identifier would make this topic represent the same subject 
        ///     as another topic and the feature "automerge" (http://tmapi.org/features/automerge) is disabled, 
        ///     an <see cref="IdentityConstraintException"/> is thrown.
        /// </summary>
        /// <param name="sid">
        ///     The subject identifier to be added; must not be <c>null</c>.
        /// </param>
        /// <exception cref="IdentityConstraintException">
        ///     If adding <paramref name="sid"/> would make this topic represent the same subject 
        ///     as another topic and the feature "automerge" (http://tmapi.org/features/automerge) is disabled.
        /// </exception>
        void AddSubjectIdentifier(ILocator sid);

        /// <summary>
        ///     Adds a subject locator to this topic.
        ///     If adding the specified subject locator would make this topic represent the same subject 
        ///     as another topic and the feature "automerge" (http://tmapi.org/features/automerge) is disabled, 
        ///     an <see cref="IdentityConstraintException"/> is thrown.
        /// </summary>
        /// <param name="slo">
        ///     The subject locator to be added; must not be <c>null</c>.
        /// </param>
        /// <exception cref="IdentityConstraintException">
        ///     If adding <paramref name="slo"/> would make this topic represent the same subject 
        ///     as another topic and the feature "automerge" (http://tmapi.org/features/automerge) is disabled.
        /// </exception>
        void AddSubjectLocator(ILocator slo);

        /// <summary>
        ///     Adds a type to this topic.
        ///     Implementations may or may not create an association for types added by this method. 
        ///     In any case, every type which was added by this method must be returned by the 
        ///     <see cref="P:org.tmapi.core.ITopic.Types"/> property.
        /// </summary>
        /// <param name="type">
        ///     The type of which this topic should become an instance of; must not be <c>null</c>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     If the <paramref name="type"/> is <c>null</c>.
        /// </exception>
        void AddType(ITopic type);

        /// <summary>
        ///     Creates a <see cref="T:org.tmapi.core.IName"/> for this topic with the specified <paramref name="type"/>, 
        ///     <paramref name="value"/>, and <paramref name="scope"/>.
        /// </summary>
        /// <param name="type">
        ///     The name type; MUST NOT be <c>null</c>.
        /// </param>
        /// <param name="value">
        ///     The string value of the name; MUST NOT be <c>null</c>.
        /// </param>
        /// <param name="scope">
        ///     An optional array of themes, MUST NOT be <c>null</c>.
        ///     If the array's length is <c>0</c>, the name will be in the unconstrained scope.
        /// </param>
        /// <returns>
        ///     The newly created <see cref="T:org.tmapi.core.IName"/>.
        /// </returns>
        /// <exception cref="ModelConstraintException">
        ///     If either the <paramref name="type"/>, the <paramref name="value"/>, 
        ///     or the <paramref name="scope"/> is <c>null</c>.
        /// </exception>
        IName CreateName(ITopic type, string value, params ITopic[] scope);

        /// <summary>
        ///     Creates a <see cref="T:org.tmapi.core.IName"/> for this topic with the specified <paramref name="type"/>, 
        ///     <paramref name="value"/>, and <paramref name="scope"/>.
        /// </summary>
        /// <param name="type">
        ///     The name type; MUST NOT be <c>null</c>.
        /// </param>
        /// <param name="value">
        ///     The string value of the name; MUST NOT be <c>null</c>.
        /// </param>
        /// <param name="scope">
        ///     A collection of themes or <c>null</c> if the name should be in the unconstrained scope.
        /// </param>
        /// <returns>
        ///     The newly created <see cref="T:org.tmapi.core.IName"/>.
        /// </returns>
        /// <exception cref="ModelConstraintException">
        ///     If either the <paramref name="type"/> or the <paramref name="value"/> is <c>null</c>.
        /// </exception>
        IName CreateName(ITopic type, string value, IList<ITopic> scope);

        /// <summary>
        ///     Creates a <see cref="T:org.tmapi.core.IName"/> for this topic with the specified <paramref name="value"/> 
        ///     and <paramref name="scope"/>.
        ///     The created <see cref="T:org.tmapi.core.IName"/> will have the default name type 
        ///     (a <see cref="T:org.tmapi.core.ITopic"/> with the subject identifier 
        ///     <a href="http://psi.topicmaps.org/iso13250/model/topic-name">http://psi.topicmaps.org/iso13250/model/topic-name</a>).
        /// </summary>
        /// <param name="value">
        ///     The string value of the name; MUST NOT be <c>null</c>.
        /// </param>
        /// <param name="scope">
        ///     An optional array of themes, MUST NOT be <c>null</c>.
        ///     If the array's length is <c>0</c>, the name will be in the unconstrained scope.
        /// </param>
        /// <returns>
        ///     The newly created <see cref="T:org.tmapi.core.IName"/>.
        /// </returns>
        /// <exception cref="ModelConstraintException">
        ///     If either the <paramref name="value"/> or the <paramref name="scope"/> is <c>null</c>.
        /// </exception>
        IName CreateName(string value, params ITopic[] scope);

        /// <summary>
        ///     Creates a <see cref="T:org.tmapi.core.IName"/> for this topic with the specified <paramref name="value"/> 
        ///     and <paramref name="scope"/>.
        ///     The created <see cref="T:org.tmapi.core.IName"/> will have the default name type 
        ///     (a <see cref="T:org.tmapi.core.ITopic"/> with the subject identifier 
        ///     <a href="http://psi.topicmaps.org/iso13250/model/topic-name">http://psi.topicmaps.org/iso13250/model/topic-name</a>).
        /// </summary>
        /// <param name="value">
        ///     The string value of the name; MUST NOT be <c>null</c>.
        /// </param>
        /// <param name="scope">
        ///     A collection of themes or <c>null</c> if the name should be in the unconstrained scope.
        /// </param>
        /// <returns>
        ///     The newly created <see cref="T:org.tmapi.core.IName"/>.
        /// </returns>
        /// <exception cref="ModelConstraintException">
        ///     If the <paramref name="value"/> is <c>null</c>.
        /// </exception>
        IName CreateName(string value, IList<ITopic> scope);

        /// <summary>
        ///     Creates a <see cref="T:org.tmapi.core.IOccurrence"/> for this topic with the specified <paramref name="type"/>, 
        ///     string <paramref name="value"/>, and <paramref name="scope"/>.
        ///     The newly created <see cref="T:org.tmapi.core.IOccurrence"/> will have the datatype 
        ///     <a href="http://www.w3.org/TR/xmlschema-2/#string">xsd:string</a>.
        /// </summary>
        /// <param name="type">
        ///     The occurrence type; MUST NOT be <c>null</c>.
        /// </param>
        /// <param name="value">
        ///     The string value of the occurrence.
        /// </param>
        /// <param name="scope">
        ///     An optional array of themes, MUST NOT be <c>null</c>.
        ///     If the array's length is <c>0</c>, the occurrence will be in the unconstrained scope.
        /// </param>
        /// <returns>
        ///     The newly created <see cref="T:org.tmapi.core.IOccurrence"/>.
        /// </returns>
        /// <exception cref="ModelConstraintException">
        ///     If either the <paramref name="type"/>, the <paramref name="value"/>, 
        ///     or the <paramref name="scope"/> is <c>null</c>.
        /// </exception>
        IOccurrence CreateOccurrence(ITopic type, string value, params ITopic[] scope);

        /// <summary>
        ///     Creates a <see cref="T:org.tmapi.core.IOccurrence"/> for this topic with the specified <paramref name="type"/>, 
        ///     string <paramref name="value"/>, and <paramref name="scope"/>.
        ///     The newly created <see cref="T:org.tmapi.core.IOccurrence"/> will have the datatype 
        ///     <a href="http://www.w3.org/TR/xmlschema-2/#string">xsd:string</a>.
        /// </summary>
        /// <param name="type">
        ///     The occurrence type; MUST NOT be <c>null</c>.
        /// </param>
        /// <param name="value">
        ///     The string value of the occurrence.
        /// </param>
        /// <param name="scope">
        ///     A collection of themes or <c>null</c> if the occurrence should be in the unconstrained scope.
        /// </param>
        /// <returns>
        ///     The newly created <see cref="T:org.tmapi.core.IOccurrence"/>.
        /// </returns>
        /// <exception cref="ModelConstraintException">
        ///     If either the <paramref name="type"/> or the <paramref name="value"/> is <c>null</c>.
        /// </exception>
        IOccurrence CreateOccurrence(ITopic type, string value, IList<ITopic> scope);

        /// <summary>
        ///     Creates a <see cref="T:org.tmapi.core.IOccurrence"/> for this topic with the specified <paramref name="type"/>, 
        ///     IRI <paramref name="value"/>, and <paramref name="scope"/>.
        ///     The newly created <see cref="T:org.tmapi.core.IOccurrence"/> will have the datatype 
        ///     <a href="http://www.w3.org/TR/xmlschema-2/#anyURI">xsd:anyURI</a>.
        /// </summary>
        /// <param name="type">
        ///     The occurrence type; MUST NOT be <c>null</c>.
        /// </param>
        /// <param name="value">
        ///     A <see cref="T:org.tmapi.core.ILocator"/> which represents an IRI.
        /// </param>
        /// <param name="scope">
        ///     An optional array of themes, MUST NOT be <c>null</c>.
        ///     If the array's length is <c>0</c>, the occurrence will be in the unconstrained scope.
        /// </param>
        /// <returns>
        ///     The newly created <see cref="T:org.tmapi.core.IOccurrence"/>.
        /// </returns>
        /// <exception cref="ModelConstraintException">
        ///     If either the <paramref name="type"/>, the <paramref name="value"/>, 
        ///     or the <paramref name="scope"/> is <c>null</c>.
        /// </exception>
        IOccurrence CreateOccurrence(ITopic type, ILocator value, params ITopic[] scope);

        /// <summary>
        ///     Creates a <see cref="T:org.tmapi.core.IOccurrence"/> for this topic with the specified <paramref name="type"/>, 
        ///     IRI <paramref name="value"/>, and <paramref name="scope"/>.
        ///     The newly created <see cref="T:org.tmapi.core.IOccurrence"/> will have the datatype 
        ///     <a href="http://www.w3.org/TR/xmlschema-2/#anyURI">xsd:anyURI</a>.
        /// </summary>
        /// <param name="type">
        ///     The occurrence type; MUST NOT be <c>null</c>.
        /// </param>
        /// <param name="value">
        ///     A <see cref="T:org.tmapi.core.ILocator"/> which represents an IRI.
        /// </param>
        /// <param name="scope">
        ///     A collection of themes or <c>null</c> if the occurrence should be in the unconstrained scope.
        /// </param>
        /// <returns>
        ///     The newly created <see cref="T:org.tmapi.core.IOccurrence"/>.
        /// </returns>
        /// <exception cref="ModelConstraintException">
        ///     If either the <paramref name="type"/> or the <paramref name="value"/> is <c>null</c>.
        /// </exception>
        IOccurrence CreateOccurrence(ITopic type, ILocator value, IList<ITopic> scope);

        /// <summary>
        ///     Creates a <see cref="T:org.tmapi.core.IOccurrence"/> for this topic with the specified <paramref name="type"/>, 
        ///     string <paramref name="value"/>, <paramref name="datatype"/> and <paramref name="scope"/>.
        ///     The newly created <see cref="T:org.tmapi.core.IOccurrence"/> will have the datatype 
        ///     specified by <paramref name="datatype"/>.
        /// </summary>
        /// <param name="type">
        ///     The occurrence type; MUST NOT be <c>null</c>.
        /// </param>
        /// <param name="value">
        ///     The string value of the occurrence.
        /// </param>
        /// <param name="datatype">
        ///     A <see cref="T:org.tmapi.core.ILocator"/> indicating the datatype of the <paramref name="value"/>.
        /// </param>
        /// <param name="scope">
        ///     An optional array of themes, MUST NOT be <c>null</c>.
        ///     If the array's length is <c>0</c>, the occurrence will be in the unconstrained scope.
        /// </param>
        /// <returns>
        ///     The newly created <see cref="T:org.tmapi.core.IOccurrence"/>.
        /// </returns>
        /// <exception cref="ModelConstraintException">
        ///     If either the <paramref name="type"/>, the <paramref name="value"/>, 
        ///     the <paramref name="datatype"/> or the <paramref name="scope"/> is <c>null</c>.
        /// </exception>
        IOccurrence CreateOccurrence(ITopic type, string value, ILocator datatype, params ITopic[] scope);

        /// <summary>
        ///     Creates a <see cref="T:org.tmapi.core.IOccurrence"/> for this topic with the specified <paramref name="type"/>, 
        ///     string <paramref name="value"/>, <paramref name="datatype"/> and <paramref name="scope"/>.
        ///     The newly created <see cref="T:org.tmapi.core.IOccurrence"/> will have the datatype 
        ///     specified by <paramref name="datatype"/>.
        /// </summary>
        /// <param name="type">
        ///     The occurrence type; MUST NOT be <c>null</c>.
        /// </param>
        /// <param name="value">
        ///     The string value of the occurrence.
        /// </param>
        /// <param name="datatype">
        ///     A <see cref="T:org.tmapi.core.ILocator"/> indicating the datatype of the <paramref name="value"/>.
        /// </param>
        /// <param name="scope">
        ///     A collection of themes or <c>null</c> if the occurrence should be in the unconstrained scope.
        /// </param>
        /// <returns>
        ///     The newly created <see cref="T:org.tmapi.core.IOccurrence"/>.
        /// </returns>
        /// <exception cref="ModelConstraintException">
        ///     If either the <paramref name="type"/>, the <paramref name="value"/> 
        ///     or the <paramref name="datatype"/> is <c>null</c>.
        /// </exception>
        IOccurrence CreateOccurrence(ITopic type, string value, ILocator datatype, IList<ITopic> scope);

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.IName"/>s of this topic where the name type is <paramref name="type"/>.
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <param name="type">
        ///     The type of the <see cref="T:org.tmapi.core.IName"/>s to be returned; must not be <c>null</c>.
        /// </param>
        /// <returns>
        ///     An unmodifiable set of <see cref="T:org.tmapi.core.IName"/>s with the specified <paramref name="type"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     If the <paramref name="type"/> is <c>null</c>.
        /// </exception>
        ReadOnlyCollection<IName> GetNames(ITopic type);

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.IOccurrence"/>s of this topic where the occurrence type is <paramref name="type"/>.
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <param name="type">
        ///     The type of the <see cref="T:org.tmapi.core.IOccurrence"/>s to be returned; must not be <c>null</c>.
        /// </param>
        /// <returns>
        ///     An unmodifiable set of <see cref="T:org.tmapi.core.IOccurrence"/>s with the specified <paramref name="type"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     If the <paramref name="type"/> is <c>null</c>.
        /// </exception>
        ReadOnlyCollection<IOccurrence> GetOccurrences(ITopic type);

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.IRole"/>s played by this topic where the role type is <paramref name="type"/>.
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <param name="type">
        ///     The type of the <see cref="T:org.tmapi.core.IRole"/>s to be returned; must not be <c>null</c>.
        /// </param>
        /// <returns>
        ///     An unmodifiable set of <see cref="T:org.tmapi.core.IRole"/>s with the specified <paramref name="type"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     If the <paramref name="type"/> is <c>null</c>.
        /// </exception>
        ReadOnlyCollection<IRole> GetRolesPlayed(ITopic type);

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.IRole"/>s played by this topic where the role type is <paramref name="type"/> 
        ///     and the <see cref="T:org.tmapi.core.IAssociation"/> type is <paramref name="assocType"/>.
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <param name="type">
        ///     The type of the <see cref="T:org.tmapi.core.IRole"/>s to be returned; must not be <c>null</c>.
        /// </param>
        /// <param name="assocType">
        ///     The type of the <see cref="T:org.tmapi.core.IAssociation"/> from which the returned roles must be part of; 
        ///     must not be <c>null</c>.
        /// </param>
        /// <returns>
        ///     An unmodifiable set of <see cref="T:org.tmapi.core.IRole"/>s with the specified <paramref name="type"/> 
        ///     which are part of <see cref="T:org.tmapi.core.IAssociation"/>s with the specified <paramref name="assocType"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     If the <paramref name="type"/> or <paramref name="assocType"/> is <c>null</c>.
        /// </exception>
        ReadOnlyCollection<IRole> GetRolesPlayed(ITopic type, ITopic assocType);

        /// <summary>
        ///     Merges another topic into this topic.
        ///     Merging a topic into this topic causes this topic to gain all of the characteristics 
        ///     of the other topic and to replace the other topic wherever it is used as type, theme, or reifier. 
        ///     After this method completes, <paramref name="other"/> will have been removed from the <see cref="T:org.tmapi.core.ITopicMap"/>.
        /// </summary>
        /// <param name="other">
        ///     The topic to be merged into this topic.
        /// </param>
        /// <remarks>
        ///     The other topic MUST belong to the same <see cref="T:org.tmapi.core.ITopicMap"/> instance as this topic!
        /// </remarks>
        void MergeIn(ITopic other);

        /// <summary>
        ///     Removes this topic from the containing <see cref="T:org.tmapi.core.ITopicMap"/> instance.
        /// </summary>
        /// <exception cref="TopicInUseException">
        ///     If the topic plays a <see cref="T:org.tmapi.core.IRole"/>, is used as type of a 
        ///     <see cref="T:org.tmapi.core.ITyped"/> construct, or if it is used as theme for a 
        ///     <see cref="T:org.tmapi.core.IScoped"/> construct, or if it reifies a <see cref="T:org.tmapi.core.IReifiable"/>.
        /// </exception>
        new void Remove();

        /// <summary>
        ///     Removes a subject identifier from this topic.
        /// </summary>
        /// <param name="sid">
        ///     The subject identifier t be removed.
        /// </param>
        void RemoveSubjectIdentifier(ILocator sid);

        /// <summary>
        ///     Removes a subject locator from this topic.
        /// </summary>
        /// <param name="slo">
        ///     The subject locator to be removed.
        /// </param>
        void RemoveSubjectLocator(ILocator slo);

        /// <summary>
        ///     Removes a type from this topic.
        /// </summary>
        /// <param name="type">
        ///     The type to remove.
        /// </param>
        void RemoveType(ITopic type);
        #endregion
	}
}