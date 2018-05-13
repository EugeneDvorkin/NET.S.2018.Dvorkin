using System;
using System.Text.RegularExpressions;

namespace Bll.Interface.Entities
{
    /// <summary>
    /// Contains definitions for BLL logic for account.
    /// </summary>
    public class PersoneBll
    {
        private string name;
        private string surname;
        private string passport;
        private string email;
        private int id;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersoneBll" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="surname">The surname.</param>
        /// <param name="passport">The passport.</param>
        /// <param name="email">The email.</param>
        public PersoneBll(int id, string name, string surname, string passport, string email = null)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Passport = passport;
            this.Email = email;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersoneBll"/> class.
        /// </summary>
        public PersoneBll()
        {
        }

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
    }
}