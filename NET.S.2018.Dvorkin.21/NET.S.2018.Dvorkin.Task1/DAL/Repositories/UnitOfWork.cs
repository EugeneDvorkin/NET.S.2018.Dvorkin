using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using ORM;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AccountRepository accountRepository;
        private PersonRepository personRepository;

        public UnitOfWork(BankEntities context)
        {
            this.Context = context;
        }

        public BankEntities Context { get; private set; }

        public IRepository<AccountDal> AccRepository
        {
            get => accountRepository ?? new AccountRepository(Context);
        }

        public IRepository<PersonalInfo> PersoneRepository
        {
            get => personRepository ?? new PersonRepository(Context);
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}