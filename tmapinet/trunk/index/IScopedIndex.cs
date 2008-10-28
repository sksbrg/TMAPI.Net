using System.Collections.ObjectModel;
using org.tmapi.core;

namespace org.tmapi.index
{
	/// <summary>
	///     Index for <see cref="T:org.tmapi.core.IScoped"/> statements and their scope. 
	///     This index provides access to <see cref="T:org.tmapi.core.IAssociation"/>s, 
	///     <see cref="T:org.tmapi.core.IOccurrence"/>s, <see cref="T:org.tmapi.core.IName"/>s, 
	///     and <see cref="T:org.tmapi.core.IVariant"/>s by their scope property and to 
	///     <see cref="T:org.tmapi.core.ITopic"/>s which are used as theme in a scope.
	/// </summary>
	public interface IScopedIndex : IIndex
	{
		#region Properties
		/// <summary>
		///     Gets the <see cref="T:org.tmapi.core.ITopic"/>s in the topic map used 
		///     in the scope property of <see cref="T:org.tmapi.core.IAssociation"/>s. 
		///     The return value may be empty but must never be <c>null</c>.
		/// </summary>
		/// <returns>
		///     An unmodifiable collection of <see cref="T:org.tmapi.core.ITopic"/>s.
		/// </returns>
		ReadOnlyCollection<ITopic> AssociationThemes
		{
			get;
		}

		/// <summary>
		///     Gets the <see cref="T:org.tmapi.core.ITopic"/>s in the topic map used 
		///     in the scope property of <see cref="T:org.tmapi.core.IName"/>s. 
		///     The return value may be empty but must never be <tt>null</tt>.
		/// </summary>
		/// <returns>
		///     An unmodifiable collection of <see cref="T:org.tmapi.core.ITopic"/>s.
		/// </returns>
		ReadOnlyCollection<ITopic> NameThemes
		{
			get;
		}

		/// <summary>
		///     Gets the <see cref="T:org.tmapi.core.ITopic"/>s in the topic map used 
		///     in the scope property of <see cref="T:org.tmapi.core.IOccurrence"/>s. 
		///     The return value may be empty but must never be <tt>null</tt>.
		/// </summary>
		/// <returns>
		///     An unmodifiable collection of <see cref="T:org.tmapi.core.ITopic"/>s.
		/// </returns>
		ReadOnlyCollection<ITopic> OccurrenceThemes
		{
			get;
		}

		/// <summary>
		///     Gets the <see cref="T:org.tmapi.core.ITopic"/>s in the topic map used 
		///     in the scope property of <see cref="T:org.tmapi.core.IVariant"/>s. 
		///     The return value may be empty but must never be <c>null</c>.
		/// </summary>
		/// <returns>
		///     An unmodifiable collection of <see cref="T:org.tmapi.core.ITopic"/>s.
		/// </returns>
		ReadOnlyCollection<ITopic> VariantThemes
		{
			get;
		}
		#endregion

		#region Methods
		/// <summary>
		///     Returns the <see cref="T:org.tmapi.core.IAssociation"/>s in the topic map whose 
		///     scope property contains the specified <paramref name="theme"/>. 
		///     The return value may be empty but must never be <c>null</c>.
		/// </summary>
		/// <param name="theme">
		///     <see cref="T:org.tmapi.core.ITopic"/> which must be part of the scope. 
		///     If it is <c>null</c> all <see cref="T:org.tmapi.core.IAssociation"/>s in the 
		///     unconstrained scope are returned.
		/// </param>
		/// <returns>
		///     An unmodifiable collection of <see cref="T:org.tmapi.core.IAssociation"/>s.
		/// </returns>
		ReadOnlyCollection<IAssociation> GetAssociations(ITopic theme);

		/// <summary>
		///     Returns the <see cref="T:org.tmapi.core.IAssociation"/>s in the topic map whose 
		///     scope property equals one of those <paramref name="themes"/> at least. 
		///     The return value may be empty but must never be <c>null</c>.
		/// </summary>
		/// <param name="themes">
		///     Scope of the <see cref="T:org.tmapi.core.IAssociation"/>s to be returned.
		/// </param>
		/// <param name="matchAll">
		///     If <c>true</c> the scope property of an association must match all <paramref name="themes"/>, 
		///     if <c>false</c> one theme must be matched at least.
		/// </param>
		/// <returns>
		///     An unmodifiable collection of <see cref="T:org.tmapi.core.IAssociation"/>s.
		/// </returns>
		/// <exception cref="T:System.ArgumentNullException">
		///     If the <paramref name="themes"/> is <c>null</c>.
		/// </exception>
		ReadOnlyCollection<IAssociation> GetAssociations(ITopic[] themes, bool matchAll);

