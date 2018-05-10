using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using ORM;

namespace DAL.Repositories
{
    public class PersoneRepository : IRepository<PersonalInfo>
    {
        private readonly BankEntities context;

        public PersoneRepository(BankEntities context)
        {
            this.context = context ?? throw new ArgumentNullException($"{nameof(context)} is null"); ;
        }

        public void Create(PersonalInfo dal)
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
                Email = dal.Email
            };
            context.Persons.Add(temp);
        }

        public void Update(PersonalInfo dal)
        {
            if (ReferenceEquals(dal, null))
            {
                throw new ArgumentNullException($"{nameof(dal)} is null");
            }

            Person temp = context.Persons.FirstOrDefault(item => item.Id == dal.Id);
            if (ReferenceEquals(temp, null))
            {
                throw new ArgumentNullException($"{nameof(dal)} doesn't contains in the storage");
            }

            context.Persons.FirstOrDefault(item => item.Id == dal.Id).Id = dal.Id;
            context.Persons.FirstOrDefault(item => item.Id == dal.Id).Name = dal.Name;
            context.Persons.FirstOrDefault(item => item.Id == dal.Id).Surname = dal.Surname;
            context.Persons.FirstOrDefault(item => item.Id == dal.Id).Email = dal.Email;
        }

        public void Delete(PersonalInfo dal)
        {
            if (ReferenceEquals(dal, null))
            {
                throw new ArgumentNullException($"{nameof(dal)} is null");
            }

            Person temp = context.Persons.FirstOrDefault(item => item.Id == dal.Id);
            if (ReferenceEquals(temp, null))
            {
                throw new ArgumentNullException($"{nameof(dal)} doesn't contains in database");
            }

            context.Persons.Remove(temp);
        }

        public PersonalInfo Get(int id)
        {
            Person temp = context.Persons.FirstOrDefault(item => item.Id == id);
            if (ReferenceEquals(temp, null))
            {
                throw new ArgumentNullException($"{nameof(id)} doesn't contains in the database");
            }

            PersonalInfo result = new PersonalInfo(temp.Id, temp.Name, temp.Surname, temp.Passport, temp.Email);
            
            return result;
        }

        public IEnumerable<PersonalInfo> GetAll()
        {
            foreach (Person person in context.Persons)
            {
                PersonalInfo temp = new PersonalInfo(person.Id,person.Name,person.Surname,person.Passport,person.Email);
                
                yield return temp;
            }
        }
    }
}