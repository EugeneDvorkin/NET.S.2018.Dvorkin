using System;
using NUnit.Framework;

namespace NET.S._2018.Dvorkin.Task2.Tests
{
    [TestFixture]
    public class BinaryFindTests
    {
        [TestCase(new int[] { 2, 4, 3, 7, 6, 5, 8 }, 4, ExpectedResult = 2)]
        public int BinaryFind_ValidIntArrayInt_ValidResult(int[] array, int elem)
        {
            return BinaryFind.BinaryFindSearch(array, elem);
        }

        [TestCase(new string[] { "a", "b", "e", "c", "d" }, "b", ExpectedResult = 1)]
        public int BinaryFind_ValidIntArrayString_ValidResult(string[] array, string elem)
        {
            return BinaryFind.BinaryFindSearch(array, elem);
        }
        
    }
}
