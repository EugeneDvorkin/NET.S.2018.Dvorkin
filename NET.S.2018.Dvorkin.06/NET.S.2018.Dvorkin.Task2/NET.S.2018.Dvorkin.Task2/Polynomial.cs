using System;
using System.Collections;
using System.Linq;

namespace NET.S._2018.Dvorkin.Task2
{
    /// <summary>
    /// Contains methods for polynomials
    /// </summary>
    /// <seealso cref="System.IComparable" />
    public sealed class Polynomial : IComparable, IEquatable<Polynomial>
    {
        #region Properties and constructor
        /// <summary>
        /// The collection of coefficients
        /// </summary>
        private readonly double[] coeff = { };

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="coeff">The coefficients.</param>
        /// <exception cref="ArgumentNullException"> coefficients</exception>
        /// <exception cref="ArgumentException"> coefficients</exception>
        public Polynomial(params double[] coeff)
        {
            if (coeff == null)
            {
                throw new ArgumentNullException($"{nameof(coeff)} is null");
            }

            if (coeff.Length == 0)
            {
                throw new ArgumentException($"{nameof(coeff)} length is 0");
            }

            this.coeff = new double[coeff.Length];
            coeff.CopyTo(this.coeff, 0);
        }

        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public int Length
        {
            get { return this.coeff.Length; }
        }

        /// <summary>
        /// Gets the <see cref="System.Double"/> with the specified indexer.
        /// </summary>
        /// <value>
        /// The <see cref="System.Double"/>.
        /// </value>
        /// <param name="indexer">The indexer.</param>
        /// <returns>Index of current element</returns>
        /// <exception cref="ArgumentException">indexer</exception>
        public double this[int indexer]
        {
            get
            {
                if (indexer < 0 || indexer > this.coeff.Length)
                {
                    throw new ArgumentException($"{nameof(indexer)} is invalid");
                }

                return this.coeff[indexer];
            }
        }
        #endregion

        #region Static methods

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="poly1">The polynomial 1.</param>
        /// <param name="poly2">The polynomial 2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator +(Polynomial poly1, Polynomial poly2) => Sum(poly1, poly2);

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="poly">The polynomial.</param>
        /// <param name="number">The number.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator +(Polynomial poly, double number) => Sum(poly, number);

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="poly1">The polynomial 1.</param>
        /// <param name="poly2">The polynomial 2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator -(Polynomial poly1, Polynomial poly2) => Subtr(poly1, poly2);

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="poly">The polynomial.</param>
        /// <param name="number">The number.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator -(Polynomial poly, double number) => Subtr(poly, number);

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="poly1">The polynomial 1.</param>
        /// <param name="poly2">The polynomial 2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator *(Polynomial poly1, Polynomial poly2) => Mult(poly1, poly2);

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="poly">The polynomial.</param>
        /// <param name="number">The number.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator *(Polynomial poly, double number) => Mult(poly, number);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="poly1">The polynomial 1.</param>
        /// <param name="poly2">The polynomial 2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Polynomial poly1, Polynomial poly2) => Equals(poly1, poly2);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="poly1">The polynomial 1.</param>
        /// <param name="poly2">The polynomial 2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Polynomial poly1, Polynomial poly2) => !Equals(poly1, poly2);

        /// <summary>
        /// Adds the specified polynomial 1 to polynomial 2.
        /// </summary>
        /// <param name="poly1">The polynomial 1.</param>
        /// <param name="poly2">The polynomial 2.</param>
        /// <returns>Sum of polynomial 1 and polynomial 2.</returns>
        public static Polynomial Add(Polynomial poly1, Polynomial poly2) => Sum(poly1, poly2);

        /// <summary>
        /// Adds the specified polynomial 1 to number.
        /// </summary>
        /// <param name="poly">The polynomial.</param>
        /// <param name="number">The number.</param>
        /// <returns>Sum of polynomial and number.</returns>
        public static Polynomial Add(Polynomial poly, double number) => Sum(poly, number);

