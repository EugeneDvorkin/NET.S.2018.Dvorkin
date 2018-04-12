using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NET.S._2018.Dvorkin.Task3.Tests
{
    [TestFixture]
    public class FibonacciTests
    {
        [TestCase(6)]
        public void FibonacciSequence_ValidCount_ValidResult(int count)
        {
            List<int> actual = new List<int>();
            foreach (int i in Fibonacci.FibonacciSequence(count))
            {
                actual.Add(i);
            }

            List<int> expected = new List<int>() { 1, 1, 2, 3, 5, 8 };
            CollectionAssert.AreEqual(expected,actual);
        }

        [TestCase(-5)]
        public void FibonacciSequence_InvalidCount_ArgumentException(int count)
        {
            Assert.Throws<ArgumentException>(() => Fibonacci.FibonacciSequence(count));
        }
    }
}
