using DAL.Interface.Interfaces;

namespace DAL.Fake.Repositories
{
    /// <summary>
    /// COntains implementation of Unit Of Work.
    /// </summary>
    /// <seealso cref="DAL.Interface.Interfaces.IUnitOfWork" />
    public class FakeUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
        }
    }
}