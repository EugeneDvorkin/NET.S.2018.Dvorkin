using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorting.Tests
{
    /// <summary>
    /// Class for sorting testing 
    /// </summary>
    [TestClass]
    public class SortingTests
    {
        /// <summary>
        /// Test for Quick Sort. Array contains unique elements
        /// </summary>
        [TestMethod]
        public void QuickSortTest_Array10Start0End10_SortedArray()
        {
            int[] arrayforsort = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            int[] sortedarray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int[] sortingarray = Sorting.QuickSort(arrayforsort, 0, arrayforsort.Length - 1);

            CollectionAssert.AreEqual(sortedarray, sortingarray);
        }

        /// <summary>
        /// Test for Quick Sort. Array contains repetitive elements
        /// </summary>
        [TestMethod]
        public void QuickSortTest_ArrayStart0End10WithRepititiveElements_SortedArray()
        {
            int[] arrayforsort = { 9, 9, 8, 8, 7, 7, 6, 6, 5, 5, 4, 4, 3, 3 };
            int[] sortedarray = { 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };

            int[] sortingarray = Sorting.QuickSort(arrayforsort, 0, arrayforsort.Length - 1);

            CollectionAssert.AreEqual(sortedarray, sortingarray);
        }

        /// <summary>
        /// Test for Quick Sort. Catch IndexOutOfRangeException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void QuickSortTest_ArraySortingFromEndToStart_IndexOutOfRangeException()
        {
            int[] arrayforsort = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            int[] sortedarray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int[] sortingarray = Sorting.QuickSort(arrayforsort, arrayforsort.Length - 1, 0);

            CollectionAssert.AreEqual(sortedarray, sortingarray);
        }

        /// <summary>
        /// Test for Merge Sort. Array contains unique elements
        /// </summary>
        [TestMethod]
        public void MergeSortTest_ArrayWithUnicElement_SortedArray()
        {
            int[] arrayforsort = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            int[] sortedarray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int[] sortingarray = Sorting.MergeSort(arrayforsort, 0, arrayforsort.Length - 1);

            CollectionAssert.AreEqual(sortedarray, sortingarray);
        }

        /// <summary>
        /// Test for Quick Sort. Array contains repetitive elements
        /// </summary>
        [TestMethod]
        public void MergeSortTest_ArrayWithRepititiveElement_SortedArray()
        {
            int[] arrayforsort = { 9, 9, 8, 8, 7, 7, 6, 6, 5, 5, 4, 4, 3, 3 };
            int[] sortedarray = { 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };

            int[] sortingarray = Sorting.MergeSort(arrayforsort, 0, arrayforsort.Length - 1);

            CollectionAssert.AreEqual(sortedarray, sortingarray);
        }
    }
}