        /// <summary>
        /// Subtracts the specified polynomial 1 to polynomial 2.
        /// </summary>
        /// <param name="poly1">The polynomial 1.</param>
        /// <param name="poly2">The polynomial 2.</param>
        /// <returns>Subtract of polynomial 1 and polynomial 2.</returns>
        public static Polynomial Subtract(Polynomial poly1, Polynomial poly2) => Subtr(poly1, poly2);

        /// <summary>
        /// Subtracts the specified polynomial to number.
        /// </summary>
        /// <param name="poly">The to number.</param>
        /// <param name="number">The number.</param>
        /// <returns>Subtract of polynomial and number.</returns>
        public static Polynomial Subtract(Polynomial poly, double number) => Subtr(poly, number);//=> Sum(poly, -number);

        /// <summary>
        /// Multiplies the specified polynomial 1 to polynomial 2.
        /// </summary>
        /// <param name="poly1">The polynomial 1.</param>
        /// <param name="poly2">The polynomial 2.</param>
        /// <returns>Multiplies of polynomial 1 and polynomial 2.</returns>
        public static Polynomial Multiply(Polynomial poly1, Polynomial poly2) => Mult(poly1, poly2);

        /// <summary>
        /// Multiplies the specified polynomial to number.
        /// </summary>
        /// <param name="poly">The polynomial.</param>
        /// <param name="number">The number.</param>
        /// <returns>Multiplies of polynomial and number.</returns>
        public static Polynomial Multiply(Polynomial poly, double number) => Mult(poly, number);
        #endregion

        #region All public methods(include override)

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. 
        /// The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj" /> in the sort order. 
        /// Zero This instance occurs in the same position in the sort order as <paramref name="obj" />. 
        /// Greater than zero This instance follows <paramref name="obj" /> in the sort order.
        /// </returns>
        public int CompareTo(object obj)
        {
            Polynomial poly = obj as Polynomial;
            Polynomial.Check(poly);
            double[] longest = (poly.Coeff().Length > this.Coeff().Length) ? poly.Coeff() : this.Coeff();
            poly.Coeff().Reverse();
            this.Coeff().Reverse();
            for (int i = 0; i < longest.Length; i++)
            {
                if (poly[i] > this[i])
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }

            return 0;
        }

