using System;
using DAL.Interface.Interfaces;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// Implementation of a base accountDal.
    /// </summary>
    /// <seealso cref="AccountDal" />
    public class BaseAccountDal : AccountDal
    {
        private const int coefWindrawPoint = 1;
        private const int coefDepositPoint = 1;
        private readonly ICalculate calculate;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAccountDal"/> class.
        /// </summary>
        /// <param name="personalInfo">The personal information.</param>
        /// <param name="number">The number.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="calculate">The calculate.</param>
        /// <exception cref="System.ArgumentNullException">calculate</exception>
        public BaseAccountDal(int id, PersonalInfo personalInfo, int number, decimal balance, ICalculate calculate) : base(id, personalInfo, number, balance, 100, DTO.Type.Base)
        {
            this.calculate = calculate ?? throw new ArgumentNullException($"{nameof(calculate)} is null");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAccountDal"/> class.
        /// </summary>
        public BaseAccountDal()
        {
        }

        /// <summary>
        /// Calculates the benefits points deposit.
        /// </summary>
        /// <param name="count">The count.</param>
        protected override void CalculatePointDeposit(decimal count)
        {
            this.Point = calculate.CalculateDeposit(count, coefDepositPoint, this.Point);
        }

        /// <summary>
        /// Calculates the benefits point withdraw.
        /// </summary>
        /// <param name="count">The count.</param>
        protected override void CalculatePointWithdraw(decimal count)
        {
            int point = calculate.CalculateWithdraw(count, coefWindrawPoint, this.Point);

            this.Point = point < 0 ? 0 : point;
        }
    }
}