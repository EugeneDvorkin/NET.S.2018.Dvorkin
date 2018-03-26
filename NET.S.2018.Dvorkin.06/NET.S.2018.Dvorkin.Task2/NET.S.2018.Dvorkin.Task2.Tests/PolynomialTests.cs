using System;
using NUnit.Framework;

namespace NET.S._2018.Dvorkin.Task2.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [TestCase("1 2 3 4 5 6 7 ", 1, 2, 3, 4, 5, 6, 7)]
        [TestCase("1,5 2,5 3,5 4,5 5,5 6,5 7,5 ", 1.5, 2.5, 3.5, 4.5, 5.5, 6.5, 7.5)]
        public void PolynomialToString_ValidParams_ValidString(string expected, params double[] test)
        {
            Polynomial polynomial = new Polynomial(test);
            Assert.AreEqual(expected, polynomial.ToString());
        }

        [TestCase]
        public void PolynomialToString_InvalidParams_ArgumentExeptions(params double[] test)
        {
            Polynomial polynomial;
            Assert.Throws<ArgumentException>(() => polynomial = new Polynomial(test));
        }

        [TestCase]
        public void PolynomialAdd_ValidTwoPolynomial_ValidResult()
        {
            Polynomial poly1 = new Polynomial(1, 2, 3);
            Polynomial poly2 = new Polynomial(1, 2, 3);
            Polynomial result = Polynomial.Add(poly1, poly2);

            Polynomial expected = new Polynomial(2, 4, 6);

            Assert.AreEqual(expected, result);
        }

        [TestCase]
        public void PolynomialAdd_ValidParams_ValidResult()
        {
            Polynomial poly1 = new Polynomial(2, 4, 6);
            Polynomial poly2 = new Polynomial(1, 2, 3);
            Polynomial result = poly1 - poly2;

            Polynomial expected = new Polynomial(1, 2, 3);
            
            Assert.AreEqual(expected, result);
        }
    }
}
