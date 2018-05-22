using System.Collections.Generic;
using Bll.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    /// <summary>
    /// Map accounts instances.
    /// </summary>
    public static class BllAccountMapper
    {
        /// <summary>
        /// To the DAL account.
        /// </summary>
        /// <param name="accountBll">The account BLL.</param>
        /// <returns>Equal DAL account.</returns>
        public static AccountDal ToDalAccount(this AccountBll accountBll)
        {
            AccountDal temp = new AccountDal(accountBll.PersoneId, accountBll.Number, accountBll.Balance,
                accountBll.Point, (int) accountBll.TypeId);
            temp.Person = accountBll.Person.PartialMapPersonDal();

            return temp;
        }

        /// <summary>
        /// To the BLL account.
        /// </summary>
        /// <param name="accountDal">The account DAL.</param>
        /// <returns>Equal BLL account.</returns>
        public static AccountBll ToBllAccount(this AccountDal accountDal)
        {
            AccountBll temp = FactoryAccounts.CreateAccount(accountDal.Type, accountDal.PersonId, accountDal.Number, accountDal.Balance);
            temp.Person = accountDal.Person.PartialMapPersonBll();

            return temp;
        }

        /// <summary>
        /// Partials the map account DAL.
        /// </summary>
        /// <param name="accountBll">The account BLL.</param>
        /// <returns>Current DAL account.</returns>
        internal static AccountDal PartialMapAccountDal(this AccountBll accountBll)
        {
            return new AccountDal(accountBll.PersoneId, accountBll.Number, accountBll.Balance,
                accountBll.Point, (int)accountBll.TypeId);
        }

        /// <summary>
        /// Partials the map account BLL.
        /// </summary>
        /// <param name="accountDal">The account DAL.</param>
        /// <returns>Current BLL account.</returns>
        internal static AccountBll PartialMapAccountBll(this AccountDal accountDal)
        {
            return FactoryAccounts.CreateAccount(accountDal.Type, accountDal.PersonId, accountDal.Number, accountDal.Balance);
        }
    }
}