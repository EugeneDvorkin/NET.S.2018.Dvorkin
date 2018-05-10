using Bll.Interface.Entities;
using Bll.Interface.Interface;
using DAL.Interface.Interfaces;

namespace BLL.Service
{
    public class BankService : IBankService
    {
        private readonly IUnitOfWork context;
        private ICalculate calculate;

        public BankService(IUnitOfWork context, ICalculate calculate)
        {
            this.context = context;
            this.calculate = calculate;
        }

        public void Deposite(decimal account, AccountBll acc)
        {
            throw new System.NotImplementedException();
        }

        public void Withdrawal(decimal account, AccountBll acc)
        {
            throw new System.NotImplementedException();
        }

        public AccountBll NewAccount(int number, int personeId, decimal balance, int point, int typeId)
        {
            throw new System.NotImplementedException();
        }

        public PersonBll NewOwner(string name, string surname, string passport, string email)
        {
            throw new System.NotImplementedException();
        }

        public void CloseAccount(AccountBll acc)
        {
            throw new System.NotImplementedException();
        }
    }
}