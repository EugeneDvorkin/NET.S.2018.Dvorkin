using System;
using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Fake.Repositories
{
    /// <summary>
    /// Implementation of account repository.
    /// </summary>
    /// <seealso cref="DAL.Interface.Interfaces.IAccountRepository" />
    public class AccountFakeRepository : IAccountRepository
    {
        private readonly List<AccountDal> accounts;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountFakeRepository"/> class.
        /// </summary>
        public AccountFakeRepository()
        {
            accounts = new List<AccountDal>();
        }

        /// <summary>
        /// Creates the specified DTO.
        /// </summary>
        /// <param name="dal">The DTO.</param>
        /// <exception cref="System.ArgumentException">DAL</exception>
        public void Create(AccountDal dal)
        {
            if (accounts.Contains(dal))
            {
                throw new ArgumentException($"{nameof(dal)} already exist");
            }

            accounts.Add(dal);
        }

        /// <summary>
        /// Updates the specified DTO.
        /// </summary>
        /// <param name="dal">The DTO.</param>
        /// <exception cref="System.ArgumentException">DAL</exception>
        public void Update(AccountDal dal)
        {
            AccountDal temp = accounts.Find(item => item.Id == dal.Id);
            if (ReferenceEquals(temp, null))
            {
                throw new ArgumentException($"{nameof(dal)} doesn't contains in the storage");
            }

            temp.Balance = dal.Balance;
            temp.Number = dal.Number;
            temp.PersonId = dal.PersonId;
            temp.Point = dal.Point;
            temp.Valid = dal.Valid;
            temp.Type = dal.Type;
        }

        /// <summary>
        /// Deletes the specified DTO.
        /// </summary>
        /// <param name="dal">The DAL.</param>
        /// <exception cref="System.ArgumentException">DAL</exception>
        public void Delete(AccountDal dal)
        {
            if (!accounts.Contains(dal))
            {
                throw new ArgumentException($"{nameof(dal)} doesn't contains in the storage");
            }

            accounts.Remove(dal);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>
        /// All DTO from the storage.
        /// </returns>
        public IEnumerable<AccountDal> GetAll()
        {
            return accounts;
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">id</exception>
        public AccountDal Get(int id)
        {
            AccountDal result = accounts.Find(item => item.Id == id);
            if (ReferenceEquals(result, null))
            {
                throw new ArgumentException($"{nameof(id)} doesn't contains in the storage");
            }

            return result;
        }
    }
}