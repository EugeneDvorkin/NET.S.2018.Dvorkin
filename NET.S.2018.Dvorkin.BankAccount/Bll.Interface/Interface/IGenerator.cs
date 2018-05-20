namespace Bll.Interface.Interface
{
    /// <summary>
    /// Definition of number generator.
    /// </summary>
    public interface IGenerator
    {
        /// <summary>
        /// Generates the number.
        /// </summary>
        /// <returns>Generated number for account.</returns>
        int GenerateNumber(int personId, decimal balance, int typeId);
    }
}