using System;
using System.Data.Entity.Core.Metadata.Edm;
using Bll.Interface.Entities;
using Bll.Interface.Interface;
using DependencyResolver;
using Ninject;
using System.Linq;

namespace ConsolePL
{
    class Program
    {
        private static IKernel kernel;

        static void Main(string[] args)
        {
            kernel = new StandardKernel();
            kernel.ConfigurateResolver();
            IBankService service = kernel.Get<IBankService>();
            //service.NewOwner("Owner1", "Owner1", "123456", "qwer@mail.ru");
            //service.NewAccount(1, 1000m, 2);
            AccountBll temp = service.FindAccount(1158234195);
            Console.WriteLine(temp.Person.Name);

            PersonBll tempP = service.FindPerson("123456");
            //PersonBll person = service.FindPerson("123456");
            Console.WriteLine(tempP.Accounts.FirstOrDefault(item=>item.Number== 1158234195).Number);

            //Console.WriteLine(account.PersoneId);
        }
    }
}
