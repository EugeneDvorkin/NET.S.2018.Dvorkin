using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Representation of a repository.
    /// </summary>
    public interface IRepository<T> where T : IEntity
    {
        /// <summary>
        /// Creates the specified dal.
        /// </summary>
        /// <param name="dal">The dal.</param>
        void Create(T dal);

        /// <summary>
        /// Updates the specified dal.
        /// </summary>
        /// <param name="dal">The dal.</param>
        void Update(T dal);

        /// <summary>
        /// Deletes the specified dal.
        /// </summary>
        /// <param name="dal">The dal.</param>
        void Delete(T dal);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All dal from the storage.</returns>
        IEnumerable<T> GetAll();
    }
}