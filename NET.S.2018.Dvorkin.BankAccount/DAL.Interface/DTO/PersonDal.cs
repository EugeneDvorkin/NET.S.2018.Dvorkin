using System;
using System.Text.RegularExpressions;
using DAL.Interface.Interfaces;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// Personal information.
    /// </summary>
    public class PersonDal : IEntity, IEquatable<PersonDal>
    {
        private int id;
        private string name;
        private string surname;
        private string passport;
        private string email;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonDal" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="surname">The surname.</param>
        /// <param name="passport">The passport.</param>
        /// <param name="email">The email.</param>
        public PersonDal(string name, string surname, string passport, string email = null)
        {
            this.Name = name;
            this.Surname = surname;
            this.Passport = passport;
            this.Email = email;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonDal"/> class.
        /// </summary>
        //public PersonDal()
        //{
        //}

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id
        {
            get => id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)} is wrong");
                }

                id = value;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <exception cref="ArgumentNullException">value</exception>
        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException($"{nameof(value)} is null");
        }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        /// <exception cref="ArgumentNullException">value</exception>
        public string Surname
        {
            get => surname;
            set => surname = value ?? throw new ArgumentNullException($"{nameof(value)} is null");
        }

        /// <summary>
        /// Gets or sets the passport of a user.
        /// </summary>
        /// <value>
        /// The passport.
        /// </value>
        /// <exception cref="ArgumentNullException">value</exception>
        /// <exception cref="ArgumentException">value</exception>
        public string Passport
        {
            get => passport;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(value)} is null");
                }

                Regex passportRegex = new Regex(@"^[0-9A-Z]");

                if (passportRegex.IsMatch(value) == false)
                {
                    throw new ArgumentException($"{nameof(value)} is wrong passport");
                }

                passport = value;
            }
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        /// <exception cref="ArgumentNullException">value</exception>
        /// <exception cref="ArgumentException">value</exception>
        public string Email
        {
            get => email;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(value)} is null");
                }

                Regex emailRegex = new Regex(@"^(?!.*@.*@.*$)(?!.*@.*\-\-.*\..*$)(?!.*@.*\-\..*$)(?!.*@.*\-$)(.*@.+(\..{1,11})?)");

                if (!emailRegex.IsMatch(value))
                {
                    throw new ArgumentException($"{nameof(value)} is wrong email");
                }

                this.email = value;
            }
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(PersonDal other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return id == other.id && string.Equals(name, other.name) && string.Equals(surname, other.surname) && string.Equals(passport, other.passport) && string.Equals(email, other.email);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PersonDal)obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = id;
                hashCode = (hashCode * 397) ^ (name != null ? name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (surname != null ? surname.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (passport != null ? passport.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (email != null ? email.GetHashCode() : 0);

                return hashCode;
            }
        }
    }
}