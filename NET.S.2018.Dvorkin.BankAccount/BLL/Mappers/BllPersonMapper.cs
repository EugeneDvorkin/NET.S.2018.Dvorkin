using System.Collections.Generic;
using System.Collections.ObjectModel;
using Bll.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    /// <summary>
    /// Map persons instances.
    /// </summary>
    public static class BllPersonMapper
    {
        /// <summary>
        /// To the DAL person.
        /// </summary>
        /// <param name="personBll">The person BLL.</param>
        /// <returns>Equals DAL person.</returns>
        public static PersonDal ToDalPerson(this PersonBll personBll)
        {
            PersonDal temp = new PersonDal(personBll.Name, personBll.Surname, personBll.Passport, personBll.Email);
            ICollection<AccountDal> accounts = new List<AccountDal>();
            foreach (AccountBll account in personBll.Accounts)
            {
                accounts.Add(account.PartialMapAccountDal());
            }

            temp.AccountsDal = accounts;

            return temp;
        }

        /// <summary>
        /// To the BLL person.
        /// </summary>
        /// <param name="personDal">The personal information.</param>
        /// <returns>Equals BLL person.</returns>
        public static PersonBll ToBllPerson(this PersonDal personDal)
        {
            PersonBll temp = new PersonBll(personDal.Name, personDal.Surname, personDal.Passport, personDal.Email);
            ObservableCollection<AccountBll> accounts = new ObservableCollection<AccountBll>();
            foreach (AccountDal account in personDal.AccountsDal)
            {
                accounts.Add(account.PartialMapAccountBll());
            }

            temp.Accounts = accounts;

            return temp;
        }

        /// <summary>
        /// Partials the map person.
        /// </summary>
        /// <param name="personDal">The person ORM.</param>
        /// <returns>Current DAL person.</returns>
        internal static PersonBll PartialMapPersonBll(this PersonDal personDal)
        {
            return new PersonBll(personDal.Name, personDal.Surname, personDal.Passport, personDal.Email);
        }

        /// <summary>
        /// Partials the map person ORM.
        /// </summary>
        /// <param name="personDal">The person DAL.</param>
        /// <returns>Current ORM person.</returns>
        internal static PersonDal PartialMapPersonDal(this PersonBll personDal)
        {
            return new PersonDal(personDal.Name, personDal.Surname, personDal.Passport, personDal.Email);
        }
    }
}