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

            return temp;
        }
    }
}