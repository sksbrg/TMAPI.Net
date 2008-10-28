namespace org.tmapi.core
{
	/// <summary>
	///     Indicates that a Topic Maps construct is typed.
	///     <see cref="T:org.tmapi.core.IAssociation"/>s, <see cref="T:org.tmapi.core.IRole"/>s, 
	///     <see cref="T:org.tmapi.core.IOccurrence"/>s, and <see cref="T:org.tmapi.core.IName"/>s are typed.
	/// </summary>
	public interface ITyped : IConstruct
	{
		#region Properties
		/// <summary>
		///     Gets or sets the type of this construct.
		/// </summary>
		/// <exception cref="ModelConstraintException">
		///     If the type is <c>null</c>.
		/// </exception>
		/// <remarks>
		///     Any previous type is overridden.
		/// </remarks>
		ITopic Type
		{
			get;
			set;
		}
		#endregion
	}
}