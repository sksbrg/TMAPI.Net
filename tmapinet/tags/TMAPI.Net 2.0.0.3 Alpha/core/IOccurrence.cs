namespace org.tmapi.core {
	/// <summary>
	///     Represents an 
	///     <a href="http://www.isotopicmaps.org/sam/sam-model/#sect-occurrence">occurrence item</a>.
	/// </summary>
	public interface IOccurrence : IDatatypeAware, ITyped {
        #region Properties
        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.ITopic"/> to which this occurrence belongs.
        /// </summary>
        /// <returns>
        ///     The <see cref="T:org.tmapi.core.ITopic"/> to which this occurrence belongs.
        /// </returns>
        new ITopic Parent { get; } 
        #endregion
	}
}