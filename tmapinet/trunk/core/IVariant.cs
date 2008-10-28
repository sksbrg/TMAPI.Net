using System.Collections.ObjectModel;

namespace org.tmapi.core
{
	/// <summary>
	///     Represents a 
	///     <a href="http://www.isotopicmaps.org/sam/sam-model/#sect-variant">variant item</a>.
	/// </summary>
	public interface IVariant : IDatatypeAware
	{
		#region Properties
		/// <summary>
		///     Gets the <see cref="T:org.tmapi.core.IName"/> to which this variant belongs.
		/// </summary>
		/// <returns>
		///     The <see cref="T:org.tmapi.core.IName"/> to which this variant belongs.
		/// </returns>
		new IName Parent
		{
			get;
		}

		/// <summary>
		///     Gets the scope of this variant.
		/// </summary>
		/// <remarks>
		///     The returned scope is a true superset of the parent's scope.
		/// </remarks>
		/// <returns>
		///     An unmodifiable set of <see cref="T:org.tmapi.core.ITopic"/>s which define the scope.
		/// </returns>
		new ReadOnlyCollection<ITopic> Scope
		{
			get;
		}
		#endregion
	}
}