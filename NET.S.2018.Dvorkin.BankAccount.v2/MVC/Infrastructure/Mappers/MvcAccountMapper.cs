using Bll.Interface.Entities;
using MVC.Models;

namespace MVC.Infrastructure.Mappers
{
    /// <summary>
    /// Contains implementation of a account mapper.
    /// </summary>
    public static class MvcAccountMapper
    {
        /// <summary>
        /// To the BLL account.
        /// </summary>
        /// <param name="accountMvc">The account MVC.</param>
        /// <returns>Current BLL account.</returns>
        public static AccountBll ToBllAccount(this AccountMvc accountMvc)
        {
            AccountBll temp = FactoryAccounts.CreateAccount((int) accountMvc.Type, accountMvc.PersonId,
                accountMvc.Number, accountMvc.Balance);
            temp.Person = accountMvc.Person.PartialPersonMapper();

            return temp;
        }

        /// <summary>
        /// To the MVC account.
        /// </summary>
        /// <param name="accountBll">The account BLL.</param>
        /// <returns>Current MVC account.</returns>
        public static AccountMvc ToMvcAccount(this AccountBll accountBll)
        {
            return new AccountMvc()
            {
                Number = accountBll.Number,
                Balance = accountBll.Balance,
                PersonId = accountBll.PersonId,
                Valid = accountBll.Valid,
                Person = accountBll.Person.PartialPersonMapper(),
                Type = (TypeMvc) accountBll.TypeId
            };
        }

        /// <summary>
        /// Partials the person mapper.
        /// </summary>
        /// <param name="personMvc">The person MVC.</param>
        /// <returns>Current partial BLL map person.</returns>
        private static PersonBll PartialPersonMapper(this PersonMvc personMvc)
        {
            return new PersonBll(personMvc.Name, personMvc.Surname, personMvc.Passport, personMvc.Email);
        }

        /// <summary>
        /// Partials the person mapper.
        /// </summary>
        /// <param name="personBll">The person BLL.</param>
        /// <returns>Current partial MVC map person.</returns>
        private static PersonMvc PartialPersonMapper(this PersonBll personBll)
        {
            return new PersonMvc()
            {
                Name = personBll.Name,
                Surname = personBll.Surname,
                Passport = personBll.Passport,
                Email = personBll.Email
            };
        }
    }
}