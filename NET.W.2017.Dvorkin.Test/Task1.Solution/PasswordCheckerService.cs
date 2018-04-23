using System;
using System.Collections.Generic;

namespace Task1
{
    public class PasswordCheckerService
    {
        private IRepository repository;

        public PasswordCheckerService(IRepository repository)
        {
            this.repository = repository;
        }

        public Tuple<bool, string> VerifyPassword(string password, IEnumerable<ICheck> check)
        {
            if (password == null)
                throw new ArgumentException($"{password} is null arg");

            foreach (var item in check)
            {
                if (item.Check(password).Item1 == false)
                {
                    return item.Check(password);
                }
            }

            repository.Create(password);

            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }
}
