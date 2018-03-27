using System;

namespace NET.S._2018.Dvorkin.Task4
{
    /// <summary>
    /// Validations and builder necessary string
    /// </summary>
    public class Notation
    {
        private int order;
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
            get => order;

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
        public string ActualString { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Notation"/> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public Notation(int order)
        {
            Order = order;
            ActualString = standartString.Substring(0, order);
        }
    }
}
