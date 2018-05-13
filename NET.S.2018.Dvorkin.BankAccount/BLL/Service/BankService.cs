using System;
using System.Collections.Generic;
using Bll.Interface.Entities;
using Bll.Interface.Interface;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace BLL.Service
{
    /// <summary>
    /// Implementation of bank service.
    /// </summary>
    /// <seealso cref="Bll.Interface.Interface.IBankService" />
    public class BankService : IBankService
    {
        private readonly IUnitOfWork context;
        private readonly IAccountRepository accountRepository;
        private readonly IPersonRepository personRepository;
        private readonly IGenerator generator;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="accountRepository">The account repository.</param>
        /// <param name="personRepository">The person repository.</param>
        /// <param name="generator">The generator.</param>
        public BankService(IUnitOfWork context, IAccountRepository accountRepository, IPersonRepository personRepository, IGenerator generator)
        {
            this.context = context;
            this.accountRepository = accountRepository;
            this.personRepository = personRepository;
            this.generator = generator;
        }

        /// <summary>
        /// Deposit the specified count.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="account">The account.</param>
        /// <exception cref="ArgumentException">count</exception>
        public void Deposit(decimal count, AccountBll account)
        {
            Check(account);
            if (count < 0)
            {
                throw new ArgumentException($"{nameof(count)} is less 0");
            }

            account.Deposit(count);
            accountRepository.Update(account.ToDalAccount());
            context.Save();
        }

        /// <summary>
        /// Withdrawals the specified count.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="account">The account.</param>
        /// <exception cref="ArgumentException">count</exception>
        public void Withdrawal(decimal count, AccountBll account)
        {
            Check(account);
            if (count < 0)
            {
                throw new ArgumentException($"{nameof(count)} is less 0");
            }

            account.Withdraw(count);
            accountRepository.Update(account.ToDalAccount());
            context.Save();
        }

        /// <summary>
        /// New the account.
        /// </summary>
        /// <param name="personId">The person identifier.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="point">The point.</param>
        /// <param name="typeId">The type identifier.</param>
        public void NewAccount(int personId, decimal balance, int point, int typeId)
        {
            AccountBll temp = FactoryAccounts.CreateAccount(typeId);
            temp.PersoneId = personId;
            temp.Balance = balance;
            temp.Point = point;
            temp.Number = generator.GenerateNumber(personId, balance, point, typeId);
            accountRepository.Create(temp.ToDalAccount());
            context.Save();
        }

        /// <summary>
        /// New the owner.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="surname">The surname.</param>
        /// <param name="passport">The passport.</param>
        /// <param name="email">The email.</param>
        /// <exception cref="ArgumentException">passport</exception>
        public void NewOwner(string name, string surname, string passport, string email)
        {
            if (!ReferenceEquals(personRepository.Get(passport), null))
            {
                throw new ArgumentException($"{nameof(passport)} already contains in the database");
            }

            personRepository.Create(new PersonDal(name, surname, passport, email));
            context.Save();
        }

        /// <summary>
        /// Closes the account.
        /// </summary>
        /// <param name="account">The account.</param>
        public void CloseAccount(AccountBll account)
        {
            Check(account);
            accountRepository.Delete(account.ToDalAccount());
            context.Save();
        }

        /// <summary>
        /// Transfers the specified account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="transfer">The transfer.</param>
        /// <param name="count">The count.</param>
        public void Transfer(AccountBll account, AccountBll transfer, decimal count)
        {
            Check(account);
            Check(transfer);
            account.Withdraw(count);
            transfer.Deposit(count);
            accountRepository.Update(account.ToDalAccount());
            accountRepository.Update(transfer.ToDalAccount());
            context.Save();
        }

        /// <summary>
        /// Finds the specified account.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">number</exception>
        public AccountBll Find(int number)
        {
            AccountBll temp = accountRepository.Get(number).ToBllAccount();
            if (ReferenceEquals(temp,null))
            {
                throw new ArgumentNullException($"{nameof(number)} doesn't contains in the database");
            }

            return temp;
        }

        /// <summary>
        /// Gets all account.
        /// </summary>
        /// <returns>All accounts from the storage.</returns>
        public IEnumerable<AccountBll> GetAllAccount()
        {
            foreach (AccountDal accountDal in accountRepository.GetAll())
            {
                yield return accountDal.ToBllAccount();
            }
        }

        /// <summary>
        /// Gets all person.
        /// </summary>
        /// <returns>All persons from the storage.</returns>
        public IEnumerable<PersonBll> GetAllPerson()
        {
            foreach (PersonDal personDal in personRepository.GetAll())
            {
                yield return personDal.ToBllPerson();
            }
        }

        /// <summary>
        /// Checks the specified account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <exception cref="ArgumentNullException">account</exception>
        /// <exception cref="ArgumentException">account</exception>
        private void Check(AccountBll account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException($"{nameof(account)} is null");
            }

            if (account.Valid == false)
            {
                throw new ArgumentException($"{nameof(account)} is closed");
            }
        }
    }
}