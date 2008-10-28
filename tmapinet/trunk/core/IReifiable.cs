namespace org.tmapi.core
{
	/// <summary>
	///     Indicates that a <see cref="T:org.tmapi.core.IConstruct"/> is reifiable.
	///     Every Topic Maps construct that is not a <see cref="T:org.tmapi.core.ITopic"/> is reifiable.
	/// </summary>
	public interface IReifiable : IConstruct
	{
		#region Properties
		/// <summary>
		///     Gets or sets the reifier of this construct.
		/// </summary>
		/// <remarks>
		///     <list type="bullet">
		///         <item>If this construct is not reified <c>null</c> is returned.</item>
		///         <item>If the reifier is set to <c>null</c> an existing reifier should be removed.</item>
		///         <item>The reifier of this construct MUST NOT reify another information item.</item>
		///     </list>
		/// </remarks>
		ITopic Reifier
		{
			get;
			set;
		}
		#endregion
	}
}