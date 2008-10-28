using System.Collections.ObjectModel;

namespace org.tmapi.core
{
	/// <summary>
	///     Indicates that a statement (Topic Maps construct) has a scope.
	///     <see cref="T:org.tmapi.core.IAssociation"/>s, <see cref="T:org.tmapi.core.IOccurrence"/>s, 
	///     <see cref="T:org.tmapi.core.IName"/>s, and <see cref="T:org.tmapi.core.IVariant"/>s are scoped.
	/// </summary>
	public interface IScoped : IConstruct
	{
		#region Properties
		/// <summary>
		///     Gets the <see cref="T:org.tmapi.core.ITopic"/>s which define the scope.
		///     An empty set represents the unconstrained scope.
		///     The return value may be empty but must never be <c>null</c>.
		/// </summary>
		/// <returns>
		///     An unmodifiable set of <see cref="T:org.tmapi.core.ITopic"/>s which define the scope.
		/// </returns>
		ReadOnlyCollection<ITopic> Scope
		{
			get;
		}
		#endregion

		#region Methods
		/// <summary>
		///     Adds a <see cref="T:org.tmapi.core.ITopic"/> to the scope.
		/// </summary>
		/// <param name="theme">
		///     The <see cref="T:org.tmapi.core.ITopic"/> which should be added to the scope.
		/// </param>
		/// <exception cref="ModelConstraintException">
		///     If the <paramref name="theme"/> is <c>null</c>.
		/// </exception>
		void AddTheme(ITopic theme);

		/// <summary>
		///     Removes a <see cref="T:org.tmapi.core.ITopic"/> from the scope.
		/// </summary>
		/// <param name="theme">
		///     The <see cref="T:org.tmapi.core.ITopic"/> which should be removed from the scope.
		/// </param>
		void RemoveTheme(ITopic theme);
		#endregion
	}
}