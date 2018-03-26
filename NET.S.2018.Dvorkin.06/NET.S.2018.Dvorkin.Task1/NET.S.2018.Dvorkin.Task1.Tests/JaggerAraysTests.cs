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
                actual[0] = secondRow;
                actual[1] = thirdRow;
                actual[2] = firstRow;
                actual[3] = fouthRow;

                SumIncreasingSort(actual);

                int[][] expected = new int[4][];
                expected[0] = secondRow; 
                expected[1] = thirdRow; 
                expected[2] = firstRow;
                expected[3] = fouthRow;

                CollectionAssert.AreEqual(expected, actual);
            }

            
        }
    }
}
