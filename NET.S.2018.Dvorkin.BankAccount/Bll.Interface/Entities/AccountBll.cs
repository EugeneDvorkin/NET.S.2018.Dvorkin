using System;

namespace Bll.Interface.Entities
{
    /// <summary>
    /// Contains definitions for BLL logic for account.
    /// </summary>
    public abstract class AccountBll
    {
        private int personeId;
        private int number;
        protected decimal balance;
        private int point;
        private TypeBll typeId;
        private bool valid;
        private PersonBll person;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountBll"/> class.
        /// </summary>
        /// <param name="personalId">The personal identifier.</param>
        /// <param name="number">The number.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="point">The point.</param>
        /// <param name="typeId">The type identifier.</param>
        protected AccountBll(int personalId, int number, decimal balance, int point, TypeBll typeId)
        {
            this.PersoneId = personalId;
            this.Number = number;
            this.Valid = true;
            Deposit(balance);
            this.Point = point;
            this.TypeId = typeId;
        }

        /// <summary>
        /// Gets or sets the person identifier.
        /// </summary>
        /// <value>
        /// The person identifier.
        /// </value>
        /// <exception cref="System.ArgumentException">value</exception>
        public int PersoneId
        {
            get => personeId;
            private set => personeId = value < 0 ? throw new ArgumentException($"{nameof(value)} is wrong") : value;
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
            get => number;
            private set => number = value < 0 ? throw new ArgumentException($"{nameof(value)} is wrong") : value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AccountBll"/> is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if valid; otherwise, <c>false</c>.
        /// </value>
        /// <exception cref="System.ArgumentException"></exception>
        public bool Valid
        {
            get => valid;
            private set => valid = balance > 0 ? throw new ArgumentException($"You can't close this account. Count is more, than 0") : value;

        }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        /// <exception cref="System.ArgumentException">value</exception>
        public abstract decimal Balance { get; protected set; }

        /// <summary>
        /// Gets or sets the point.
        /// </summary>
        /// <value>
        /// The point.
        /// </value>
        public int Point
        {
            get => point;
            protected set
            {
                if (Point - value < 0)
                {
                    value = Point;
                }

                this.point = value;
            }
        }

        /// <summary>
        /// Gets or sets the type identifier.
        /// </summary>
        /// <value>
        /// The type identifier.
        /// </value>
        /// <exception cref="System.ArgumentException">value</exception>
        public TypeBll TypeId
        {
            get => typeId;
            private set => typeId = value < 0 ? throw new ArgumentException($"There is wrong {nameof(value)}") : value;
        }

        public PersonBll Person
        {
            get => person;
            set => person = value.GetType() == typeof(PersonBll)
                ? value
                : throw new ArgumentException($"{nameof(value)} is wrong type");
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
        /// <exception cref="System.ArgumentException">count is less than 0
        /// or
        /// count is more than balance.</exception>
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
                if (this.Balance > 0 || this.Balance < 0)
                {
                    throw new ArgumentException("There is money at the balance");
                }

                this.Valid = false;
            }
        }

        /// <summary>
        /// Checks the specified accountDal.
        /// </summary>
        /// <param name="account">The accountDal.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">accountDal</exception>
        private bool Check(AccountBll account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException($"{nameof(account)} is null");
            }

            return account.Valid;
        }
    }
}