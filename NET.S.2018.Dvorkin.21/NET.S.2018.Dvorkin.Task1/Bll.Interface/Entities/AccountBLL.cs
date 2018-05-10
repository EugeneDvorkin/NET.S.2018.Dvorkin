using System;

namespace Bll.Interface.Entities
{
    /// <summary>
    /// Contains definitions for BLL logic for account.
    /// </summary>
    public class AccountBll
    {
        private int id;
        private int personeId;
        private int number;
        private decimal balance;
        private int point;
        private int _typeIdId;
        private bool valid;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountBll"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="personalId">The personal identifier.</param>
        /// <param name="number">The number.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="point">The point.</param>
        /// <param name="typeId">The type identifier.</param>
        internal AccountBll(int id, int personalId, int number, decimal balance, int point, int typeId)
        {
            this.Id = id;
            this.PersoneId = personalId;
            this.Number = number;
            this.Valid = true;
            this.Balance = balance;
            this.Point = point;
            this.TypeId = typeId;
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
            get =>id;
            set => id = value < 0 ? throw new ArgumentException($"{nameof(value)} is wrong") : value;
        }

        /// <summary>
        /// Gets or sets the persone identifier.
        /// </summary>
        /// <value>
        /// The persone identifier.
        /// </value>
        /// <exception cref="System.ArgumentException">value</exception>
        public int PersoneId
        {
            get => personeId;
            set => personeId = value < 0 ? throw new ArgumentException($"{nameof(value)} is wrong") : value;
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
            set => number = value < 0 ? throw new ArgumentException($"{nameof(value)} is wrong") : value;
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
            set => valid = balance > 0 ? throw new ArgumentException($"You can't close this account. Count is more, than 0") : value;

        }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        /// <exception cref="System.ArgumentException">value</exception>
        public decimal Balance
        {
            get => this.balance;
            set => this.balance = value < 0 ? throw new ArgumentException($"There is wrong {nameof(value)}") : value;
        }

        /// <summary>
        /// Gets or sets the point.
        /// </summary>
        /// <value>
        /// The point.
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
        /// Gets or sets the type identifier.
        /// </summary>
        /// <value>
        /// The type identifier.
        /// </value>
        /// <exception cref="System.ArgumentException">value</exception>
        public int TypeId
        {
            get => _typeIdId;
            set =>_typeIdId=value<0? throw new ArgumentException($"There is wrong {nameof(value)}") : value;
        }
    }
}