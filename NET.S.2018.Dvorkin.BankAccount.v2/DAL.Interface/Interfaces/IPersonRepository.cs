using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Definition for person repository.
    /// </summary>
    /// <seealso cref="DAL.Interface.Interfaces.IRepository{DAL.Interface.DTO.PersonDal}" />
    public interface IPersonRepository:IRepository<PersonDal>
    {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="passport">The passport.</param>
        /// <returns>Current instance of Person.</returns>
        PersonDal Get(string passport);
    }
}