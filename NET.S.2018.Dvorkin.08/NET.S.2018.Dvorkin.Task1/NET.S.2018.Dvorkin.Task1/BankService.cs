using System;

namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Contains methods for interactions with a bank account.
    /// </summary>
    /// <seealso cref="NET.S._2018.Dvorkin.Task1.IBankService{NET.S._2018.Dvorkin.Task1.Acc}" />
    public class BankService : IBankService<Acc>
    {
        #region Constants
        private const int BaseCountUp = 100;
        private const int BaseUp = 125;
        private const int BaseCountDown = 75;
        private const int BaseDown = 50;
        private const double Percent = 0.1;
        #endregion

        #region Public methods
        /// <summary>
        /// Replenishments the specified account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="acc">The account.</param>
        /// <returns>Changed account.</returns>
        public Acc Replenishment(decimal account, Acc acc)
        {
            Checker(acc);
            AccountChecker(account);
            acc.Account = acc.Account + account;
            acc.Score = ScoreUp(acc, account);
            Type(acc);

            return acc;
        }

        /// <summary>
        /// Withdrawals the specified account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="acc">The account.</param>
        /// <returns>Changed account.</returns>
        /// <exception cref="ArgumentException">account</exception>
        public Acc Withdrawal(decimal account, Acc acc)
        {
            Checker(acc);
            AccountChecker(account);

            if (account > acc.Account)
            {
                throw new ArgumentException($"{nameof(account)} exceeds the limit");
            }

            acc.Account = acc.Account - account;
            acc.Score = ScoreDown(acc, account);
            Type(acc);

            return acc;
        }

        /// <summary>
        /// Closes the account.
        /// </summary>
        /// <param name="acc">The account.</param>
        /// <exception cref="ArgumentException">account</exception>
        public void CloseAcc(Acc acc)
        {
            Checker(acc);

            if (acc.Account > 0)
            {
                throw new ArgumentException($"{nameof(acc)} can't be close. There are money on the account");
            }
            else
            {
                acc.Valid = false;
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Scores up.
        /// </summary>
        /// <param name="acc">The account.</param>
        /// <param name="account">The account.</param>
        /// <returns>New score of a account.</returns>
        private int ScoreUp(Acc acc, decimal account)
        {
            acc.Score = acc.Score + Convert.ToInt32(BaseUp * (int)acc.Type * Percent * Convert.ToInt32(account)) + Convert.ToInt32(BaseCountUp * Convert.ToInt32(acc.Account) * Percent);

            return acc.Score;
        }

        /// <summary>
        /// Scores down.
        /// </summary>
        /// <param name="acc">The account.</param>
        /// <param name="account">The account.</param>
        /// <returns>New score of a account.</returns>
        private int ScoreDown(Acc acc, decimal account)
        {
            int difference = Convert.ToInt32(BaseDown * (int)acc.Type * Percent * Convert.ToInt32(account)) +
                             Convert.ToInt32(BaseCountDown * Convert.ToInt32(acc.Account) * Percent);

            if (acc.Score > difference)
            {
                acc.Score = acc.Score - difference;
            }
            else
            {
                acc.Score = 0;
            }

            return acc.Score;
        }

        /// <summary>
        /// Types the specified account.
        /// </summary>
        /// <param name="acc">The account.</param>
        private void Type(Acc acc)
        {
            if (acc.Score < 200)
            {
                acc.Type = (Acc.AccType)1;
            }

            if (acc.Score >= 200 && acc.Score < 300)
            {
                acc.Type = (Acc.AccType)2;
            }

            if (acc.Score >= 300 && acc.Score < 400)
            {
                acc.Type = (Acc.AccType)3;
            }

            if (acc.Score >= 400)
            {
                acc.Type = (Acc.AccType)4;
            }
        }

        /// <summary>
        /// Checkers the specified account.
        /// </summary>
        /// <param name="acc">The account.</param>
        /// <exception cref="ArgumentNullException">account</exception>
        /// <exception cref="ArgumentException">account</exception>
        private void Checker(Acc acc)
        {
            if (acc == null)
            {
                throw new ArgumentNullException($"{nameof(acc)} is null");
            }

            if (acc.Valid == false)
            {
                throw new ArgumentException($"{nameof(acc)} is closed");
            }
        }

        private void AccountChecker(decimal account)
        {
            if (account < 0)
            {
                throw new ArgumentException($"{nameof(account)} is wrong");
            }
        }
        #endregion
    }
}
