using Bll.Interface.Entities;

namespace Bll.Interface.Interface
{
    public interface IBankService
    {
        void Deposite(decimal account, AccountBll acc);

        void Withdrawal(decimal account, AccountBll acc);

        AccountBll NewAccount(int number, int personeId, decimal balance, int point, int typeId);

        PersonBll NewOwner(string name, string surname, string passport, string email);

        void CloseAccount(AccountBll acc);
    }
}