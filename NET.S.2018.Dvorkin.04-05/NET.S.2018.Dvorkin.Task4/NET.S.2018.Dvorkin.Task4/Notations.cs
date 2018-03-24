using System;

namespace NET.S._2018.Dvorkin.Task4
{
    /// <summary>
    /// Validations and builder necessary string
    /// </summary>
    public class Notations
    {
        private int order;
        private string _string;
        private string standartString = "0123456789ABCDEF";

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        /// <exception cref="ArgumentException">order</exception>
        public int Order
        {
            get
            {
                return order;
            }

            set
            {
                if (value < 2 || value > 16)
                {
                    throw new ArgumentException($"{nameof(order)} is out of range");
                }
                order = value;
            }
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <value>
        /// The string.
        /// </value>
        public string String
        {
            get
            {
                return _string;
            }
            private set
            {                
                _string = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Notations"/> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public Notations(int order)
        {
            Order = order;
            String = standartString.Substring(0, order);
        }
    }
}
