using System.Collections.ObjectModel;

namespace org.tmapi.core {
	/// <summary>
	///     Represents an <a href="http://www.isotopicmaps.org/sam/sam-model/#sect-association">
	///     association item</a>.
	/// </summary>
	public interface IAssociation : IReifiable, ITyped, IScoped {
        #region Properties
        /// <summary>
        ///     Returns the <see cref="T:org.tmapi.core.ITopicMap"/> to which this association belongs.
        /// </summary>
        /// <returns>
        ///     The <see cref="T:org.tmapi.core.ITopicMap"/> to which this association belongs.
        /// </returns>
        new ITopicMap Parent { get; }

        /// <summary>
        ///     Returns the roles participating in this association.
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <returns>
        ///     An unmodifiable set of <see cref="T:org.tmapi.core.IRole"/>s.
        /// </returns>
        ReadOnlyCollection<IRole> Roles { get; }

        /// <summary>
        ///     Returns the role types participating in this association.
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <returns>
        ///     An unmodifiable set of role types.
        /// </returns>
        ReadOnlyCollection<ITopic> RoleTypes { get; } 
        #endregion

        #region Methods
        /// <summary>
        ///     Creates a new <see cref="T:org.tmapi.core.IRole"/> representing a role in this association.
        /// </summary>
        /// <param name="type">
        ///     The role type; must not be <c>null</c>.
        /// </param>
        /// <param name="player">
        ///     The role player; must not be <c>null</c>.
        /// </param>
        /// <returns>
        ///     A newly created association role.
        /// </returns>
        /// <exception cref="T:org.tmapi.core.ModelConstraintException">
        ///     If the <paramref name="type"/> or <paramref name="player"/> is <c>null</c>.
        /// </exception>
        IRole CreateRole(ITopic type, ITopic player);

        /// <summary>
        ///     Returns all roles with the specified <c>type</c>.
        ///     The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <param name="type">
        ///     The type of the <see cref="T:org.tmapi.core.IRole"/> instances to be returned, must not be <c>null</c>.
        /// </param>
        /// <returns>
        ///     An unmodifiable (maybe empty) set of roles with the specified <c>type</c> property.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     If the <paramref name="type"/> is <c>null</c>.
        /// </exception>
        ReadOnlyCollection<IRole> GetRoles(ITopic type);
        #endregion
	}
}