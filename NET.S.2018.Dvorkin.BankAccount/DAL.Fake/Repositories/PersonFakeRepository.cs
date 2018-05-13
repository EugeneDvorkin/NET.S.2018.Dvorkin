using System;
using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Fake.Repositories
{
    /// <summary>
    /// Implementation for person repository.
    /// </summary>
    /// <seealso cref="DAL.Interface.Interfaces.IPersonRepository" />
    public class PersonFakeRepository : IPersonRepository
    {
        private readonly List<PersonDal> people;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonFakeRepository"/> class.
        /// </summary>
        public PersonFakeRepository()
        {
            people = new List<PersonDal>();
        }

        /// <summary>
        /// Creates the specified DTO.
        /// </summary>
        /// <param name="dal">The DTO.</param>
        /// <exception cref="System.ArgumentException">DTO</exception>
        public void Create(PersonDal dal)
        {
            if (people.Contains(dal))
            {
                throw new ArgumentException($"{nameof(dal)} already exist");
            }

            people.Add(dal);
        }

        /// <summary>
        /// Updates the specified DTO.
        /// </summary>
        /// <param name="dal">The DTO.</param>
        /// <exception cref="System.ArgumentException">DTO</exception>
        public void Update(PersonDal dal)
        {
            PersonDal temp = people.Find(item => item.Id == dal.Id);
            if (ReferenceEquals(temp, null))
            {
                throw new ArgumentException($"{nameof(dal)} doesn't contains in the storage");
            }

            temp.Name = dal.Name;
            temp.Surname = dal.Surname;
            temp.Passport = dal.Passport;
            temp.Email = dal.Email;
        }

        /// <summary>
        /// Deletes the specified DTO.
        /// </summary>
        /// <param name="dal">The DTO.</param>
        /// <exception cref="System.ArgumentException">DTO</exception>
        public void Delete(PersonDal dal)
        {
            if (!people.Contains(dal))
            {
                throw new ArgumentException($"{nameof(dal)} doesn't contains in the storage");
            }

            people.Remove(dal);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>
        /// All DTO from the storage.
        /// </returns>
        public IEnumerable<PersonDal> GetAll()
        {
            return people;
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="passport">The passport.</param>
        /// <returns>
        /// Current instance of Person.
        /// </returns>
        /// <exception cref="System.ArgumentException">passport</exception>
        public PersonDal Get(string passport)
        {
            PersonDal result = people.Find(item => item.Passport == passport);
            if (ReferenceEquals(result, null))
            {
                throw new ArgumentException($"{nameof(passport)} doesn't contains in the storage");
            }

            return result;
        }
    }
}