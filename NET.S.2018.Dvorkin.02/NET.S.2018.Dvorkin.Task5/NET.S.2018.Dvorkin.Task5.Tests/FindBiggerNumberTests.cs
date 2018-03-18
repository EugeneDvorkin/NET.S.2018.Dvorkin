using System;
using NUnit.Framework;

namespace NET.S._2018.Dvorkin.Task5.Tests
{
    [TestFixture]
    public class FindBiggerNumberTests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        [TestCase(111, ExpectedResult =-1)]
        public int FindNextBiggerNumber_ValidNumber_NextBiggerNumber(int number) => FindBiggerNumber.FindNextBiggerNumber(number);

        [TestCase(-5)]
        [TestCase(0)]
        public void FindNextBiggerNumber_InvalidNumber_ArgumentException(int number) => 
            Assert.Throws<ArgumentException>(() => FindBiggerNumber.FindNextBiggerNumber(number)); 

        [TestCase(2170, 2701)]
        [TestCase(514, 541)]
        [TestCase(747, 774)]
        [TestCase(123, 132)]
        [TestCase(111, -1)]
        [TestCase(31,-1)]        
        public void FindNextBiggerNumberWithTimeOfWork_ValidNumbers_NextbiggerNumbers(int number, int expect)
        {
            double expectedTime = 10;

            Assert.AreEqual(expect, FindBiggerNumber.FindNextBiggerNumberWithTimer(number, out double actualTime));
            Assert.GreaterOrEqual(expectedTime, actualTime);
        }

        [TestCase(-5)]
        [TestCase(0)]
        public void FindNextBiggerNumberWithTimeOfWork_InvalidNumber_ArgumentException(int number)
        {
            Assert.Throws<ArgumentException>(() => FindBiggerNumber.FindNextBiggerNumberWithTimer(number, out double actualTime));           
        }
            
    }
}
