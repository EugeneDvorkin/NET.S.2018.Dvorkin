using System;

namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Definition of pattern Unit of work.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();
    }
}