        /// <summary>
        /// Get current coefficients of the polynomial.
        /// </summary>
        /// <returns>Coefficients.</returns>
        public double[] Coeff()
        {
            double[] coeff = new double[this.coeff.Length];
            this.coeff.CopyTo(coeff, 0);

            return coeff;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            Polynomial poly = obj as Polynomial;
            Check(poly);

            if (ReferenceEquals(poly, null))
            {
                return false;
            }

            if (poly.Coeff().Length != this.Coeff().Length)
            {
                return false;
            }

            for (int i = 0; i < poly.Coeff().Length; i++)
            {
                if (poly.Coeff()[i] != this.Coeff()[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(this, other);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string result = string.Empty;
            foreach (var item in this.coeff)
            {
                result += item + " ";
            }

            return result;
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Sums the specified polynomial 1 to polynomial 2.
        /// </summary>
        /// <param name="poly1">The polynomial 1.</param>
        /// <param name="poly2">The polynomial 2.</param>
        /// <returns>Sum of polynomial 1 and polynomial 2.</returns>
        private static Polynomial Sum(Polynomial poly1, Polynomial poly2)
        {
            Polynomial.Check(poly1, poly2);
            double[] result = Copy(poly1, poly2);
            poly1.Coeff().CopyTo(result, 0);

            for (int i = 0; i < poly2.Coeff().Length; i++)
            {
                result[i] += poly2[i];
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Sums the specified polynomial 1 to number..
        /// </summary>
        /// <param name="poly">The polynomial.</param>
        /// <param name="number">The number.</param>
        /// <returns>Sums of polynomial and number.</returns>
        private static Polynomial Sum(Polynomial poly, double number)
        {
            Polynomial.Check(poly);
            double[] result = new double[poly.Coeff().Length];
            poly.Coeff().CopyTo(result, 0);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] += number;
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Subtracts the specified polynomial 1 to polynomial 2.
        /// </summary>
        /// <param name="poly1">The polynomial 1.</param>
        /// <param name="poly2">The polynomial 2.</param>
        /// <returns>Subtract of polynomial 1 and polynomial 2.</returns>
        private static Polynomial Subtr(Polynomial poly1, Polynomial poly2)
        {
            Polynomial.Check(poly1, poly2);
            double[] result = Copy(poly1, poly2);
            poly1.Coeff().CopyTo(result, 0);

            for (int i = 0; i < poly2.Coeff().Length; i++)
            {
                result[i] -= poly2[i];
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Subtracts the specified polynomial to number.
        /// </summary>
        /// <param name="poly">The polynomial.</param>
        /// <param name="number">The number.</param>
        /// <returns>Subtracts of polynomial and number.</returns>
        private static Polynomial Subtr(Polynomial poly, double number)
        {
            Polynomial.Check(poly);
            double[] result = new double[poly.Coeff().Length];
            poly.Coeff().CopyTo(result, 0);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] -= number;
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Multiplies the specified polynomial 1 to polynomial 2.
        /// </summary>
        /// <param name="poly1">The polynomial 1.</param>
        /// <param name="poly2">The polynomial 2.</param>
        /// <returns>Multiplies of polynomial 1 and polynomial 2.</returns>
        private static Polynomial Mult(Polynomial poly1, Polynomial poly2)
        {
            Polynomial.Check(poly1, poly2);
            double[] result = Copy(poly1, poly2);
            poly1.Coeff().CopyTo(result, 0);
            for (int j = 0; j < poly1.Length; j++)
            {
                for (int i = 0; i < poly2.Length; i++)
                {
                    result[j + i] += poly2[i] + poly1[j];
                }
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Multiplies the specified polynomial to number.
        /// </summary>
        /// <param name="poly">The polynomial.</param>
        /// <param name="number">The number.</param>
        /// <returns>Multiplies of polynomial and number.</returns>
        private static Polynomial Mult(Polynomial poly, double number)
        {
            Polynomial.Check(poly);
            double[] result = new double[poly.Coeff().Length];
            poly.Coeff().CopyTo(result, 0);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] *= number;
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Validation of polynomial 1 and polynomial 2.
        /// </summary>
        /// <param name="poly1">The polynomial 1.</param>
        /// <param name="poly2">The polynomial 2.</param>
        private static void Check(Polynomial poly1, Polynomial poly2)
        {
            Check(poly1);
            Check(poly2);
        }

        /// <summary>
        /// Validation of polynomial.
        /// </summary>
        /// <param name="poly">The polynomial.</param>
        /// <exception cref="ArgumentNullException">polynomial</exception>
        /// <exception cref="ArgumentException">polynomial</exception>
        private static void Check(Polynomial poly)
        {
            if (poly is null)
            {
                throw new ArgumentNullException($"{nameof(poly)} is null");
            }

            if (poly.Coeff().Length == 0)
            {
                throw new ArgumentException($"{nameof(poly)} has 0 arguments");
            }
        }

        /// <summary>
        /// Copies the specified poly1 or poly2, consists of which is longer.
        /// </summary>
        /// <param name="poly1">The poly1.</param>
        /// <param name="poly2">The poly2.</param>
        /// <returns>New longest array from poly1 or poly2.</returns>
        private static double[] Copy(Polynomial poly1, Polynomial poly2)
        {
            double[] longest = (poly1.Coeff().Length > poly2.Coeff().Length) ? poly1.Coeff() : poly2.Coeff();
            double[] result = new double[longest.Length];

            return result;
        }
        #endregion
    }
}