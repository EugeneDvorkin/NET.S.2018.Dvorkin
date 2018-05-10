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
            AccountDal temp = FactoryAccounts.CreateAccount(accountBll.TypeId);
            temp.Valid = accountBll.Valid;
            temp.Number = accountBll.Number;
            temp.Balance = accountBll.Balance;
            temp.Point = accountBll.Point;
            temp.PersonalInfo.Id = accountBll.PersoneId;

            return temp;
        }

        /// <summary>
        /// To the BLL account.
        /// </summary>
        /// <param name="accountDal">The account DAL.</param>
        /// <returns>Equal BLL account.</returns>
        public static AccountBll ToBllAccount(this AccountDal accountDal)
        {
            AccountBll temp = new AccountBll()
            {
                Id = accountDal.Id,
                Number = accountDal.Number,
                PersoneId = accountDal.PersonalInfo.Id,
                Point = accountDal.Point,
                TypeId = (int) accountDal.Type,
                Valid = accountDal.Valid,
                Balance = accountDal.Balance
            };

            return temp;
        }
    }
}