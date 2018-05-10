using System;
using DAL.Interface.Interfaces;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// Implementation of a gold account.
    /// </summary>
    /// <seealso cref="AccountDal" />
    public class GoldAccountDal : AccountDal
    {
        private const int coefWindrawPoint = 3;
        private const int coefDepositPoint = 3;

        /// <summary>
        /// Initializes a new instance of the <see cref="GoldAccountDal"/> class.
        /// </summary>
        /// <param name="personalInfo">The personal information.</param>
        /// <param name="number">The number.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="calculate">The calculate.</param>
        /// <exception cref="System.ArgumentNullException">calculate</exception>
        public GoldAccountDal(int id, PersonalInfo personalInfo, int number, decimal balance, ICalculate calculate) :
            base(id, personalInfo, number, balance, 300, Type.Gold)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoldAccountDal"/> class.
        /// </summary>
        public GoldAccountDal()
        {
        }

        /// <summary>
        /// Calculates the benefits points deposit.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="calculate">The calculate.</param>
        protected override void CalculatePointDeposit(decimal count, ICalculate calculate)
        {
            this.Point = calculate.CalculateDeposit(count, coefDepositPoint, this.Point);
        }

        /// <summary>
        /// Calculates the benefits point withdraw.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="calculate">The calculate.</param>
        protected override void CalculatePointWithdraw(decimal count, ICalculate calculate)
        {
            int point = calculate.CalculateWithdraw(count, coefWindrawPoint, this.Point);

            this.Point = point < 0 ? 0 : point;
        }
    }
}