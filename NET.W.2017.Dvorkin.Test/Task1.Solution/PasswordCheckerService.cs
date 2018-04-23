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
            if (password == null)
                throw new ArgumentException($"{password} is null arg");

            Tuple<bool, string> result = check.Check(password);

            if (result.Item1)
            {
                repository.Create(password);
                return result;
            }
            else
            {
                return result;
            }
        }
    }
}
