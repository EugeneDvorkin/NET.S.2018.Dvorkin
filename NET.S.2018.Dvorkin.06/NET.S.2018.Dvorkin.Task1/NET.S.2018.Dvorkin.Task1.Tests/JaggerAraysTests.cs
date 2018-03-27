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

                SumIncreasingSort(actual);

                int[][] expected = new int[4][];
                expected[0] = secondRow;
                expected[1] = fouthRow;
                expected[2] = firstRow;
                expected[3] = thirdRow;

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


                MaxIncreasingSort(actual);

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


                MinIncreasingSort(actual);

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

                SumDecreasingSort(actual);

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
                expected[0] = secondRow;
                expected[1] = fouthRow;
                expected[2] = thirdRow;
                expected[3] = firstRow;

                MaxDecreasingSort(actual);

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
                expected[0] = secondRow;
                expected[1] = fouthRow;
                expected[2] = thirdRow;
                expected[3] = firstRow;

                MinDecreasingSort(actual);

                CollectionAssert.AreEqual(expected, actual);
            }
        }
    }
}
