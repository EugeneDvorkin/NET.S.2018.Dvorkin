using System;
using NUnit.Framework;

namespace NET.S._2018.Dvorkin.Task1.Tests
{
    [TestFixture]
    public class BankServiceTests
    {
        Acc acc = new Acc("QDG1HGUNGP347G5", "John", "Smith", "1736GH163644", 1000);
        BankService bankService = new BankService();

        [TestCase]
        public void Replenishment_ValidAcc_ValidResult()
        {
            acc = bankService.Replenishment(200, acc);

            Assert.AreEqual(1200m, acc.Account);
        }

        [TestCase()]
        public void Withdrawal_ValidAcc_ValidResult()
        {
            acc = bankService.Withdrawal(200, acc);

            Assert.AreEqual(800, acc.Account);
        }

        [TestCase()]
        public void CloseAcc_ValidAcc_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => bankService.CloseAcc(acc));
        }

        [TestCase()]
        public void CheckAccount_ValidAcc_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => bankService.Replenishment(-200, acc));
        }
    }
}
