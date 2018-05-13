namespace Bll.Interface.Entities
{
    public class SilverBll : AccountBll
    {
        private const int coefWindrawPoint = 2;
        private const int coefDepositPoint = 2;

        /// <summary>
        /// Initializes a new instance of the <see cref="SilverBll" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="personId">The person identifier.</param>
        /// <param name="number">The number.</param>
        /// <param name="balance">The balance.</param>
        public SilverBll(int id, int personId, int number, decimal balance) :
            base(personId, number, balance, 200, TypeBll.Silver)
        {
        }

        public SilverBll()
        {
            Valid = true;
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