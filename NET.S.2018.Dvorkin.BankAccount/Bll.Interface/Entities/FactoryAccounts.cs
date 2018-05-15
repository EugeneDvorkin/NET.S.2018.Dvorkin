using System;

namespace Bll.Interface.Entities
{
    /// <summary>
    /// Factory for BLL Accounts.
    /// </summary>
    public static class FactoryAccounts
    {
        /// <summary>
        /// Creates the account.
        /// </summary>
        /// <param name="accountType">Type of the account.</param>
        /// <param name="personId">The person identifier.</param>
        /// <param name="number">The number.</param>
        /// <param name="balance">The balance.</param>
        /// <returns>
        /// Current BLL account.
        /// </returns>
        /// <exception cref="ArgumentNullException">accountType</exception>
        /// <exception cref="ArgumentException">accountType</exception>
        public static AccountBll CreateAccount(int accountType, int personId, int number, decimal balance)
        {
            if (!Enum.IsDefined(typeof(TypeBll), accountType))
            {
                throw new ArgumentNullException($"{nameof(accountType)} is null");
            }

            switch ((TypeBll)accountType)
            {
                case (TypeBll.Base):
                {
                    return new BaseBll(personId, number, balance);
                }
                case (TypeBll.Silver):
                {
                    return new SilverBll(personId, number, balance);
                }
                case (TypeBll.Gold):
                {
                    return new GoldBll(personId, number, balance);
                }
                case (TypeBll.Platinum):
                {
                    return new PlatinumBll(personId, number, balance);
                }
                default:
                {
                    throw new ArgumentException($"{nameof(accountType)} doesn't contains");
                }
            }
        }
    }
}