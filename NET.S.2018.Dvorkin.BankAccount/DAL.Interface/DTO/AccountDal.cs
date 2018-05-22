using System;
using DAL.Interface.Interfaces;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// Account.
    /// </summary>
    public class AccountDal : IEntity, IEquatable<AccountDal>
    {
        private int id;
        private int personId;
        private int number;
        private decimal balance;
        private int point;
        private int type;
        private bool valid;
        private PersonDal person;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountDal" /> class.
        /// </summary>
        /// <param name="personId">The person identifier.</param>
        /// <param name="number">The number.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="point">The point.</param>
        /// <param name="type">The type.</param>
        public AccountDal(int personId, int number, decimal balance, int point, int type)
        {
            this.PersonId = personId;
            this.Number = number;
            this.Valid = true;
            this.Balance = balance;
            this.Point = point;
            this.Type = type;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        /// <exception cref="System.ArgumentException">value</exception>
        public int Id
        {
            get => id;
            set => id = value < 0 ? throw new ArgumentException($"{nameof(value)} is wrong") : value;
        }

        /// <summary>
        /// Gets or sets the person identifier.
        /// </summary>
        /// <value>
        /// The person identifier.
        /// </value>
        /// <exception cref="System.ArgumentException">value</exception>
        public int PersonId
        {
            get => personId;
            set => personId = value < 0 ? throw new ArgumentException($"{nameof(value)} is wrong") : value;
        }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        /// <exception cref="System.ArgumentException">value</exception>
        public int Number
        {
            get => this.number;
            set => this.number = value < 0 ? throw new ArgumentException($"{nameof(value)} is wrong") : value;
        }

        /// <summary>
        /// Gets or sets money on the accountDal.
        /// </summary>
        /// <value>
        /// The accountDal.
        /// </value>
        /// <exception cref="ArgumentException">value</exception>
        public decimal Balance
        {
            get => this.balance;
            set => this.balance = value < 0 ? throw new ArgumentException($"There is wrong {nameof(value)}") : value;
        }

        /// <summary>
        /// Gets or sets the score of bonus points.
        /// </summary>
        /// <value>
        /// The score.
        /// </value>
        public int Point
        {
            get => point;
            set
            {
                ////if (score - value < 0)
                ////{
                ////    value = score;
                ////}

                this.point = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AccountDal" /> is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if valid; otherwise, <c>false</c>.
        /// </value>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public bool Valid
        {
            get => valid;
            set => valid = balance > 0 ? throw new ArgumentException($"You can't close this account. Count is more, than 0") : value;

        }

        /// <summary>
        /// Gets or sets the type of a accountDal.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        /// <exception cref="ArgumentException">value</exception>
        public int Type
        {
            get => type;
            set => type = value < 0 || value > 4 ? throw new ArgumentException($"{nameof(value)} is wrong") : value;
        }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        /// <value>
        /// The person.
        /// </value>
        /// <exception cref="ArgumentException">value</exception>
        public PersonDal Person
        {
            get => person;
            set => person = value.GetType() == typeof(PersonDal)
                ? value
                : throw new ArgumentException($"{nameof(value)} doesn't current type");
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(AccountDal other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return id == other.id && personId == other.personId && number == other.number && balance == other.balance && point == other.point && type == other.type && valid == other.valid;
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
            return Equals((AccountDal) obj);
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
                hashCode = (hashCode * 397) ^ personId;
                hashCode = (hashCode * 397) ^ number;
                hashCode = (hashCode * 397) ^ balance.GetHashCode();
                hashCode = (hashCode * 397) ^ point;
                hashCode = (hashCode * 397) ^ type;
                hashCode = (hashCode * 397) ^ valid.GetHashCode();

                return hashCode;
            }
        }
    }
}