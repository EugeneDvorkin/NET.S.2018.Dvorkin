using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IAccountRepository:IRepository<AccountDal>
    {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Current account from the storage.</returns>
        AccountDal Get(int id);
    }
}