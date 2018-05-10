using System;

namespace DAL.Interface.DTO
{
    public static class FactoryAccounts
    {
        public static AccountDal CreateAccount(int accountType)
        {
            if (accountType < 1)
            {
                throw new ArgumentNullException($"{nameof(accountType)} is null");
            }

            switch (accountType)
            {
                case (1):
                    {
                        return new BaseAccountDal();
                    }
                case (2):
                    {
                        return new SilverAccountDal();
                    }
                case (3):
                    {
                        return new GoldAccountDal();
                    }
                case (4):
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