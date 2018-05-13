using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using ORM;

namespace DAL.Repositories
{
    /// <summary>
    /// Implementation of pattern Unit of work.
    /// </summary>
    /// <seealso cref="DAL.Interface.Interfaces.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        private AccountRepository accountRepository;
        private PersonRepository personRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(BankEntities context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public BankEntities Context { get; private set; }

        /// <summary>
        /// Gets the account repository.
        /// </summary>
        /// <value>
        /// The account repository.
        /// </value>
        public IRepository<AccountDal> AccRepository
        {
            get => accountRepository ?? new AccountRepository(Context);
        }

        /// <summary>
        /// Gets the person repository.
        /// </summary>
        /// <value>
        /// The person repository.
        /// </value>
        public IRepository<PersonDal> PersonRepository
        {
            get => personRepository ?? new PersonRepository(Context);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Context?.Dispose();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}