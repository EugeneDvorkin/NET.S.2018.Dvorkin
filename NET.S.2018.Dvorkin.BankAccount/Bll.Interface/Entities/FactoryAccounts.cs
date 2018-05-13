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
            if (accountType < 1)
            {
                throw new ArgumentNullException($"{nameof(accountType)} is null");
            }

            switch (accountType)
            {
                case (1):
                {
                    return new BaseBll();
                }
                case (2):
                {
                    return new SilverBll();
                }
                case (3):
                {
                    return new GoldBll();
                }
                case (4):
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