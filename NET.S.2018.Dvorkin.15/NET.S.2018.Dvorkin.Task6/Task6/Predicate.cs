using System;

namespace Task6
{
    /// <summary>
    /// Contains logic for filter.
    /// </summary>
    /// <seealso cref="int" />
    public class Predicate : IPredicate<int>
    {
        private int digit;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Predicate"/> class.
        /// </summary>
        /// <param name="digit">The digit.</param>
        public Predicate(int digit)
        {
            this.Digit = digit;
        }

        /// <summary>
        /// Gets the digit.
        /// </summary>
        /// <value>
        /// The digit.
        /// </value>
        /// <exception cref="ArgumentException">digit</exception>
        public int Digit
        {
            get => digit;
            private set
            {
                if (digit > 9 || digit < 0)
                {
                    throw new ArgumentException($"{nameof(digit)} is not a digit");
                }

                digit = value;
            }
        }

        /// <summary>
        /// Determines whether the specified element is match.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        ///   <c>true</c> if the specified element is match; otherwise, <c>false</c>.
        /// </returns>
        public bool IsMatch(int element)
        {
            if (element < 0)
            {
                element = Math.Abs(element);
            }

            if (element == digit)
            {
                return true;
            }

            while (element > 0)
            {
                if (element % 10 == digit)
                {
                    return true;
                }

                element /= 10;
            }

            return false;
        }
    }
}
