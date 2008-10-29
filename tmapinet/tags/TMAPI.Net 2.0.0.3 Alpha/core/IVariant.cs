using System.Collections.ObjectModel;

namespace org.tmapi.core {
	/// <summary>
	///     Represents a 
	///     <a href="http://www.isotopicmaps.org/sam/sam-model/#sect-variant">variant item</a>.
	/// </summary>
	public interface IVariant : IDatatypeAware {
        #region Properties
        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.IName"/> to which this variant belongs.
        /// </summary>
        /// <returns>
        ///     The <see cref="T:org.tmapi.core.IName"/> to which this variant belongs.
        /// </returns>
        new IName Parent { get; }

        /// <summary>
        ///     Returns the scope of this variant.
        ///     The returned scope is a true superset of the parent's scope.
        /// </summary>
        /// <returns>
        ///     An unmodifiable set of <see cref="T:org.tmapi.core.ITopic"/>s which define the scope.
        /// </returns>
        new ReadOnlyCollection<ITopic> Scope { get; }
        #endregion
	}
}