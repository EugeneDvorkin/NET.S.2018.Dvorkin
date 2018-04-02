using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task6;


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
            Predicate logic = new Predicate(2);

            int[] actualArray = Filter.FilterDigit(arrayForFilter, logic);

            CollectionAssert.AreEqual(filtredArray, actualArray);
        }

        [TestMethod]
        public void FilterDigit_ArrayWithNegatElem_FiltredArray()
        {
            int[] arrayForFilter = { 1, -2, -22, -232, 5, 55, -222, 8, 9, -123 };
            int[] filtredArray = { -2, -22, -232, -222, -123 };
            Predicate logic = new Predicate(2);

            int[] actualArray = Filter.FilterDigit(arrayForFilter, logic);

            CollectionAssert.AreEqual(filtredArray, actualArray);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilterDigir_DigitIsNotADigit_ArgumentOutOfRangeException()
        {
            int[] arrayForFilter = { 1, -2, -22, -232, 5, 55, -222, 8, 9, -123 };
            int[] filtredArray = { -2, -22, -232, -222, -123 };
            Predicate logic = new Predicate(10);

            int[] actualArray = Filter.FilterDigit(arrayForFilter, logic);

            CollectionAssert.AreEqual(filtredArray, actualArray);
        }   
        
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource ("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\TestCases.xml"
            , "TestCase",DataAccessMethod.Sequential)]        
        public void FilterDigit_UnFiltredArrays_FiltredArrays()
        {
            int[] arrayForFiltering = Array.ConvertAll(Convert.ToString(TestContext.DataRow["Actual"]).Split(' '), int.Parse);
            int[] filteredArray = Array.ConvertAll(Convert.ToString(TestContext.DataRow["ExpectedResult"]).Split(' '), int.Parse);
            int flag = Convert.ToInt32(TestContext.DataRow["Filter"]);
            Predicate logic = new Predicate(flag);

            int[] actualArray = Filter.FilterDigit(arrayForFiltering, logic);

            CollectionAssert.AreEqual(filteredArray, actualArray);
        }
    }
}