		/// <summary>
		///     Returns the <see cref="T:org.tmapi.core.IName"/>s in the topic map whose 
		///     scope property contains the specified <paramref name="theme"/>. 
		///     The return value may be empty but must never be <c>null</c>.
		/// </summary>
		/// <param name="theme">
		///     <see cref="T:org.tmapi.core.ITopic"/> which must be part of the scope. 
		///     If it is <c>null</c> all <see cref="T:org.tmapi.core.IName"/>s in the 
		///     unconstrained scope are returned.
		/// </param>
		/// <returns>
		///     An unmodifiable collection of <see cref="T:org.tmapi.core.IName"/>s.
		/// </returns>
		ReadOnlyCollection<IName> GetNames(ITopic theme);

		/// <summary>
		///     Returns the <see cref="T:org.tmapi.core.IName"/>s in the topic map whose 
		///     scope property equals one of those <paramref name="themes"/> at least. 
		///     The return value may be empty but must never be <c>null</c>.
		/// </summary>
		/// <param name="themes">
		///     Scope of the <see cref="T:org.tmapi.core.IName"/>s to be returned.
		/// </param>
		/// <param name="matchAll">
		///     If <c>true</c> the scope property of an name must match all <paramref name="themes"/>, 
		///     if <c>false</c> one theme must be matched at least.
		/// </param>
		/// <returns>
		///     An unmodifiable collection of <see cref="T:org.tmapi.core.IName"/>s.
		/// </returns>
		/// <exception cref="T:System.ArgumentNullException">
		///     If the <paramref name="themes"/> is <c>null</c>.
		/// </exception>
		ReadOnlyCollection<IName> GetNames(ITopic[] themes, bool matchAll);

		/// <summary>
		///     Returns the <see cref="T:org.tmapi.core.IOccurrence"/>s in the topic map whose 
		///     scope property contains the specified <paramref name="theme"/>. 
		///     The return value may be empty but must never be <c>null</c>.
		/// </summary>
		/// <param name="theme">
		///     <see cref="T:org.tmapi.core.ITopic"/> which must be part of the scope. 
		///     If it is <c>null</c> all <see cref="T:org.tmapi.core.IOccurrence"/>s in the 
		///     unconstrained scope are returned.
		/// </param>
		/// <returns>
		///     An unmodifiable collection of <see cref="T:org.tmapi.core.IOccurrence"/>s.
		/// </returns>
		ReadOnlyCollection<IOccurrence> GetOccurrences(ITopic theme);

		/// <summary>
		///     Returns the <see cref="T:org.tmapi.core.IOccurrence"/>s in the topic map whose 
		///     scope property equals one of those <paramref name="themes"/> at least. 
		///     The return value may be empty but must never be <c>null</c>.
		/// </summary>
		/// <param name="themes">
		///     Scope of the <see cref="T:org.tmapi.core.IOccurrence"/>s to be returned.
		/// </param>
		/// <param name="matchAll">
		///     If <c>true</c> the scope property of an occurrence must match all <paramref name="themes"/>, 
		///     if <c>false</c> one theme must be matched at least.
		/// </param>
		/// <returns>
		///     An unmodifiable collection of <see cref="T:org.tmapi.core.IOccurrence"/>s.
		/// </returns>
		/// <exception cref="T:System.ArgumentNullException">
		///     If the <paramref name="themes"/> is <c>null</c>.
		/// </exception>
		ReadOnlyCollection<IOccurrence> GetOccurrences(ITopic[] themes, bool matchAll);

		/// <summary>
		///     Returns the <see cref="T:org.tmapi.core.IVariants"/>s in the topic map whose 
		///     scope property contains the specified <paramref name="theme"/>. 
		///     The return value may be empty but must never be <c>null</c>.
		/// </summary>
		/// <param name="theme">
		///     <see cref="T:org.tmapi.core.ITopic"/> which must be part of the scope. 
		///     This must not be null <c>null</c>.
		/// </param>
		/// <returns>
		///     An unmodifiable collection of <see cref="T:org.tmapi.core.IVariant"/>s.
		/// </returns>
		/// <exception cref="T:System.ArgumentNullException">
		///     If the <paramref name="theme"/> is <c>null</c>.
		/// </exception>
		ReadOnlyCollection<IVariant> GetVariants(ITopic theme);

		/// <summary>
		///     Returns the <see cref="T:org.tmapi.core.IVariants"/>s in the topic map whose 
		///     scope property equals one of those <paramref name="themes"/> at least. 
		///     The return value may be empty but must never be <c>null</c>.
		/// </summary>
		/// <param name="themes">
		///     Scope of the <see cref="T:org.tmapi.core.IVariant"/>s to be returned.
		/// </param>
		/// <param name="matchAll">
		///     If <c>true</c> the scope property of an variant must match all <paramref name="themes"/>, 
		///     if <c>false</c> one theme must be matched at least.
		/// </param>
		/// <returns>
		///     An unmodifiable collection of <see cref="T:org.tmapi.core.IOccurrence"/>s.
		/// </returns>
		/// <exception cref="T:System.ArgumentNullException">
		///     If the <paramref name="themes"/> is <c>null</c>.
		/// </exception>
		ReadOnlyCollection<IVariant> GetVariants(ITopic[] themes, bool matchAll);
		#endregion
	}
}