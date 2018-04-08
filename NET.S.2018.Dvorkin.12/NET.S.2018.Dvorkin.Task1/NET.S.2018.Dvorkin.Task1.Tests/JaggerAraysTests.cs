using System;
using NUnit.Framework;
using static NET.S._2018.Dvorkin.Task1.JaggerArays;

namespace NET.S._2018.Dvorkin.Task1.Tests
{
    [TestFixture]
    public class JaggerAraysTests
    {
        [TestFixture]
        public class JaggedArraySortTests
        {
            [TestCase(new int[] { 1, 1, 1, 1, 1, 1 }, new int[] { 2, 2 }, null, new int[] { 5 })]
            public void SortBySumIncreasingTest_ReturnsSortedArray(int[] firstRow, int[] secondRow, int[] thirdRow, int[] fouthRow)
            {
                int[][] actual = new int[4][];
                actual[0] = fouthRow;
                actual[1] = thirdRow;
                actual[2] = firstRow;
                actual[3] = secondRow;

                BubbleSort(actual, new ComparerSumIncrease());

                int[][] expected = new int[4][];
                expected[0] = thirdRow;
                expected[1] = secondRow;
                expected[2] = fouthRow;
                expected[3] = firstRow;

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 1, 1, 1, 1, 1, 1 }, null, new int[] { 2, 2 }, new int[] { 5 })]
            public void SortByMaxIncreasingTest_ReturnsSortedArray(int[] firstRow, int[] secondRow, int[] thirdRow, int[] fouthRow)
            {
                int[][] actual = new int[4][];
                actual[0] = thirdRow;
                actual[1] = secondRow;
                actual[2] = fouthRow;
                actual[3] = firstRow;


                BubbleSort(actual, new ComparerMaxEncrease());

                int[][] expected = new int[4][];
                expected[0] = firstRow;
                expected[1] = thirdRow;
                expected[2] = fouthRow;
                expected[3] = secondRow;

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 1, 1, 1, 1, 1, 1 }, null, new int[] { 2, 2 }, new int[] { 5 })]
            public void SortByMinIncreasingTest_ReturnsSortedArray(int[] firstRow, int[] secondRow, int[] thirdRow, int[] fouthRow)
            {
                int[][] actual = new int[4][];
                actual[0] = thirdRow;
                actual[1] = secondRow;
                actual[2] = fouthRow;
                actual[3] = firstRow;


                BubbleSort(actual, new ComparerMinEncrease());

                int[][] expected = new int[4][];
                expected[0] = firstRow;
                expected[1] = thirdRow;
                expected[2] = fouthRow;
                expected[3] = secondRow;

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 1, 1, 1, 1, 1, 1 }, null, new int[] { 2, 2 }, new int[] { 5 })]
            public void SortBySumDecreasingTest_ReturnsSortedArray(int[] firstRow, int[] secondRow, int[] thirdRow, int[] fouthRow)
            {
                int[][] actual = new int[4][];
                actual[0] = fouthRow;
                actual[1] = secondRow;
                actual[2] = thirdRow;
                actual[3] = firstRow;

                int[][] expected = new int[4][];
                expected[0] = secondRow;
                expected[1] = firstRow;
                expected[2] = fouthRow;
                expected[3] = thirdRow;

                BubbleSort(actual, new ComparerSumDecrease());

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 1, 1, 1, 1, 1, 1 }, null, new int[] { 2, 2 }, new int[] { 5 })]
            public void SortByMaxDecreasingTest_ReturnsSortedArray(int[] firstRow, int[] secondRow, int[] thirdRow, int[] fouthRow)
            {
                int[][] actual = new int[4][];
                actual[0] = fouthRow;
                actual[1] = secondRow;
                actual[2] = thirdRow;
                actual[3] = firstRow;

                int[][] expected = new int[4][];
                expected[0] = fouthRow;
                expected[1] = thirdRow;
                expected[2] = firstRow;
                expected[3] = secondRow;

                BubbleSort(actual, new ComparerMaxDecrease());

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 1, 1, 1, 1, 1, 1 }, null, new int[] { 2, 2 }, new int[] { 5 })]
            public void SortByMinDecreasingTest_ReturnsSortedArray(int[] firstRow, int[] secondRow, int[] thirdRow, int[] fouthRow)
            {
                int[][] actual = new int[4][];
                actual[0] = fouthRow;
                actual[1] = secondRow;
                actual[2] = thirdRow;
                actual[3] = firstRow;

                int[][] expected = new int[4][];
                expected[0] = fouthRow;
                expected[1] = thirdRow;
                expected[2] = firstRow;
                expected[3] = secondRow;

                BubbleSort(actual, new ComparerMinDecrease());

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 1, 1, 1, 1, 1, 1 }, new int[] { 2, 2 }, null, new int[] { 5 })]
            public void SortWithFuncComparer(int[] firstRow, int[] secondRow, int[] thirdRow, int[] fouthRow)
            {
                int[][] actual = new int[4][];
                actual[0] = fouthRow;
                actual[1] = thirdRow;
                actual[2] = firstRow;
                actual[3] = secondRow;
                ComparerSumIncrease SumInc = new ComparerSumIncrease();
                Predicate predicate = SumInc.Compare;

                BubbleSort(actual, predicate);

                int[][] expected = new int[4][];
                expected[0] = thirdRow;
                expected[1] = secondRow;
                expected[2] = fouthRow;
                expected[3] = firstRow;

                BubbleSort(actual, predicate);
            }

            [TestCase(new int[] { 1, 1, 1, 1, 1, 1 }, new int[] { 2, 2 }, null, new int[] { 5 })]
            public void SortWithFuncDelegate(int[] firstRow, int[] secondRow, int[] thirdRow, int[] fouthRow)
            {
                int[][] actual = new int[4][];
                actual[0] = fouthRow;
                actual[1] = thirdRow;
                actual[2] = firstRow;
                actual[3] = secondRow;
                ComparerSumIncrease SumInc = new ComparerSumIncrease();
                Predicate predicate = SumInc.Compare;

                ComparerFunc comparerFunc = new ComparerFunc(predicate);

                BubbleSort(actual, comparerFunc);

                int[][] expected = new int[4][];
                expected[0] = thirdRow;
                expected[1] = secondRow;
                expected[2] = fouthRow;
                expected[3] = firstRow;

                BubbleSort(actual, predicate);
            }
        }
    }
}
