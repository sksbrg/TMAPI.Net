namespace org.tmapi.index {
	/// <summary>
	///     Base interface for all indices.
	/// </summary>
	public interface IIndex {
        #region Properties
        /// <summary>
        ///     Indicates whether the index is updated automatically.  If the value of this is
        ///     <c>true</c>, then the index is automatically kept synchronized with the topic
        ///     map as values are changed. If the value is <c>false</c>, then the 
        ///     <see cref="M:org.tmapi.index.IIndex.Reindex"/> method must be called to 
        ///     resynchronize the index with the topic map after values are changed.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if index is updated automatically, <c>false</c> otherwise.
        /// </returns>
        bool AutoUpdated { get; }

        /// <summary>
        ///     Indicates if the index is open.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if index is already opened, <c>false</c> otherwise.
        /// </returns>
        bool IsOpen { get; } 
        #endregion

        #region Methods
        /// <summary>
        ///     Close the index.
        /// </summary>
        void Close();

        /// <summary>
        ///     Open the index.
        ///     This method must be invoked before using any other method
        ///     exported by this interface or derived interfaces.
        /// </summary>
        void Open();

        /// <summary>
        ///     Synchronize the index with data in the topic map.
        /// </summary>
        void Reindex();
        #endregion
	}
}