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
            PersonDal temp = new PersonDal()
            {
                Name = personBll.Name,
                Surname = personBll.Surname,
                Passport = personBll.Passport,
                Email = personBll.Email
            };

            return temp;
        }

        /// <summary>
        /// To the BLL person.
        /// </summary>
        /// <param name="personDal">The personal information.</param>
        /// <returns>Equals BLL person.</returns>
        public static PersonBll ToBllPerson(this PersonDal personDal)
        {
            PersonBll temp = new PersonBll
            {
                Id = personDal.Id,
                Name = personDal.Name,
                Surname = personDal.Surname,
                Passport = personDal.Passport,
                Email = personDal.Email
            };

            return temp;
        }
    }
}