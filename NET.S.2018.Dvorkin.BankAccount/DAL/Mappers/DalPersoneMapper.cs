using System.Collections.Generic;
using DAL.Interface.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalPersoneMapper
    {
        /// <summary>
        /// To the DAL person.
        /// </summary>
        /// <param name="personOrm">The person BLL.</param>
        /// <returns>Equals DAL person.</returns>
        public static PersonDal ToDalPerson(this Person personOrm)
        {
            PersonDal temp = new PersonDal(personOrm.Name, personOrm.Surname, personOrm.Passport, personOrm.Email);
            
            ICollection<AccountDal> accounts = new List<AccountDal>();
            foreach (Account account in personOrm.Accounts)
            {
                accounts.Add(account.PartialMapAccountDal());
            }

            temp.AccountsDal = accounts;

            return temp;
        }

        /// <summary>
        /// To the ORM person.
        /// </summary>
        /// <param name="personDal">The personal information.</param>
        /// <returns>Equals ORM person.</returns>
        public static Person ToOrmPerson(this PersonDal personDal)
        {
            Person temp = new Person()
            {
                Name = personDal.Name,
                Surname = personDal.Surname,
                Passport = personDal.Passport,
                Email = personDal.Email
            };

            if (personDal.AccountsDal.Count != 0)
            {
                ICollection<Account> accounts = new List<Account>();
                foreach (AccountDal accountDal in personDal.AccountsDal)
                {
                    accounts.Add(accountDal.PartialMapAccountOrm());
                }

                temp.Accounts = accounts;
            }

            return temp;
        }

        /// <summary>
        /// Partials the map person.
        /// </summary>
        /// <param name="personOrm">The person ORM.</param>
        /// <returns>Current DAL person.</returns>
        internal static PersonDal PartialMapPersonDal(this Person personOrm)
        {
            return new PersonDal(personOrm.Name, personOrm.Surname, personOrm.Passport, personOrm.Email);
        }

        /// <summary>
        /// Partials the map person ORM.
        /// </summary>
        /// <param name="personDal">The person DAL.</param>
        /// <returns>Current ORM person.</returns>
        internal static Person PartialMapPersonOrm(this PersonDal personDal)
        {
            return new Person
            {
                Name = personDal.Name,
                Surname = personDal.Surname,
                Passport = personDal.Passport,
                Email = personDal.Email
            };
        }
    }
}