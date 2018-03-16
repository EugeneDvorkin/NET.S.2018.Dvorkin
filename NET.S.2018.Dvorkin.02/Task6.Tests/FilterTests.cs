using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Task6.Tests
{
    [TestClass]
    public class FilterTests
    {
        [TestMethod]
        public void FilterDigit_ArrayFor10Elem_FiltredArray()
        {
            int[] arrayForFilter = { 1, 2, 22, 232, 5, 55, 222, 8, 9, 123 };
            int[] filtredArray = { 2, 22, 232, 222, 123 };

            int[] actualArray = Filter.FilterDigit(arrayForFilter, 2);

            CollectionAssert.AreEqual(filtredArray, actualArray);
        }

        [TestMethod]
        public void FilterDigit_ArrayWithNegatElem_FiltredArray()
        {
            int[] arrayForFilter = { 1, -2, -22, -232, 5, 55, -222, 8, 9, -123 };
            int[] filtredArray = { -2, -22, -232, -222, -123 };

            int[] actualArray = Filter.FilterDigit(arrayForFilter, 2);

            CollectionAssert.AreEqual(filtredArray, actualArray);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilterDigir_DigitIsNotADigit_ArgumentOutOfRangeException()
        {
            int[] arrayForFilter = { 1, -2, -22, -232, 5, 55, -222, 8, 9, -123 };
            int[] filtredArray = { -2, -22, -232, -222, -123 };

            int[] actualArray = Filter.FilterDigit(arrayForFilter, 10);

            CollectionAssert.AreEqual(filtredArray, actualArray);
        }        
    }
}
