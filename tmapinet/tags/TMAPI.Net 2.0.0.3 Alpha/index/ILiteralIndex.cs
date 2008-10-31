using System.Collections.ObjectModel;
using org.tmapi.core;

namespace org.tmapi.index {
	/// <summary>
	///     Index for literal values stored in a topic map.
	/// </summary>
	public interface ILiteralIndex : IIndex {
        #region Methods
        /// <summary>
        ///     Retrieves the <see cref="T:org.tmapi.core.IName"/>s in the topic map 
        ///     which have a value equal to <paramref name="value"/>. 
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <param name="value">
        ///     The value of the <see cref="T:org.tmapi.core.IName"/>s to be returned.
        /// </param>
        /// <returns>
        ///     An unmodifiable collection of <see cref="T:org.tmapi.core.IName"/>s.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     If the <paramref name="value"/> is <c>null</c>.
        /// </exception>
        ReadOnlyCollection<IName> GetNames(string value);

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.IOccurrence"/>s in the topic map 
        ///     whose value property matches <paramref name="value"/> and whose datatype 
        ///     property is <a href="http://www.w3.org/TR/xmlschema-2/#string">xsd:string</a>. 
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <param name="value">
        ///     The value of the <see cref="T:org.tmapi.core.IOccurrence"/>s to be returned.
        /// </param>
        /// <returns>
        ///     An unmodifiable collection of <see cref="T:org.tmapi.core.IOccurrence"/>s.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     If the <paramref name="value"/> is <c>null</c>.
        /// </exception>
        ReadOnlyCollection<IOccurrence> GetOccurrences(string value);

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.IOccurrence"/>s in the topic map 
        ///     whose value property matches the IRI represented by <paramref name="value"/>. 
        ///     Those <see cref="T:org.tmapi.core.IOccurrence"/>s which have a datatype equal to 
        ///     <a href="http://www.w3.org/TR/xmlschema-2/#anyURI">xsd:anyURI</a> and their 
        ///     value property is equal to <see cref="P:org.tmapi.core.ILocator.Reference"/> are returned. 
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <param name="value">
        ///     The value of the <see cref="T:org.tmapi.core.IOccurrence"/>s to be returned.
        /// </param>
        /// <returns>
        ///     An unmodifiable collection of <see cref="T:org.tmapi.core.IOccurrence"/>s.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     If the <paramref name="value"/> is <c>null</c>.
        /// </exception>
        ReadOnlyCollection<IOccurrence> GetOccurrences(ILocator value);

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.IOccurrence"/>s in the topic map 
        ///     whose value property matches <paramref name="value"/> and whose datatye is <paramref name="datatype"/>. 
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <param name="value">
        ///     The value of the <see cref="T:org.tmapi.core.IOccurrence"/>s to be returned.
        /// </param>
        /// <param name="datatype">
        ///     The datatype of the <see cref="T:org.tmapi.core.IOccurrence"/>s to be returned.
        /// </param>
        /// <returns>
        ///     An unmodifiable collection of <see cref="T:org.tmapi.core.IOccurrence"/>s.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     If the <paramref name="value"/> or <paramref name="datatype"/> is <c>null</c>.
        /// </exception>
        ReadOnlyCollection<IOccurrence> GetOccurrences(string value, ILocator datatype);

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.IVariant"/>s in the topic map whose 
        ///     value property matches <paramref name="value"/> and whose datatype property is 
        ///     <a href="http://www.w3.org/TR/xmlschema-2/#string">xsd:string</a>.
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <param name="value">
        ///     The value of the <see cref="T:org.tmapi.core.IVariant"/>s to be returned.
        /// </param>
        /// <returns>
        ///     An unmodifiable collection of <see cref="T:org.tmapi.core.IVariant"/>s.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     If the <paramref name="value"/> is <c>null</c>.
        /// </exception>
        ReadOnlyCollection<IVariant> GetVariants(string value);

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.IVariant"/>s in the topic map whose 
        ///     value property matches the IRI represented by <paramref name="value"/>. 
        ///     Those <see cref="T:org.tmapi.core.IVariant"/>s which have a datatype equal to 
        ///     <a href="http://www.w3.org/TR/xmlschema-2/#anyURI">xsd:anyURI</a> and their 
        ///     value property is equal to <see cref="P:org.tmapi.core.ILocator.Reference"/> are returned. 
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <param name="value">
        ///     The value of the <see cref="T:org.tmapi.core.IVariant"/>s to be returned.
        /// </param>
        /// <returns>
        ///     An unmodifiable collection of <see cref="T:org.tmapi.core.IVariant"/>s.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     If the <paramref name="value"/> is <c>null</c>.
        /// </exception>
        ReadOnlyCollection<IVariant> GetVariants(ILocator value);

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.IVariant"/>s in the topic map 
        ///     whose value property matches <paramref name="value"/> and whose datatye is <paramref name="datatype"/>. 
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <param name="value">
        ///     The value of the <see cref="T:org.tmapi.core.IVariant"/>s to be returned.
        /// </param>
        /// <param name="datatype">
        ///     The datatype of the <see cref="T:org.tmapi.core.IVariant"/>s to be returned.
        /// </param>
        /// <returns>
        ///     An unmodifiable collection of <see cref="T:org.tmapi.core.IVariant"/>s.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     If the <paramref name="value"/> or <paramref name="datatype"/> is <c>null</c>.
        /// </exception>
        ReadOnlyCollection<IVariant> GetVariants(string value, ILocator datatype);
        #endregion
	}
}