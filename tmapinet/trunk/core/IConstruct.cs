using System.Collections.ObjectModel;

namespace org.tmapi.core
{
	/// <summary>
	///     Base interface for all Topic Maps constructs.
	/// </summary>
	public interface IConstruct
	{
		#region Properties
		/// <summary>
		///     Gets the identifier of this construct.
		///     This property has no representation in the Topic Maps - Data Model.
		/// </summary>
		/// <returns>
		///     An identifier which identifies this construct uniquely within a topic map.
		/// </returns>
		string Id
		{
			get;
		}

		/// <summary>
		///     Gets the item identifiers of this Topic Maps construct.
		///     The return value may be empty but must never be <c>null</c>.
		/// </summary>
		/// <returns>
		///     An unmodifiable set of <see cref="T:org.tmapi.core.ILocator"/>s representing the item identifiers.
		/// </returns>
		ReadOnlyCollection<ILocator> ItemIdentifiers
		{
			get;
		}

		/// <summary>
		///     Gets the parent of this construct.
		///     This method returns <c>null</c> if this construct is a <see cref="T:org.tmapi.core.ITopicMap"/> instance.
		/// </summary>
		/// <returns>
		///     The parent of this construct or <c>null</c> if the construct is an instance 
		///     of <see cref="T:org.tmapi.core.ITopicMap"/>.
		/// </returns>
		IConstruct Parent
		{
			get;
		}

		/// <summary>
		///     Gets the <see cref="T:org.tmapi.core.ITopicMap"/> instance to which this Topic Maps construct
		///     belongs.
		///     A <see cref="T:org.tmapi.core.ITopicMap"/> instance returns itself. 
		/// </summary>
		/// <returns>
		///     The <see cref="T:org.tmapi.core.ITopicMap"/> instance to which this constructs belongs.
		/// </returns>
		ITopicMap TopicMap
		{
			get;
		}
		#endregion

		#region Methods
		/// <summary>
		///     Adds an item identifier.
		///     It is not allowed to have two <see cref="T:org.tmapi.core.IConstruct"/>s in the same 
		///     <see cref="T:org.tmapi.core.ITopicMap"/> with the same item identifier.
		///     If the two objects are <see cref="T:org.tmapi.core.ITopic"/>s, then they must be merged.
		///     If at least one of the two objects is not a <see cref="T:org.tmapi.core.ITopic"/>, 
		///     an <see cref="T:org.tmapi.core.IdentityConstraintException"/> must be reported.
		/// </summary>
		/// <param name="iid">
		///     The item identifier to be added; must not be <c>null</c>.
		/// </param>
		/// <exception cref="ModelConstraintException">
		///     If the <paramref name="iid"/> is <c>null</c>. 
		/// </exception>
		/// <exception cref="IdentityConstraintException">
		///     If another construct has an item identifier which is equal to <paramref name="iid"/>.
		/// </exception>
		void AddItemIdentifier(ILocator iid);

		/// <summary>
		///     Returns <c>true</c> if the <paramref name="other"/> object is equal to this one.
		///     Equality must be the result of comparing the ids of the two objects. If
		///     <paramref name="other"/> is not an instance of <see cref="T:org.tmapi.core.IConstruct"/>, 
		///     the return value is <c>false</c>.
		/// </summary>
		/// <param name="other">
		///     The object to compare this object against.
		/// </param>
		/// <returns>
		///     Returns <c>true</c> if the ids of the two objects are equal, <c>false</c> otherwise.
		/// </returns>
		/// <remarks>
		///     This equalitiy test does not reflect any equalitiy rule according to the 
		///     <a href="http://www.isotopicmaps.org/sam/sam-model/">Topic Maps - Data Model (TMDM)</a> 
		///     by intention.
		/// </remarks>
		bool Equals(object other);

		/// <summary>
		///     Returns a hash code value.
		///     The returned hash code is equal to the hash code of the <see cref="P:org.tmapi.core.IConstruct.Id"/> property.
		/// </summary>
		/// <returns>
		///     Hash code of the <see cref="P:org.tmapi.core.IConstruct.Id"/> property.
		/// </returns>
		int GetHashCode();

		/// <summary>
		///     Deletes this construct from its parent container.
		/// </summary>
		void Remove();

		/// <summary>
		///     Removes an item identifier.
		/// </summary>
		/// <param name="iid">
		///     The item identifier to be removed.
		/// </param>
		void RemoveItemIdentifier(ILocator iid);
		#endregion
	}
}