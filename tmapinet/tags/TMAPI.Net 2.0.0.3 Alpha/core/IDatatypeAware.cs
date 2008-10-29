namespace org.tmapi.core {
	/// <summary>
    ///     Common base interface for <see cref="T:org.tmapi.core.IOccurrence"/>s and <see cref="T:org.tmapi.core.IVariant"/>s.
    ///     Some convenience methods for a subset of <a href="http://www.w3.org/TR/xmlschema-2/">XML Schema Part 2: Datatypes</a>
	///     are supported.
	/// </summary>
	public interface IDatatypeAware : IReifiable, IScoped {
        #region Properties
        /// <summary>
        ///     Gets or sets the <c>decimal</c> representation of the value.
        ///     This method sets the datatype implicitly to 
        ///     <a href="http://www.w3.org/TR/xmlschema-2/#decimal">xsd:decimal</a>.
        /// </summary>
        /// <exception cref="System.FormatException">
        ///     If value isn't in <c>decimal</c> format or cannot converted into it.
        /// </exception>
        decimal DecimalValue { get; set; }

        /// <summary>
        ///     Gets or sets the <c>float</c> representation of the value.
        ///     This method sets the datatype implicitly to 
        ///     <a href="http://www.w3.org/TR/xmlschema-2/#float">xsd:float</a>.
        /// </summary>
        /// <exception cref="System.FormatException">
        ///     If value isn't in <c>float</c> format or cannot converted into it.
        /// </exception>
        float FloatValue { get; set; }

        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.ILocator"/> identifying the datatype of the value. 
        /// </summary>
        /// <returns>
        ///     The datatype of this construct (never <c>null</c>).
        /// </returns>
        ILocator Datatype { get; }

        /// <summary>
        ///     Gets or sets the lexical representation of the value.
        ///     For the datatype <a href="http://www.w3.org/TR/xmlschema-2/#string">xsd:string</a> 
        ///     the string itself is returned.
        ///     For the datatype <a href="http://www.w3.org/TR/xmlschema-2/#anyURI">xsd:anyURI</a> 
        ///     the <see cref="P:org.tmapi.core.ILocator.Reference"/> is returned.
        ///     This method sets the datatype implicitly to
        ///     <a href="http://www.w3.org/TR/xmlschema-2/#string">xsd:string</a>.
        /// </summary>
        /// <exception cref="ModelConstraintException">
        ///     If value is <c>null</c>.
        /// </exception>
        string Value { get; set; }

        /// <summary>
        ///     Gets or sets the <c>int</c> representation of the value.
        ///     This method sets the datatype implicitly to 
        ///     <a href="http://www.w3.org/TR/xmlschema-2/#int">xsd:int</a>.
        /// </summary>
        /// <exception cref="System.FormatException">
        ///     If value isn't in <c>int</c> format or cannot converted into it.
        /// </exception>
        int IntValue { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="T:org.tmapi.core.ILocator"/> representation of the value.
        /// </summary>
        /// <exception cref="T:org.tmapi.core.ModelConstraintException">
        ///     In case the <paramref name="value"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        ///     If trying to access the property but value is <c>null</c>.
        /// </exception>
        ILocator LocatorValue { get; set; }

        /// <summary>
        ///     Gets or sets the <c>long</c> representation of the value.
        ///     This method sets the datatype implicitly to 
        ///     <a href="http://www.w3.org/TR/xmlschema-2/#long">xsd:long</a>.
        /// </summary>
        /// <exception cref="System.FormatException">
        ///     If value isn't in <c>long</c> format or cannot converted into it.
        /// </exception>
        long LongValue { get; set; } 
        #endregion

        #region Methods
        /// <summary>
        ///     Sets the string value and the datatype.
        /// </summary>
        /// <param name="value">
        ///     The string value.
        /// </param>
        /// <param name="datatype">
        ///     The value's datatype.
        /// </param>
        /// <exception cref="T:org.tmapi.core.ModelConstraintException">
        ///     In case the <paramref name="value"/> or <paramref name="datatype"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.FormatException">
        ///     If value couldn't converted into format specified by <paramref name="datatype"/>.
        /// </exception>
        void SetValue(string value, ILocator datatype);
        #endregion
	}
}