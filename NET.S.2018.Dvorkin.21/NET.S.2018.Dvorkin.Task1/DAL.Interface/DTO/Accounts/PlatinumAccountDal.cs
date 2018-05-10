﻿using System;
using DAL.Interface.Interfaces;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// Implementation of a platinum accountDal.
    /// </summary>
    /// <seealso cref="AccountDal" />
    public class PlatinumAccountDal : AccountDal
    {
        private const int coefWindrawPoint = 4;
        private const int coefDepositPoint = 4;
        private readonly ICalculate calculate;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatinumAccountDal"/> class.
        /// </summary>
        /// <param name="personalInfo">The personal information.</param>
        /// <param name="number">The number.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="calculate">The calculate.</param>
        /// <exception cref="System.ArgumentNullException">calculate</exception>
        public PlatinumAccountDal(int id, PersonalInfo personalInfo, int number, decimal balance, ICalculate calculate) : base(id, personalInfo, number, balance, 400, Type.Platinum)
        {
            this.calculate = calculate ?? throw new ArgumentNullException($"{nameof(calculate)} is null");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatinumAccountDal"/> class.
        /// </summary>
        public PlatinumAccountDal()
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