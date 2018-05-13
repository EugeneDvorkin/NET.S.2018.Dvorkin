﻿using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
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

            Account temp = new Account()
            {
                TypeId = dal.Type,
                Balance = dal.Balance,
                Number = dal.Number,
                Points = dal.Point,
                PersonId = dal.Id,
                Valid = dal.Valid
            };
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

            temp.Id = dal.Id;
            temp.PersonId = dal.Id;
            temp.Number = dal.Number;
            temp.AccountType.Id = dal.Type;
            temp.Balance = dal.Balance;
            temp.Points = dal.Point;
            temp.Valid = dal.Valid;
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

            AccountDal result = new AccountDal
            {
                Id = temp.Id,
                Number = temp.Number,
                Balance = temp.Balance,
                PersonId = temp.PersonId,
                Point = temp.Points,
                Valid = temp.Valid,
                Type = temp.TypeId
            };

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
                AccountDal temp = new AccountDal
                {
                    Id = account.Id,
                    Number = account.Number,
                    Balance = account.Balance,
                    PersonId = account.PersonId,
                    Point = account.Points,
                    Valid = account.Valid,
                    Type = account.TypeId
                };

                yield return temp;
            }
        }
    }
}