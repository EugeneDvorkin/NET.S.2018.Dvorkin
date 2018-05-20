using System;
using System.Collections.Generic;
using System.Linq;
using Bll.Interface.Entities;
using Bll.Interface.Interface;
using DependencyResolver;
using Ninject;
using NUnit.Framework;

namespace BLL.Tests
{
    [TestFixture]
    public class ServiceTestsNUnit
    {
        private IKernel kernel = new StandardKernel();

        [TestCase]
        public void Deposit_ValidValue_ValidResult()
        {
            IBankService service = GetKernel();
            service.NewAccount(1, 1000m, 1);
            List<AccountBll> storage = service.AllAccount().ToList();
            AccountBll temp = storage.Find(item => item.PersoneId == 1);
            service.Deposit(1000m, temp);
            Assert.AreEqual(2000m, temp.Balance);
        }

        [TestCase]
        public void Withdrawal_ValidValue_ValidResult()
        {
            IBankService service = GetKernel();
            service.NewAccount(1, 2000m, 1);
            List<AccountBll> storage = service.AllAccount().ToList();
            AccountBll temp = storage.Find(item => item.PersoneId == 1);
            service.Withdrawal(1000m, temp);
            Assert.AreEqual(1000m, temp.Balance);
        }

        [TestCase]
        public void Transfer_ValidValue_ValidResult()
        {
            IBankService service = GetKernel();
            service.NewAccount(2, 2000m, 1);
            service.NewAccount(1, 1000m, 1);
            List<AccountBll> storage = service.AllAccount().ToList();
            AccountBll firstPersone= storage.Find(item => item.PersoneId == 1);
            AccountBll secondPersone = storage.Find(item => item.PersoneId == 2);
            service.Transfer(secondPersone, firstPersone, 500m);
            Assert.AreEqual(1500m, firstPersone.Balance);
        }

        [TestCase]
        public void CloseAccount_ValidParams_ValidResult()
        {
            IBankService service = GetKernel();
            service.NewAccount(1, 1000m, 1);
            List<AccountBll> storage = service.AllAccount().ToList();
            AccountBll temp = storage.Find(item => item.PersoneId == 1);
            service.Withdrawal(1000m, temp);
            service.CloseAccount(temp);
            Assert.AreEqual(false, temp.Valid);
        }

        [TestCase]
        public void CreateOwner_InvalidParams_ArgumentException()
        {
            IBankService service = GetKernel();
            service.NewOwner("Owner1", "Owner2", "123456");
            Assert.Throws<ArgumentException>(() => service.NewOwner("Owner2", "Owner2", "123456"));
        }

        [TestCase]
        public void Withdrawal_InvalidParams_ArgumentException()
        {
            IBankService service = GetKernel();
            service.NewAccount(1, 1000m, 1);
            List<AccountBll> storage = service.AllAccount().ToList();
            AccountBll temp = storage.Find(item => item.PersoneId == 1);
            Assert.Throws<ArgumentException>(() => service.Withdrawal(2000m, temp));
        }

        [TestCase]
        public void Transfer_InvalidParams_ArgumentException()
        {
            IBankService service = GetKernel();
            service.NewAccount(2, 2000m, 1);
            service.NewAccount(1, 1000m, 1);
            List<AccountBll> storage = service.AllAccount().ToList();
            AccountBll firstPersone = storage.Find(item => item.PersoneId == 1);
            AccountBll secondPersone = storage.Find(item => item.PersoneId == 2);
            Assert.Throws<ArgumentException>(() => service.Transfer(secondPersone, firstPersone, 3000m));
        }

        [TestCase]
        public void CloseAccount_InvalidParams_ArgumentException()
        {
            IBankService service = GetKernel();
            service.NewAccount(1, 1000m, 1);
            List<AccountBll> storage = service.AllAccount().ToList();
            AccountBll temp = storage.Find(item => item.PersoneId == 1);
            Assert.Throws<ArgumentException>(() => service.CloseAccount(temp));
        }

        private IBankService GetKernel()
        {
            kernel.ConfigurateResolver();

            return kernel.Get<IBankService>();
        }
    }
}
