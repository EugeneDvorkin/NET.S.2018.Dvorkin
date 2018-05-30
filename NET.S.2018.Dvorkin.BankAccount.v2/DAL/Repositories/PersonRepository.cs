using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.Mappers;
using ORM;

namespace DAL.Repositories
{
    /// <summary>
    /// Implementation of pattern Repository for owners.
    /// </summary>
    /// <seealso cref="DAL.Interface.Interfaces.IRepository{DAL.Interface.DTO.PersonalInfo}" />
    public class PersonRepository : IPersonRepository
    {
        private readonly BankEntities context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">context</exception>
        public PersonRepository(BankEntities context)
        {
            this.context = context ?? throw new ArgumentNullException($"{nameof(context)} is null"); ;
        }

        /// <summary>
        /// Creates the specified DTO.
        /// </summary>
        /// <param name="dal">The DTO.</param>
        /// <exception cref="ArgumentNullException">DAL</exception>
        public void Create(PersonDal dal)
        {
            if (ReferenceEquals(dal, null))
            {
                throw new ArgumentNullException($"{nameof(dal)} is null");
            }

            Person temp = new Person()
            {
                Id = dal.Id,
                Name = dal.Name,
                Surname = dal.Surname,
                Passport = dal.Passport,
                Email = dal.Email
            };
            context.Persons.Add(temp);
        }

        /// <summary>
        /// Updates the specified DTO.
        /// </summary>
        /// <param name="dal">The DTO.</param>
        /// <exception cref="ArgumentNullException">DTO. </exception>
        /// <exception cref="ArgumentException">DTO.</exception>
        public void Update(PersonDal dal)
        {
            if (ReferenceEquals(dal, null))
            {
                throw new ArgumentNullException($"{nameof(dal)} is null");
            }

            Person temp = context.Persons.FirstOrDefault(item => item.Id == dal.Id);
            if (ReferenceEquals(temp, null))
            {
                throw new ArgumentException($"{nameof(dal)} doesn't contains in the storage");
            }

            temp.Id = dal.Id;
            temp.Name = dal.Name;
            temp.Surname = dal.Surname;
            temp.Email = dal.Email;
        }

        /// <summary>
        /// Deletes the specified DAL.
        /// </summary>
        /// <param name="dal">The DAL.</param>
        /// <exception cref="ArgumentNullException">DTO. </exception>
        /// <exception cref="ArgumentException">DTO.</exception>
        public void Delete(PersonDal dal)
        {
            if (ReferenceEquals(dal, null))
            {
                throw new ArgumentNullException($"{nameof(dal)} is null");
            }

            Person temp = context.Persons.FirstOrDefault(item => item.Id == dal.Id);
            if (ReferenceEquals(temp, null))
            {
                throw new ArgumentException($"{nameof(dal)} doesn't contains in database");
            }

            context.Persons.Remove(temp);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="passport">The passport.</param>
        /// <returns>
        /// Current person.
        /// </returns>
        /// <exception cref="ArgumentNullException">id</exception>
        public PersonDal Get(string passport)
        {
            Person temp = context.Persons.FirstOrDefault(item => item.Passport == passport);
            if (ReferenceEquals(temp, null))
            {
                return null;
            }

            PersonDal result = temp.ToDalPerson();

            return result;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>
        /// All persons from the storage.
        /// </returns>
        public IEnumerable<PersonDal> GetAll()
        {
            foreach (Person person in context.Persons)
            {
                PersonDal temp = person.ToDalPerson();

                yield return temp;
            }
        }
    }
}