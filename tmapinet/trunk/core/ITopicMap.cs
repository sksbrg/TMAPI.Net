using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using org.tmapi.index;

namespace org.tmapi.core
{
	/// <summary>
	///     Represents a 
	///     <a href="http://www.isotopicmaps.org/sam/sam-model/#d0e657">topic map item</a>.
	/// </summary>
	public interface ITopicMap : IReifiable
	{
		#region Properties
		/// <summary>
		///     Gets all <see cref="T:org.tmapi.core.IAssociation"/>s contained in this topic map.
		///     The return value may be empty but must never be <c>null</c>.
		/// </summary>
		/// <returns>
		///     An unmodifiable set of <see cref="T:org.tmapi.core.IAssociation"/>s.
		/// </returns>
		ReadOnlyCollection<IAssociation> Associations
		{
			get;
		}

		/// <summary>
		///     Gets <c>null</c> since topic maps do not have a parent.
		/// </summary>
		/// <returns>
		///     <c>null</c> since topic maps do not have a parent.
		/// </returns>
		new IConstruct Parent
		{
			get;
		}

		/// <summary>
		///     Gets all <see cref="T:org.tmapi.core.ITopic"/>s contained in this topic map.
		///     The return value may be empty but must never be <c>null</c>.
		/// </summary>
		/// <returns>
		///     An unmodifiable set of <see cref="T:org.tmapi.core.ITopic"/>s.
		/// </returns>
		ReadOnlyCollection<ITopic> Topics
		{
			get;
		}
		#endregion

		#region Methods
		/// <summary>
		///     Closes use of this topic map instance.
		///     This method should be invoked by the application once it is finished using this topic map instance.
		///     Implementations may release any resources required for the <c>TopicMap</c> instance or any of 
		///     the <see cref="T:org.tmapi.core.IConstruct"/> instances contained by this instance.
		/// </summary>
		void Close();

		/// <summary>
		///     Creates an <see cref="T:org.tmapi.core.IAssociation"/> in this topic map with the specified 
		///     <paramref name="type"/> and <paramref name="scope"/>.
		/// </summary>
		/// <param name="type">
		///     The association type, MUST NOT be <c>null</c>.
		/// </param>
		/// <param name="scope">
		///     An optional array of themes, MUST NOT be <c>null</c>.
		///     If the array's length is <c>0</c>, the association will be in the unconstrained scope.
		/// </param>
		/// <returns>
		///     The newly created <see cref="T:org.tmapi.core.IAssociation"/>.
		/// </returns>
		/// <exception cref="ModelConstraintException">
		///     If either the <paramref name="type"/> or <paramref name="scope"/> is <c>null</c>.
		/// </exception>
		IAssociation CreateAssociation(ITopic type, params ITopic[] scope);

		/// <summary>
		///     Creates an <see cref="T:org.tmapi.core.IAssociation"/> in this topic map with the specified 
		///     <paramref name="type"/> and <paramref name="scope"/>.
		/// </summary>
		/// <param name="type">
		///     The association type, MUST NOT be <c>null</c>.
		/// </param>
		/// <param name="scope">
		///     A collection of themes or <c>null</c> if the association should be in the unconstrained scope.
		/// </param>
		/// <returns>
		///     The newly created <see cref="T:org.tmapi.core.IAssociation"/>.
		/// </returns>
		/// <exception cref="ModelConstraintException">
		///     If the <paramref name="type"/> is <c>null</c>.
		/// </exception>
		IAssociation CreateAssociation(ITopic type, IList<ITopic> scope);

		/// <summary>
		///     Returns a <see cref="T:org.tmapi.core.ILocator"/> instance representing the specified IRI 
		///     <paramref name="reference"/>.  
		///     The specified IRI <paramref name="reference"/> is assumed to be absolute.
		/// </summary>
		/// <param name="reference">
		///     A string which uses the IRI notation.
		/// </param>
		/// <returns>
		///     A <see cref="T:org.tmapi.core.ILocator"/> representing the IRI <paramref name="reference"/>.
		/// </returns>
		ILocator CreateLocator(string reference);

		/// <summary>
		///     Returns a <see cref="T:org.tmapi.core.ITopic"/> instance with an automatically generated item identifier.
		///     This method returns never an existing <see cref="T:org.tmapi.core.ITopic"/> but creates a new one 
		///     with an automatically generated item identifier.
		///     How that item identifier is generated depends on the implementation.
		/// </summary>
		/// <returns>
		///     The newly created <see cref="T:org.tmapi.core.ITopic"/> instance with an automatically generated item identifier.
		/// </returns>
		ITopic CreateTopic();

		/// <summary>
		///     Returns a <see cref="T:org.tmapi.core.ITopic"/> instance with the specified item identifier.
		///     This method returns either an existing <see cref="T:org.tmapi.core.ITopic"/> or creates a new 
		///     <see cref="T:org.tmapi.core.ITopic"/> instance with the specified item identifier.
		///     If a topic with the specified item identifier exists in the topic map, that topic is returned. If a topic 
		///     with a subject identifier equals to the specified item identifier exists, the specified item identifier 
		///     is added to that topic and the topic is returned. If neither a topic with the specified item identifier 
		///     nor with a subject identifier equals to the item identifier exists, a topic with the item identifier is created.
		/// </summary>
		/// <param name="itemIdentifier">
		///     The item identifier the topic should contain.
		/// </param>
		/// <returns>
		///     A <see cref="T:org.tmapi.core.ITopic"/> instance with the specified item identifier.
		/// </returns>
		/// <exception cref="ModelConstraintException">
		///     If the item identifier <paramref name="itemIdentifier"/> is <c>null</c>.
		/// </exception>
		/// <exception cref="IdentityConstraintException">
		///     If an other <see cref="T:org.tmapi.core.IConstruct"/> with the specified item identifier exists which is 
		///     not a <see cref="T:org.tmapi.core.ITopic"/>. 
		/// </exception>
		ITopic CreateTopicByItemIdentifier(ILocator itemIdentifier);

