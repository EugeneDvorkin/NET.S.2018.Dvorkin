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
        /// Creates the specified DTO.
        /// </summary>
        /// <param name="dal">The DTO.</param>
        void Create(T dal);

        /// <summary>
        /// Updates the specified DTO.
        /// </summary>
        /// <param name="dal">The DTO.</param>
        void Update(T dal);

        /// <summary>
        /// Deletes the specified DTO.
        /// </summary>
        /// <param name="dal">The DTO.</param>
        void Delete(T dal);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All DTO from the storage.</returns>
        IEnumerable<T> GetAll();
    }
}