using System;

namespace DAL.Interface.DTO
{
    public static class FactoryAccounts
    {
        public static AccountDal CreateAccount(string accountType)
        {
            if (string.IsNullOrWhiteSpace(accountType))
            {
                throw new ArgumentNullException($"{nameof(accountType)} is null");
            }

            switch (accountType)
            {
                case ("Base"):
                {
                    return new BaseAccountDal();
                }
                case ("Silver"):
                {
                    return new SilverAccountDal();
                }
                case ("Gold"):
                {
                    return new GoldAccountDal();
                }
                case ("Platinum"):
                {
                    return new GoldAccountDal();
                }
                default:
                {
                    throw new ArgumentException($"{nameof(accountType)} doesn't contains");
                }
            }
        }
    }
}