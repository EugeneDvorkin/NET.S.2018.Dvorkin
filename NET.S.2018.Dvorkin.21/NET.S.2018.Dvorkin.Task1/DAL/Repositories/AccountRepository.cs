using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using ORM;

namespace DAL.Repositories
{
    public class AccountRepository : IRepository<AccountDal>
    {
        private readonly BankEntities context;

        public AccountRepository(BankEntities context)
        {
            this.context = context ?? throw new ArgumentNullException($"{nameof(context)} is null");
        }
        public void Create(AccountDal dal)
        {
            if (ReferenceEquals(dal, null))
            {
                throw new ArgumentNullException($"{nameof(dal)} is null");
            }

            Account temp = new Account()
            {
                Id = dal.Id,
                TypeId = (int) dal.Type,
                Balance = dal.Balance,
                Number = dal.Number,
                Points = dal.Point,
                PersoneId = dal.PersonalInfo.Id,
                Valid = dal.Valid
            };
            context.Accounts.Add(temp);
        }

        public void Update(AccountDal dal)
        {
            if (ReferenceEquals(dal,null))
            {
                throw new ArgumentNullException($"{nameof(dal)} is null");
            }
            
            Account temp = context.Accounts.FirstOrDefault(item => item.Id == dal.Id);
            if (ReferenceEquals(temp,null))
            {
                throw new ArgumentNullException($"{nameof(dal)} doesn't contains in the storage");
            }

            context.Accounts.FirstOrDefault(item => item.Id == dal.Id).Id = dal.Id;
            context.Accounts.FirstOrDefault(item => item.Id == dal.Id).PersoneId = dal.PersonalInfo.Id;
            context.Accounts.FirstOrDefault(item => item.Id == dal.Id).Number = dal.Number;
            context.Accounts.FirstOrDefault(item => item.Id == dal.Id).AccountType.Id = (int) dal.Type;
            context.Accounts.FirstOrDefault(item => item.Id == dal.Id).Balance = dal.Balance;
            context.Accounts.FirstOrDefault(item => item.Id == dal.Id).Points = dal.Point;
            context.Accounts.FirstOrDefault(item => item.Id == dal.Id).Valid = dal.Valid;
        }

        public void Delete(AccountDal dal)
        {
            if (ReferenceEquals(dal, null))
            {
                throw new ArgumentNullException($"{nameof(dal)} is null");
            }

            Account temp = context.Accounts.FirstOrDefault(item => item.Id == dal.Id);
            if (ReferenceEquals(temp,null))
            {
                throw new ArgumentNullException($"{nameof(dal)} doesn't contains in database");
            }

            context.Accounts.Remove(temp);
        }

        public AccountDal Get(int id)
        {
            Account temp = context.Accounts.FirstOrDefault(item => item.Id == id);
            if (ReferenceEquals(temp,null))
            {
                throw new ArgumentNullException($"{nameof(id)} doesn't contains in the database");
            }

            AccountDal result = FactoryAccounts.CreateAccount(temp.AccountType.Name);
            result.Id = temp.Id;
            result.Number = temp.Number;
            result.Balance = temp.Balance;
            result.PersonalInfo.Id = temp.PersoneId;
            result.Point = temp.Points;
            result.Valid = temp.Valid;
            return result;
        }

        public IEnumerable<AccountDal> GetAll()
        {
            foreach (Account account in context.Accounts)
            {
                AccountDal temp = FactoryAccounts.CreateAccount(account.AccountType.Name);
                temp.Id = account.Id;
                temp.Number = account.Number;
                temp.Balance = account.Balance;
                temp.PersonalInfo.Id = account.PersoneId;
                temp.Point = account.Points;
                temp.Valid = account.Valid;
                yield return temp;
            }
        }
    }
}