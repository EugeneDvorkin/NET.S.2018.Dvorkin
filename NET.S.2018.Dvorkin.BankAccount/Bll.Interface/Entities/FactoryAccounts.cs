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
        /// <returns>Current BLL account.</returns>
        /// <exception cref="ArgumentNullException">accountType</exception>
        /// <exception cref="ArgumentException">accountType</exception>
        public static AccountBll CreateAccount(int accountType)
        {
            if (!Enum.IsDefined(typeof(TypeBll), accountType))
            {
                throw new ArgumentNullException($"{nameof(accountType)} is null");
            }

            switch ((TypeBll)accountType)
            {
                case (TypeBll.Base):
                {
                    return new BaseBll();
                }
                case (TypeBll.Silver):
                {
                    return new SilverBll();
                }
                case (TypeBll.Gold):
                {
                    return new GoldBll();
                }
                case (TypeBll.Platinum):
                {
                    return new PlatinumBll();
                }
                default:
                {
                    throw new ArgumentException($"{nameof(accountType)} doesn't contains");
                }
            }
        }
    }
}