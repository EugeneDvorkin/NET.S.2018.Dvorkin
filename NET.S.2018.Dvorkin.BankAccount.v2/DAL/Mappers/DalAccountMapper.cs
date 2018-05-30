using DAL.Interface.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalAccountMapper
    {
        /// <summary>
        /// To the DAL account.
        /// </summary>
        /// <param name="accountOrm">The account BLL.</param>
        /// <returns>Equal DAL account.</returns>
        public static AccountDal ToDalAccount(this Account accountOrm)
        {
            AccountDal temp = new AccountDal(accountOrm.PersonId, accountOrm.Number, accountOrm.Balance,
                accountOrm.Points, accountOrm.TypeId);
            temp.Person = accountOrm.Person.PartialMapPersonDal();

            return temp;
        }

        /// <summary>
        /// To the BLL account.
        /// </summary>
        /// <param name="accountDal">The account DAL.</param>
        /// <returns>Equal ORM account.</returns>
        public static Account ToOrmAccount(this AccountDal accountDal)
        {
            Account temp = new Account()
            {
                Number = accountDal.Number,
                Id = accountDal.Id,
                TypeId = accountDal.Type,
                Valid = accountDal.Valid,
                Balance = accountDal.Balance,
                PersonId = accountDal.PersonId,
                Points = accountDal.Point,
                Person = accountDal.Person.PartialMapPersonOrm()
            };

            return temp;
        }

        /// <summary>
        /// Partials the map account.
        /// </summary>
        /// <param name="accountOrm">The account ORM.</param>
        /// <returns>Current DAL account.</returns>
        internal static AccountDal PartialMapAccountDal(this Account accountOrm)
        {
            return new AccountDal(accountOrm.PersonId, accountOrm.Number, accountOrm.Balance,
                accountOrm.Points, accountOrm.TypeId);
        }

        /// <summary>
        /// Partials the map account ORM.
        /// </summary>
        /// <param name="accountDal">The account DAL.</param>
        /// <returns>Current ORM account.</returns>
        internal static Account PartialMapAccountOrm(this AccountDal accountDal)
        {
            return new Account()
            {
                Number = accountDal.Number,
                Id = accountDal.Id,
                TypeId = accountDal.Type,
                Valid = accountDal.Valid,
                Balance = accountDal.Balance,
                PersonId = accountDal.PersonId,
                Points = accountDal.Point
            };
        }
    }
}