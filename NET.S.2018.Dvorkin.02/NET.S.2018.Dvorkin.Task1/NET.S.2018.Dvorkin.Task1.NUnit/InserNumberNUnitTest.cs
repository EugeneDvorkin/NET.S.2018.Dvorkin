using NUnit.Framework;
using static NET.S._2018.Dvorkin.Task1.InsertNumbers;

namespace NET.S._2018.Dvorkin.Task1.NUnit
{
    [TestFixture]
    public class InserNumberNUnitTest
    {
        [TestCase(15, 15, 0, 30, ExpectedResult = 15)]
        [TestCase(358, 522, 9, 30, ExpectedResult = 267622)]
        [TestCase(15, 9, 1, 2, ExpectedResult = 11)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(8, int.MaxValue, 0, 31, ExpectedResult = int.MaxValue)]        
        public int InsertBitsInNumber(int targretNumber, int insertNumber, int startBit, int endBit)
        {
            return InsertNumber(targretNumber, insertNumber, startBit, endBit);
        }

        [TestCase(15, 15, 0, 30, ExpectedResult = 15)]
        [TestCase(358, 522, 9, 30, ExpectedResult = 267622)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(8, int.MaxValue, 0, 31, ExpectedResult = int.MaxValue)]
        public int InsertBitsInNumber_BitsOperations(int targretNumber, int insertNumber, int startBit, int endBit)
        {
            return InsertNumber_BitsOperation(targretNumber, insertNumber, startBit, endBit);
        }
    }
}