		/// <summary>
		///     Returns a <see cref="T:org.tmapi.core.ITopic"/> instance with the specified subject identifier.
		///     This method returns either an existing <see cref="T:org.tmapi.core.ITopic"/> or creates a new 
		///     <see cref="T:org.tmapi.core.ITopic"/> instance with the specified subject identifier.
		///     If a topic with the specified subject identifier exists in the topic map, that topic is returned. If a topic 
		///     with an item identifier equals to the specified subject identifier exists, the specified subject identifier 
		///     is added to that topic and the topic is returned. If neither a topic with the specified subject identifier 
		///     nor with an item identifier equals to the subject identifier exists, a topic with the subject identifier is created.
		/// </summary>
		/// <param name="subjectIdentifier">
		///     The subject identifier the topic should contain.
		/// </param>
		///  <returns>
		///     A <see cref="T:org.tmapi.core.ITopic"/> instance with the specified subject identifier.
		/// </returns>
		/// <exception cref="ModelConstraintException">
		///     If the subject identifier <paramref name="subjectIdentifier"/> is <c>null</c>.
		/// </exception>
		ITopic CreateTopicBySubjectIdentifier(ILocator subjectIdentifier);

		/// <summary>
		///     Returns a <see cref="T:org.tmapi.core.ITopic"/> instance with the specified subject locator.
		///     This method returns either an existing <see cref="T:org.tmapi.core.ITopic"/> or creates a new 
		///     <see cref="T:org.tmapi.core.ITopic"/> instance with the specified subject locator.
		/// </summary>
		/// <param name="subjectLocator">
		///     The subject locator the topic should contain.
		/// </param>
		/// <returns>
		///     A <see cref="T:org.tmapi.core.ITopic"/> instance with the specified subject locator.
		/// </returns>
		///  <exception cref="ModelConstraintException">
		///     If the subject locator <paramref name="subjectLocator"/> is <c>null</c>.
		/// </exception>
		ITopic CreateTopicBySubjectLocator(ILocator subjectLocator);

		/// <summary>
		///     Returns a <see cref="T:org.tmapi.core.IConstruct"/> by its (system specific) identifier.
		/// </summary>
		/// <param name="id">
		///     The identifier of the construct to be returned.
		/// </param>
		/// <returns>
		///     The construct with the specified id or <c>null</c> if such a construct is unknown.
		/// </returns>
		IConstruct GetConstructById(string id);

		/// <summary>
		///     Returns a <see cref="T:org.tmapi.core.IConstruct"/> by its item identifier.
		/// </summary>
		/// <param name="itemIdentifier">
		///     The item identifier of the construct to be returned.
		/// </param>
		/// <returns>
		///     A construct with the specified item identifier or <c>null</c> if no such construct exists in the topic map.
		/// </returns>
		IConstruct GetConstructByItemIdentifier(ILocator itemIdentifier);

		/// <summary>
		///     Returns an index instance for this topic map using the specified generic type.
		/// </summary>
		/// <typeparam name="T">
		///     The data type of the index for this topic map.
		/// </typeparam>
		/// <returns>
		///     The index instance for this topic map.
		/// </returns>
		/// <exception cref="NotSupportedException">
		///     If the implementation does not support indices or if the specified index is unsupported.
		/// </exception>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "As discussed in http://social.msdn.microsoft.com/Forums/en-US/vstscode/thread/81f356fd-3821-47bd-ad30-c0a6b70aade5/ there is no better solution.")]
		T GetIndex<T>() where T : IIndex;

		/// <summary>
		///     Returns a topic by its subject identifier.
		/// </summary>
		/// <param name="subjectIdentifier">
		///     The subject identifier of the topic to be returned.
		/// </param>
		/// <returns>
		///     A topic with the specified subject identifier or <c>null</c> if no such topic exists in the topic map.
		/// </returns>
		ITopic GetTopicBySubjectIdentifier(ILocator subjectIdentifier);

		/// <summary>
		///     Returns a topic by its subject locator.
		/// </summary>
		/// <param name="subjectLocator">
		///     The subject locator of the topic to be returned.
		/// </param>
		/// <returns>
		///     A topic with the specified subject locator or <c>null</c> if no such topic exists in the topic map.
		/// </returns>
		ITopic GetTopicBySubjectLocator(ILocator subjectLocator);

		/// <summary>
		///     Merges the topic map <paramref name="other"/> into this topic map.
		///     All <see cref="T:org.tmapi.core.ITopic"/>s and <see cref="T:org.tmapi.core.IAssociation"/>s and all of 
		///     their contents in <paramref name="other"/> will be added to this topic map.
		///     All information items in <paramref name="other"/> will be merged into this topic map as defined by the 
		///     <a href="http://www.isotopicmaps.org/sam/sam-model/#d0e1862">Topic Maps - Data Model (TMDM) merging rules</a>.
		///     The merge process will not modify <paramref name="other"/> in any way.
		/// </summary>
		/// <param name="other">
		///     The topic map to be merged with this topic map instance.
		/// </param>
		void MergeIn(ITopicMap other);
		#endregion
	}
}