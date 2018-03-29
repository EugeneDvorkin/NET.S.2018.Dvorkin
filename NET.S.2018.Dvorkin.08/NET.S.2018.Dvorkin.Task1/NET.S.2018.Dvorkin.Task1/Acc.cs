using System;
using System.Text.RegularExpressions;

namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Contains description of a bank account
    /// </summary>
    public class Acc
    {
        #region Fields
        private string number;
        private string name;
        private string surname;
        private string passport;
        private decimal account;
        private int score;
        private AccType type;
        private bool valid;
        private readonly Regex numbeRegex = new Regex(@"^[0-9A-Z]{15}([A - Z]{0,1})?$");
        private readonly Regex nameRegex = new Regex(@"^[A-Z]{1}[a-z]");
        private readonly Regex passportRegex = new Regex(@"^[0-9A-Z]");

        public enum AccType
        {
            Base = 1,
            Silver,
            Gold,
            Platinum
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the number of a count.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        /// <exception cref="ArgumentNullException">value</exception>
        /// <exception cref="ArgumentException">value</exception>
        public string Number
        {
            get => number;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(value)} is null");
                }

                if (numbeRegex.IsMatch(value) == false)
                {
                    throw new ArgumentException($"{nameof(value)} doesn't match rules");
                }

                number = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of a user.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <exception cref="ArgumentNullException">value</exception>
        /// <exception cref="ArgumentException">value</exception>
        public string Name
        {
            get => name;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(value)} is null");
                }

                if (nameRegex.IsMatch(value) == false)
                {
                    throw new ArgumentException($"{nameof(value)} is wrong name");
                }

                name = value;
            }
        }

        /// <summary>
        /// Gets or sets the surname of a user.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        /// <exception cref="ArgumentNullException">value</exception>
        /// <exception cref="ArgumentException">value</exception>
        public string Surname
        {
            get => surname;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(value)} is null");
                }

                if (nameRegex.IsMatch(value) == false)
                {
                    throw new ArgumentException($"{nameof(value)} is wrong surname");
                }

                surname = value;
            }
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

                if (passportRegex.IsMatch(value) == false)
                {
                    throw new ArgumentException($"{nameof(value)} is wrong passport");
                }

                passport = value;
            }
        }

        /// <summary>
        /// Gets or sets money on the account.
        /// </summary>
        /// <value>
        /// The account.
        /// </value>
        /// <exception cref="ArgumentException">value</exception>
        public decimal Account
        {
            get => account;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)} is more than {nameof(account)}. There is wrong{nameof(value)}");
                }

                account = value;
            }
        }

        /// <summary>
        /// Gets or sets the score of bonus points.
        /// </summary>
        /// <value>
        /// The score.
        /// </value>
        public int Score
        {
            get => score;
            set
            {
                //if (score - value < 0)
                //{
                //    value = score;
                //}

                score = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of a account.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        /// <exception cref="ArgumentException">value</exception>
        public AccType Type
        {
            get => type;
            set
            {
                if (value < (AccType)1 || value > (AccType)4)
                {
                    throw new ArgumentException($"{nameof(value)} can't be this value");
                }

                type = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Acc"/> is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if valid; otherwise, <c>false</c>.
        /// </value>
        /// <exception cref="ArgumentException"></exception>
        public bool Valid
        {
            get => valid;
            set
            {
                if (account > 0)
                {
                    throw new ArgumentException($"You can't close this account. Count is more, than 0");
                }

                valid = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Acc"/> class.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="name">The name.</param>
        /// <param name="surname">The surname.</param>
        /// <param name="passport">The passport.</param>
        /// <param name="account">The account.</param>
        /// <param name="score">The score.</param>
        /// <param name="accType">Type of the account.</param>
        public Acc(string number, string name, string surname, string passport, decimal account = 0, int score = 0, AccType accType = (AccType)1)
        {
            this.Number = number;
            this.Name = name;
            this.Surname = surname;
            this.Passport = passport;
            this.Valid = true;
            this.Score = score;
            this.Type = accType;
            this.Account = account;
        }
        #endregion
    }
}
