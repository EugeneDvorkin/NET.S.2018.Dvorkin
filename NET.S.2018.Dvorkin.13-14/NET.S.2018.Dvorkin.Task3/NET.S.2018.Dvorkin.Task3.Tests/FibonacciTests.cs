using System;
using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;

namespace NET.S._2018.Dvorkin.Task3.Tests
{
    [TestFixture]
    public class FibonacciTests
    {
        [TestCase(6)]
        public void FibonacciSequence_ValidCount_ValidResult(int count)
        {
            List<BigInteger> actual = new List<BigInteger>();
            foreach (BigInteger i in Fibonacci.FibonachGenerator(count))
            {
                actual.Add(i);
            }

            List<BigInteger> expected = new List<BigInteger>() { new BigInteger(1), new BigInteger(1), new BigInteger(2), new BigInteger(3), new BigInteger(5), new BigInteger(8) };
            CollectionAssert.AreEqual(expected,actual);
        }

        [TestCase(-5)]
        public void FibonacciSequence_InvalidCount_ArgumentException(int count)
        {
            Assert.Throws<ArgumentException>(() => Fibonacci.FibonachGenerator(count));
        }
    }
}
