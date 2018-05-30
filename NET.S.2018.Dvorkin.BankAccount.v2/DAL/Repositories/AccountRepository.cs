using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.Mappers;
using ORM;

namespace DAL.Repositories
{
    /// <summary>
    /// Implementation of Repository pattern
    /// </summary>
    /// <seealso cref="DAL.Interface.Interfaces.IRepository{AccountDal}" />
    public class AccountRepository : IAccountRepository
    {
        private readonly BankEntities context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">context</exception>
        public AccountRepository(BankEntities context)
        {
            this.context = context ?? throw new ArgumentNullException($"{nameof(context)} is null");
        }

        /// <summary>
        /// Creates the specified DTO.
        /// </summary>
        /// <param name="dal">The DTO.</param>
        /// <exception cref="ArgumentNullException">DAL</exception>
        public void Create(AccountDal dal)
        {
            if (ReferenceEquals(dal, null))
            {
                throw new ArgumentNullException($"{nameof(dal)} is null");
            }

            Account temp = dal.ToOrmAccount();
            context.Accounts.Add(temp);
        }

        /// <summary>
        /// Updates the specified DTO.
        /// </summary>
        /// <param name="dal">The DTO.</param>
        /// <exception cref="ArgumentNullException">DTO is null.</exception>
        /// <exception cref="ArgumentException">DTO.</exception>
        public void Update(AccountDal dal)
        {
            if (ReferenceEquals(dal, null))
            {
                throw new ArgumentNullException($"{nameof(dal)} is null");
            }

            Account temp = context.Accounts.FirstOrDefault(item => item.Id == dal.Id);
            if (ReferenceEquals(temp, null))
            {
                throw new ArgumentException($"{nameof(dal)} doesn't contains in the storage");
            }

            temp = dal.ToOrmAccount();
        }

        /// <summary>
        /// Deletes the specified DTO.
        /// </summary>
        /// <param name="dal">The DTO.</param>
        /// <exception cref="ArgumentNullException">DTO.</exception>
        /// <exception cref="ArgumentException">DTO.</exception>
        public void Delete(AccountDal dal)
        {
            if (ReferenceEquals(dal, null))
            {
                throw new ArgumentNullException($"{nameof(dal)} is null");
            }

            Account temp = context.Accounts.FirstOrDefault(item => item.Id == dal.Id);
            if (ReferenceEquals(temp, null))
            {
                throw new ArgumentException($"{nameof(dal)} doesn't contains in database");
            }

            if (temp.Balance > 0 || temp.Balance < 0)
            {
                throw new ArgumentException($"{nameof(dal)} can't be close. Its balance doesn't equals 0");
            }

            temp.Valid = false;
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        /// Current DTO from the storage.
        /// </returns>
        /// <exception cref="ArgumentNullException">Number.</exception>
        public AccountDal Get(int number)
        {
            Account temp = context.Accounts.FirstOrDefault(item => item.Number == number); 
            if (ReferenceEquals(temp, null))
            {
                throw new ArgumentNullException($"{nameof(number)} doesn't contains in the database");
            }

            AccountDal result = temp.ToDalAccount();

            return result;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>
        /// All accounts from the storage.
        /// </returns>
        public IEnumerable<AccountDal> GetAll()
        {
            foreach (Account account in context.Accounts)
            {
                AccountDal temp = account.ToDalAccount();

                yield return temp;
            }
        }
    }
}