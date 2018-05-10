using System;
using DAL.Interface.Interfaces;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// Base type for accountDal.
    /// </summary>
    public abstract class AccountDal : IEntity
    {
        private PersonalInfo personalInfo;
        private int number;
        private decimal balance;
        private int point;
        private Type type;
        private bool valid;
        private int id;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountDal"/> class.
        /// </summary>
        /// <param name="personalInfo">The personal information.</param>
        /// <param name="number">The number.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="point">The point.</param>
        /// <param name="type">The type.</param>
        internal AccountDal(int id, PersonalInfo personalInfo, int number, decimal balance, int point, Type type)
        {
            this.Id = id;
            this.PersonalInfo = personalInfo;
            this.Number = number;
            this.Valid = true;
            this.Balance = balance;
            this.Point = point;
            this.Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountDal"/> class.
        /// </summary>
        internal AccountDal()
        {
            this.Valid = true;
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
        /// Gets or sets the personal information.
        /// </summary>
        /// <value>
        /// The personal information.
        /// </value>
        /// <exception cref="System.ArgumentException">value</exception>
        public PersonalInfo PersonalInfo
        {
            get => personalInfo;
            set => personalInfo = value.GetType() != typeof(PersonalInfo) ? throw new ArgumentException($"{nameof(value)} is wrong type") : value;
        }

        /// <summary>
        /// Gets or sets the number of a count.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        /// <exception cref="ArgumentNullException">value</exception>
        /// <exception cref="ArgumentException">value</exception>
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
        public Type Type
        {
            get => type;
            set => type = (value < (Type)1) ? throw new ArgumentException($"{nameof(value)} can't be this value") : value;
        }

        /// <summary>
        /// Calculates the benefits points deposit.
        /// </summary>
        /// <param name="count">The count.</param>
        protected abstract void CalculatePointDeposit(decimal count);

        /// <summary>
        /// Calculates the benefits point withdraw.
        /// </summary>
        /// <param name="count">The count.</param>
        protected abstract void CalculatePointWithdraw(decimal count);

        /// <summary>
        /// Deposits the specified accountDal balance.
        /// </summary>
        /// <param name="count">The deposit.</param>
        /// <exception cref="System.ArgumentException">deposit</exception>
        public void Deposit(decimal count)
        {
            if (Check(this))
            {
                if (count < 0)
                {
                    throw new ArgumentException($"{nameof(count)} is wrong");
                }

                this.Balance = Balance + count;
                CalculatePointDeposit(count);
            }
            else
            {
                throw new ArgumentException($"AccountDal is closed");
            }
        }

        /// <summary>
        /// Withdraws the specified accountDal balance.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <exception cref="System.ArgumentException">
        /// count is less than 0
        /// or
        /// count is more than balance.
        /// </exception>
        public void Withdraw(decimal count)
        {
            if (Check(this))
            {
                if (count < 0)
                {
                    throw new ArgumentException($"{nameof(count)} is wrong");
                }

                if (this.Balance < count)
                {
                    throw new ArgumentException($"{nameof(count)} is more than balance");
                }

                this.Balance = Balance - count;
                CalculatePointWithdraw(count);
            }
            else
            {
                throw new ArgumentException($"AccountDal is closed");
            }

        }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        /// <exception cref="System.ArgumentException">There is money at the balance</exception>
        public void Close()
        {
            if (Check(this))
            {
                if (this.Balance > 0)
                {
                    throw new ArgumentException("There is money at the balance");
                }

                this.Valid = false;
            }
        }

        /// <summary>
        /// Checks the specified accountDal.
        /// </summary>
        /// <param name="accountDal">The accountDal.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">accountDal</exception>
        private bool Check(AccountDal accountDal)
        {
            if (ReferenceEquals(accountDal, null))
            {
                throw new ArgumentNullException($"{nameof(accountDal)} is null");
            }

            return accountDal.Valid;
        }
    }
}