using System;
using NUnit.Framework;

namespace NET.S._2018.Dvorkin.Task1.Tests
{
    [TestFixture]
    public class FindRootTests
    {
        [TestCase(1, 5, 0.0001)]
        public void FindRoots_1_5_00001_Expect1(double element, int pow, double eps) => Assert.AreEqual(1, FindRoot.FindNthRoot(element, pow, eps), 0.0001);

        [TestCase(8, 3, 0.0001)]
        public void FindRoots_8_3_00001_Expect2(double element, int pow, double eps)
        {
            Assert.AreEqual(2, FindRoot.FindNthRoot(element, pow, eps), 0.0001);
        }

        [TestCase(0.001, 3, 0.0001)]
        public void FindRoots_0001_3_00001_Expect01(double element, int pow, double eps)
        {
            Assert.AreEqual(0.1, FindRoot.FindNthRoot(element, pow, eps), 0.0001);
        }

        [TestCase(0.04100625, 4, 0.0001)]
        public void FindRoots_004100625_4_00001_Expect045(double element, int pow, double eps)
        {
            Assert.AreEqual(0.45, FindRoot.FindNthRoot(element, pow, eps), 0.0001);
        }
        
        [TestCase(0.0279936, 7, 0.0001)]
        public void FindRoots_00279936_7_00001_Expect06(double element, int pow, double eps)
        {
            Assert.AreEqual(0.6, FindRoot.FindNthRoot(element, pow, eps), 0.0001);
        }

        [TestCase(0.0081, 4, 0.1)]
        public void FindRoots_00081_4_01_Expect03(double element, int pow, double eps)
        {
            Assert.AreEqual(0.3, FindRoot.FindNthRoot(element, pow, eps), 0.1);
        }

        [TestCase(-0.008, 3, 0.1)]
        public void FindRoots_M0008_3_01_ExpectM02(double element, int pow, double eps)
        {
            Assert.AreEqual(-0.2, FindRoot.FindNthRoot(element, pow, eps), 0.1);
        }

        [TestCase(0.004241979, 9, 0.00000001)]
        public void FindRoots_0004241979_9_000000001_Expect0545(double element, int pow, double eps)
        {
            Assert.AreEqual(0.545, FindRoot.FindNthRoot(element, pow, eps), 0.00000001);
        }

        [TestCase(8, 15, -7)]
        public void FindRoots_8_15_M7_ArgumentException(double element, int pow, double eps)
        {
            Assert.Throws<ArgumentException>(() => FindRoot.FindNthRoot(element, pow, eps));
        }

        [TestCase(8, 15, -0.6)]
        public void FindRoots_8_15_M06_ArgumentException(double element, int pow, double eps)
        {
            Assert.Throws<ArgumentException>(() => FindRoot.FindNthRoot(element, pow, eps));
        }
    }
}
