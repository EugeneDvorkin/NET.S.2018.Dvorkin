using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace MVC.Models
{
    /// <summary>
    /// Definition for person.
    /// </summary>
    public class PersonMvc
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the passport.
        /// </summary>
        /// <value>
        /// The passport.
        /// </value>
        public string Passport { get; set; }


        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
        
        /// <summary>
        /// Gets or sets the accounts.
        /// </summary>
        /// <value>
        /// The accounts.
        /// </value>
        public ObservableCollection<AccountMvc> Accounts { get; set; }
    }
}