using System;
using NUnit.Framework;

namespace NET.S._2018.Dvorkin.Task2.Tests
{
    [TestFixture]
    public class GsdsTests
    {
        [TestCase(12, 24, 36, 48, 72, ExpectedResult = 12)]
        [TestCase(-12, -24, -36, -48, -72, ExpectedResult = 12)]
        [TestCase(12, 0, 0, 0, 0, ExpectedResult = 12)]
        [TestCase(-12, 24, -36, 48, -72, ExpectedResult = 12)]
        [TestCase(12, 1, int.MaxValue, ExpectedResult = 1)]
        [TestCase(12, 12, ExpectedResult = 12)]
        public int Gsds_Elem_12(params int[] numbInts)
        {
            return Gsds.GsdParams(numbInts);
        }

        [Test]
        public void Gsds_InvalidElem_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Gsds.GsdParams(-12, 12, int.MinValue));
        }

        [Test]
        public void Gsds_NullElem_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Gsds.GsdParams());
        }

        [TestCase(12, 24, 36, 48, 72, ExpectedResult = 12)]
        [TestCase(-12, -24, -36, -48, -72, ExpectedResult = 12)]
        [TestCase(12, 0, 0, 0, 0, ExpectedResult = 12)]
        [TestCase(-12, 24, -36, 48, -72, ExpectedResult = 12)]
        [TestCase(12, 1, int.MaxValue, ExpectedResult = 1)]
        [TestCase(12, 12, ExpectedResult = 12)]
        public int GsdsBin_Elem_12(params int[] numbInts)
        {
            return Gsds.BinaryGsdParams(numbInts);
        }

        [Test]
        public void GsdsBin_InvalidElem_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Gsds.BinaryGsdParams(-12, 12, int.MinValue));
        }

        [Test]
        public void GsdsBin_NullElem_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Gsds.BinaryGsdParams());
        }
    }
}
