using Bll.Interface.Entities;

namespace Bll.Interface.Interface
{
    /// <summary>
    /// Definition of bank service.
    /// </summary>
    public interface IBankService
    {
        /// <summary>
        /// Deposits the specified count.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="account">The account.</param>
        void Deposit(decimal count, AccountBll account);

        /// <summary>
        /// Withdrawals the specified count.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="account">The account.</param>
        void Withdrawal(decimal count, AccountBll account);

        /// <summary>
        /// News the account.
        /// </summary>
        /// <param name="personId">The person identifier.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="typeId">The type identifier.</param>
        void NewAccount(int personId, decimal balance, int typeId);

        /// <summary>
        /// News the owner.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="surname">The surname.</param>
        /// <param name="passport">The passport.</param>
        /// <param name="email">The email.</param>
        void NewOwner(string name, string surname, string passport, string email);

        /// <summary>
        /// Closes the account.
        /// </summary>
        /// <param name="account">The account.</param>
        void CloseAccount(AccountBll account);

        /// <summary>
        /// Transfers the specified account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="transfer">The transfer.</param>
        /// <param name="count">The count.</param>
        void Transfer(AccountBll account, AccountBll transfer, decimal count);

        /// <summary>
        /// Finds the account.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Current account.</returns>
        AccountBll FindAccount(int name);

        /// <summary>
        /// Finds the person.
        /// </summary>
        /// <param name="passport">The passport.</param>
        /// <returns>Current person.</returns>
        PersonBll FindPerson(string passport);

    }
}