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
            int[] arrayForSort = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            int[] sortedArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Sorting.QuickSort(arrayForSort, arrayForSort.Length - 1, 0);

            CollectionAssert.AreEqual(sortedArray, arrayForSort);
        }

        /// <summary>
        /// Test for Quick Sort. Array contains repetitive elements
        /// </summary>
        [TestMethod]
        public void QuickSortTest_ArrayStart0End10WithRepititiveElements_SortedArray()
        {
            int[] arrayForSort = { 9, 9, 8, 8, 7, 7, 6, 6, 5, 5, 4, 4, 3, 3 };
            int[] sortedArray = { 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };

            Sorting.QuickSort(arrayForSort, arrayForSort.Length - 1, 0);

            CollectionAssert.AreEqual(sortedArray, arrayForSort);
        }

        /// <summary>
        /// Test for Quick Sort. Array contains random elements
        /// </summary>
        [TestMethod]
        public void QuickSortTest_Array1000RandomElements_SortedArray()
        {
            Random random = new Random();
            int[] arrayForSort = new int[2000000];
            foreach (var item in arrayForSort)
            {
                arrayForSort[item] = random.Next(int.MinValue, int.MaxValue);
            }
            int[] sortedArray = new int[arrayForSort.Length];
            Array.Copy(arrayForSort, sortedArray, sortedArray.Length);
            Array.Sort(sortedArray);

            Sorting.QuickSort(arrayForSort, arrayForSort.Length - 1, 0);

            CollectionAssert.AreEqual(sortedArray, arrayForSort);
        }

        /// <summary>
        /// Test for Quick Sort. Catch IndexOutOfRangeException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void QuickSortTest_ArraySortingFromEndToStart_IndexOutOfRangeException()
        {
            int[] arrayForSort = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            int[] sortedArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Sorting.QuickSort(arrayForSort, 0, arrayForSort.Length - 1);

            CollectionAssert.AreEqual(sortedArray, arrayForSort);
        }

        /// <summary>
        /// Test for Merge Sort. Array contains unique elements
        /// </summary>
        [TestMethod]
        public void MergeSortTest_ArrayWithUnicElement_SortedArray()
        {
            int[] arrayForSort = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            int[] sortedArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Sorting.MergeSort(arrayForSort, arrayForSort.Length - 1, 0);

            CollectionAssert.AreEqual(sortedArray, arrayForSort);
        }

        /// <summary>
        /// Test for Quick Sort. Array contains repetitive elements
        /// </summary>
        [TestMethod]
        public void MergeSortTest_ArrayWithRepititiveElement_SortedArray()
        {
            int[] arrayForSort = { 9, 9, 8, 8, 7, 7, 6, 6, 5, 5, 4, 4, 3, 3 };
            int[] sortedArray = { 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };

            Sorting.MergeSort(arrayForSort, arrayForSort.Length - 1, 0);

            CollectionAssert.AreEqual(sortedArray, arrayForSort);
        }

        /// <summary>
        /// Test for Quick Sort. Array contains random elements
        /// </summary>
        [TestMethod]
        public void MergeSortTest_ArrayRandomElements_SortedArray()
        {
            Random random = new Random();
            int[] arrayForSort = new int[200000];
            foreach (var item in arrayForSort)
            {
                arrayForSort[item] = random.Next(int.MinValue, int.MaxValue);
            }
            int[] sortedArray = new int[arrayForSort.Length];
            Array.Copy(arrayForSort, sortedArray, sortedArray.Length);
            Array.Sort(sortedArray);

            Sorting.MergeSort(arrayForSort, arrayForSort.Length - 1, 0);

            CollectionAssert.AreEqual(sortedArray, arrayForSort);
        }
    }
}
