using Microsoft.VisualStudio.TestTools.UnitTesting;
using static NET.S._2018.Dvorkin.Task1.InsertNumbers;

namespace NET.S._2018.Dvorkin.Task1.Tests
{
    [TestClass]
    public class InserNumberUnitTest
    {
        [TestMethod]
        public void InertNumber_Target15Insert15_15()
        {
            Assert.AreEqual(15, InsertNumber(15, 15, 0, 30));
        }

        [TestMethod]
        public void InsertNumber_Target358Insert522_267622()
        {
            Assert.AreEqual(267622, InsertNumber(358, 522, 9, 30));
        }

        [TestMethod]
        public void InsertNumber_Target15Insert9_11()
        {
            Assert.AreEqual(11, InsertNumber(15, 9, 1, 2));
        }

        [TestMethod]
        public void InsertNumber_Target8Insert15_9()
        {
            Assert.AreEqual(9, InsertNumber(8, 15, 0, 0));
        }

        [TestMethod]
        public void InsertNumber_Target8Insert15_120()
        {
            Assert.AreEqual(120, InsertNumber(8, 15, 3, 8));
        }
    }
}
