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
        public static PersonalInfo ToDalPerson(this PersonBll personBll)
        {
            PersonalInfo temp = new PersonalInfo()
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
        /// <param name="personalInfo">The personal information.</param>
        /// <returns>Equals BLL person.</returns>
        public static PersonBll ToBllPerson(this PersonalInfo personalInfo)
        {
            PersonBll temp = new PersonBll
            {
                Id = personalInfo.Id,
                Name = personalInfo.Name,
                Surname = personalInfo.Surname,
                Passport = personalInfo.Passport,
                Email = personalInfo.Email
            };

            return temp;
        }
    }
}