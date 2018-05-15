using System;

namespace Bll.Interface.Entities
{
    public class SilverBll : AccountBll
    {
        private const int coefWindrawPoint = 2;
        private const int coefDepositPoint = 2;

        /// <summary>
        /// Initializes a new instance of the <see cref="SilverBll" /> class.
        /// </summary>
        /// <param name="personId">The person identifier.</param>
        /// <param name="number">The number.</param>
        /// <param name="balance">The balance.</param>
        public SilverBll(int personId, int number, decimal balance) :
            base(personId, number, balance, 200, TypeBll.Silver)
        {
        }
        
        /// <summary>
        /// Calculates the benefits points deposit.
        /// </summary>
        /// <param name="count">The count.</param>
        protected override void CalculatePointDeposit(decimal count)
        {
            this.Point = this.Point = Point + (int)count * coefDepositPoint;
        }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        /// <exception cref="ArgumentException">value</exception>
        public override decimal Balance
        {
            get => balance;
            protected set => balance = value < 0 || balance - value < -20000m
                ? throw new ArgumentException($"{nameof(value)} is wrong value or more than current balance")
                : value;
        }

        /// <summary>
        /// Calculates the benefits point withdraw.
        /// </summary>
        /// <param name="count">The count.</param>
        protected override void CalculatePointWithdraw(decimal count)
        {
            int point = Point + (int)count * coefWindrawPoint;

            this.Point = point < 0 ? 0 : point;
        }
    }
}