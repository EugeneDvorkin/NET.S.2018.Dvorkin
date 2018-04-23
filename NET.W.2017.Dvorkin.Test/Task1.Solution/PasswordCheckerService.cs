using System;
using System.Linq;

namespace Task1
{
    public class PasswordCheckerService
    {
        private IRepository repository;
        private ICheck check;

        public PasswordCheckerService(IRepository repository, ICheck check)
        {
            this.repository = repository;
            this.check = check;
        }

        public PasswordCheckerService(IRepository repository)
        {
            this.repository = repository;
            this.check = new DefaultCheck();
        }

        public Tuple<bool, string> VerifyPassword(string password)
        {
            try
            {
                check.Check(password);
            }
            catch (ArgumentException e)
            {
                throw e;
            }

            repository.Create(password);

            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }
}
