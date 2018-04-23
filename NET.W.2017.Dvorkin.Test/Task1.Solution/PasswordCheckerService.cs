using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Task1
{
    public class PasswordCheckerService
    {
        private IRepository repository;

        private List<ICheck> check = new List<ICheck>();

        public PasswordCheckerService(IRepository repository)
        {
            this.repository = repository;
        }

        public void AddCheck(ICheck item)
        {
            if (item == null)
            {
                throw new ArgumentException($"{nameof(item)} is null");
            }

            check.Add(item);
        }

        public Tuple<bool, string> VerifyPassword(string password)
        {
            if (password == null)
                throw new ArgumentException($"{password} is null arg");

            if (check.Count == 0)
            {
                throw new ArgumentException($"There is no validators");
            }

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
