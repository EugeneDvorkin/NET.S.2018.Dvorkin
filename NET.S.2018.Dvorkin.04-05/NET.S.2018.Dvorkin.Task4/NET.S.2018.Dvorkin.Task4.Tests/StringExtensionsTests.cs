using System;
using NUnit.Framework;

namespace NET.S._2018.Dvorkin.Task4.Tests
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [TestCase("0110111101100001100001010111111", 2, 934331071)]
        [TestCase("01101111011001100001010111111", 2, 233620159)]
        [TestCase("11101101111011001100001010", 2, 62370570)]
        [TestCase("1AeF101", 16, 28242177)]
        [TestCase("1ACB67", 16, 1756007)]
        [TestCase("764241", 8, 256161)]
        [TestCase("10", 5, 5)]
        public void ToNumber_ValidParams_ValidResult(string source, int order, int expectedResult)
        {
            int actualresult = source.ToNumber(new Notation(order));

            Assert.AreEqual(expectedResult, actualresult);
        }

        [TestCase("0110111101100001100001010111111", 17)]
        [TestCase("0110111101100001100001010111111", 1)]       
        [TestCase("764241", 20)]
        [TestCase("1AeF101", 2)]
        [TestCase("SA123", 2)]
        public void ToNumber_InvalidParams_ArgumentExceptions(string source, int order)
        {
            Assert.Throws<ArgumentException>(()=>source.ToNumber(new Notation(order)));
        }

        [TestCase("11111111111111111111111111111111", 2)]
        public void ToNumber_InvalidParams_OverFlowException(string source, int order)
        {
            Assert.Throws<OverflowException>(() => source.ToNumber(new Notation(order)));
        }
    }
}
