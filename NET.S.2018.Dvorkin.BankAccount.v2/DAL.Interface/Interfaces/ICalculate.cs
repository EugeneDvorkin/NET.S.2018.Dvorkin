namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Definition of a benefits points calculation.
    /// </summary>
    public interface ICalculate
    {
        /// <summary>
        /// Calculates the deposit.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="depositCoeff">The deposit coefficient.</param>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        int CalculateDeposit(decimal count, int depositCoeff, int point);

        /// <summary>
        /// Calculates the withdraw.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="withdrawCoeff">The withdraw coefficient.</param>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        int CalculateWithdraw(decimal count, int withdrawCoeff, int point);
    }
}