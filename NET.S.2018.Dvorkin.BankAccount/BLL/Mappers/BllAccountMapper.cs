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
            AccountDal temp = new AccountDal
            {
                Valid = accountBll.Valid,
                Number = accountBll.Number,
                Balance = accountBll.Balance,
                Point = accountBll.Point,
                Id = accountBll.PersoneId
            };

            return temp;
        }

        /// <summary>
        /// To the BLL account.
        /// </summary>
        /// <param name="accountDal">The account DAL.</param>
        /// <returns>Equal BLL account.</returns>
        public static AccountBll ToBllAccount(this AccountDal accountDal)
        {
            AccountBll temp = FactoryAccounts.CreateAccount(accountDal.Type);
            temp.Id = accountDal.Id;
            temp.Number = accountDal.Number;
            temp.PersoneId = accountDal.Id;
            temp.Point = accountDal.Point;
            temp.Valid = accountDal.Valid;
            temp.Balance = accountDal.Balance;

            return temp;
        }
    }
}