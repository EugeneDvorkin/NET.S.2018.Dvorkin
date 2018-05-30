using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace Bll.Interface.Entities
{
    /// <summary>
    /// Contains definitions for BLL logic for account.
    /// </summary>
    public class PersonBll
    {
        private string name;
        private string surname;
        private string passport;
        private string email;
        private ObservableCollection<AccountBll> accounts;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonBll" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="surname">The surname.</param>
        /// <param name="passport">The passport.</param>
        /// <param name="email">The email.</param>
        public PersonBll(string name, string surname, string passport, string email = null)
        {
            this.Name = name;
            this.Surname = surname;
            this.Passport = passport;
            this.Email = email;
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
        /// <exception cref="ArgumentException">value</exception>
        public string Email
        {
            get => email;
            set
            {
                Regex emailRegex = new Regex(@"^(?!.*@.*@.*$)(?!.*@.*\-\-.*\..*$)(?!.*@.*\-\..*$)(?!.*@.*\-$)(.*@.+(\..{1,11})?)");

                if (!ReferenceEquals(value, null) && !emailRegex.IsMatch(value))
                {
                    throw new ArgumentException($"{nameof(value)} is wrong email");
                }

                this.email = value;
            }
        }

        /// <summary>
        /// Gets or sets the accounts.
        /// </summary>
        /// <value>
        /// The accounts.
        /// </value>
        public ObservableCollection<AccountBll> Accounts { get; set; }
    }
}