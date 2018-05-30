using System.Collections.ObjectModel;
using Bll.Interface.Entities;
using MVC.Models;

namespace MVC.Infrastructure.Mappers
{
    /// <summary>
    /// Contain implementation of a person mapper.
    /// </summary>
    public static class MvcPersonMapper
    {
        /// <summary>
        /// To the BLL person.
        /// </summary>
        /// <param name="personMvc">The person MVC.</param>
        /// <returns>Current BLL person.</returns>
        public static PersonBll ToBllPerson(this PersonMvc personMvc)
        {
            PersonBll temp = new PersonBll(personMvc.Name, personMvc.Surname, personMvc.Passport, personMvc.Email);
            ObservableCollection<AccountBll> accounts = new ObservableCollection<AccountBll>();
            foreach (AccountMvc account in personMvc.Accounts)
            {
                accounts.Add(account.PartialAccountMapper());
            }

            temp.Accounts = accounts;

            return temp;
        }

        /// <summary>
        /// To the MVC person.
        /// </summary>
        /// <param name="personBll">The person BLL.</param>
        /// <returns>Current MVC person.</returns>
        public static PersonMvc ToMvcPerson(this PersonBll personBll)
        {
            PersonMvc temp = new PersonMvc()
            {
                Name = personBll.Name,
                Surname = personBll.Surname,
                Passport = personBll.Passport,
                Email = personBll.Email
            };
            ObservableCollection<AccountMvc> accounts = new ObservableCollection<AccountMvc>();
            foreach (AccountBll account in personBll.Accounts)
            {
                accounts.Add(account.PartialAccountMapper());
            }

            temp.Accounts = accounts;

            return temp;
        }

        /// <summary>
        /// Partials the account mapper.
        /// </summary>
        /// <param name="accountMvc">The account MVC.</param>
        /// <returns>Current partial map BLL account.</returns>
        private static AccountBll PartialAccountMapper(this AccountMvc accountMvc)
        {
            return FactoryAccounts.CreateAccount((int) accountMvc.Type, accountMvc.PersonId, accountMvc.Number,
                accountMvc.Balance);
        }

        private static AccountMvc PartialAccountMapper(this AccountBll accountBll)
        {
            return new AccountMvc()
            {
                PersonId = accountBll.PersonId,
                Number = accountBll.Number,
                Balance = accountBll.Balance,
                Valid = accountBll.Valid,
                Type = (TypeMvc) accountBll.TypeId
            };
        }
    }
}