// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAssociation.cs">
//  TMAPI.Net was created collectively by the membership of the tmapinet-discuss mailing list 
//  (https://lists.sourceforge.net/lists/listinfo/tmapinet-discuss) with support by the 
//  tmapi-discuss mailing list (http://lists.sourceforge.net/mailman/listinfo/tmapi-discuss),
//  and is hereby released into the public domain; and comes with NO WARRANTY.
//  
//  No one owns TMAPI.Net: you may use it freely in both commercial and
//  non-commercial applications, bundle it with your software
//  distribution, include it on a CD-ROM, list the source code in a
//  book, mirror the documentation at your own web site, or use it in
//  any other way you see fit.
// </copyright>
// <summary>
//   Represents an <a href="http://www.isotopicmaps.org/sam/sam-model/#sect-association">
//   association item</a>.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TMAPI.Net.Core
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// Represents an <a href="http://www.isotopicmaps.org/sam/sam-model/#sect-association">
    /// association item</a>.
    /// </summary>
    public interface IAssociation : IReifiable, ITyped, IScoped
    {
        #region Properties

        /// <summary>
        /// Gets the <see cref="T:TMAPI.Net.Core.ITopicMap"/> this association belongs to.
        /// </summary>
        /// <returns>
        /// The <see cref="T:TMAPI.Net.Core.ITopicMap"/> this association belongs to.
        /// </returns>
        new ITopicMap Parent
        {
            get;
        }

        /// <summary>
        /// Gets the roles participating in this association.
        /// </summary>
        /// <remarks>
        /// The return value may be empty but must never be <c>null</c>.
        /// </remarks>
        /// <returns>
        /// An unmodifiable set of <see cref="T:TMAPI.Net.Core.IRole">IRoles</see>.
        /// </returns>
        ReadOnlyCollection<IRole> Roles
        {
            get;
        }

        /// <summary>
        /// Gets the role types participating in this association.
        /// The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <returns>
        /// An unmodifiable set of role types.
        /// </returns>
        ReadOnlyCollection<ITopic> RoleTypes
        {
            get;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new <see cref="T:TMAPI.Net.Core.IRole"/> representing a role in this association.
        /// </summary>
        /// <param name="roleType">
        /// The role type; must not be <c>null</c>.
        /// </param>
        /// <param name="player">
        /// The role player; must not be <c>null</c>.
        /// </param>
        /// <returns>
        /// A newly created association role.
        /// </returns>
        /// <exception cref="T:TMAPI.Net.Core.ModelConstraintException">
        /// If the <paramref name="roleType"/> or <paramref name="player"/> is <c>null</c> or 
        /// if <paramref name="roleType"/> or <paramref name="player"/> belongs to another topic map.
        /// </exception>
        IRole CreateRole(ITopic roleType, ITopic player);

        /// <summary>
        /// Returns all roles with the specified <c>type</c>.
        /// The return value may be empty but must never be <c>null</c>.
        /// </summary>
        /// <param name="type">
        /// The type of the <see cref="T:TMAPI.Net.Core.IRole"/> instances to be returned, must not be <c>null</c>.
        /// </param>
        /// <returns>
        /// An unmodifiable (maybe empty) set of roles with the specified <c>type</c> property.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// If the <paramref name="type"/> is <c>null</c>.
        /// </exception>
        ReadOnlyCollection<IRole> GetRolesByTopicType(ITopic type);

        #endregion
    }
}