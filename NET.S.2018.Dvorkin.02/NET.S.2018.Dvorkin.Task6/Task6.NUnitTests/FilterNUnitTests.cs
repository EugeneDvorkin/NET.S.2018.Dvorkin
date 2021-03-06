﻿using System;
using NUnit.Framework;

namespace Task6.NUnitTests
{
    [TestFixture]
    public class FilterNUnitTests
    {
        static int[] arrayForFilter = { 1, 2, 22, 232, 5, 55, 222, 8, 9, 123 };
        static int[] filtredArray = { 2, 22, 232, 222, 123 };
        static int[] arrayForFilterWithNegat = { 1, -2, -22, -232, 5, 55, -222, 8, 9, -123 };
        static int[] filtredArrayWithNegate = { -2, -22, -232, -222, -123 };

        static object[] ListForSort =
        {
            new object[]{ arrayForFilter, filtredArray },
            new object[]{ arrayForFilterWithNegat, filtredArrayWithNegate }
        };

        [Test, TestCaseSource("ListForSort")]
        public void FilterDigit_ArrayFor10Elem_FiltredArray(int[] arrayForFilter, int[] filtredArray)
        {
            Predicate logic = new Predicate(2);
            int[] actualArray = Filter.FilterDigit(arrayForFilter, logic);

            CollectionAssert.AreEqual(filtredArray, actualArray);
        }

        [Test, TestCase(new int[] { 1, 0, 10, 232, 5, 100, 222, 8, 1, 123 }, new int[] { 0, 10, 100 }, 0)]
        public void FilterDigit_ArraySomeIntElem_FiltredArray(int[] arrayForFilter, int[] filtredArray, int flag)
        {
            Predicate logic = new Predicate(flag);
            int[] actualArray = Filter.FilterDigit(arrayForFilter, logic);

            CollectionAssert.AreEqual(filtredArray, actualArray);
        }

        [Test]
        public void FilterDigit_ArrayArgumentNullException_ArgumentNullException()
        {
            Predicate logic = new Predicate(9);
            Assert.That(() => Filter.FilterDigit(null, logic), Throws.ArgumentNullException);
        }
    }
}
